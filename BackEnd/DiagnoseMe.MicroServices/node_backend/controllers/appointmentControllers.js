const asyncHandler = require('express-async-handler');
const Appointment = require('../models/appointmentModel');
const { parseISO, format, parse, addHours } = require('date-fns');
const { v4: uuidv4 } = require('uuid');
const { AppError } = require('../middleware/errorMiddleware');
const AvailableTimes = require('../models/availableTimes');
const sendToQueue = require('../utils/sender');
const User = require('../models/userModel');

const extractTime = (dateString) => {
  const date = dateString.length == 8 ? parseISO(`1970-01-01T${dateString}Z`) : parseISO(dateString);
  const isoDateString = format(date, "yyyy-MM-dd'T'HH:mm:ss.SSSxxx");
  return isoDateString;
};

const extractDate = (dateIsoString) => {
  let date = parseISO(dateIsoString);
  const day = format(date, 'd');
  const month = format(date, 'M');
  const year = format(date, 'yyyy');
  const dateString = `${year}-${month.padStart(2, '0')}-${day.padStart(2, '0')}`;
  date = parse(dateString, 'yyyy-MM-dd', new Date());
  const isoDateString = format(date, "yyyy-MM-dd'T'HH:mm:ss.SSSxxx");
  return isoDateString;
};

//

// Adding available Date for the doctor
const addAvailableTime = asyncHandler(async (req, res, next) => {
  if (!req.user.Role.includes('Doctor')) {
    return next(new AppError('Only Doctors Can Add Available Time', 403));
  }

  const doctorId = req.user._id;
  const dateISO = extractDate(req.body.date);
  const startTime = extractTime(req.body.time);
  const graceTime = addHours(parseISO(startTime), 1);

  if (parseISO(dateISO) < new Date()) {
    return next(new AppError('This date is old, You have to provide a new Date stupid😕', 400));
  }

  const result1 = await AvailableTimes.findOne({ day: dateISO, doctorId });

  if (!result1) {
    const createdDate = await AvailableTimes.create({
      _id: uuidv4(),
      day: dateISO,
      doctorId,
      times: [{ startTime, graceTime }],
    });
    return res.status(201).json(createdDate);
  }

  const result2 = await AvailableTimes.findOne({
    $and: [
      { day: dateISO },
      { doctorId },
      { $or: [{ 'times.startTime': startTime }, { 'times.graceTime': startTime }] },
    ],
  });

  if (result2) {
    return next(new AppError('this time is already exists', 400));
    // return res.status(200).json('this time is already exists');
  }

  const createdDate = await AvailableTimes.findOneAndUpdate(
    { day: dateISO, doctorId },
    { $push: { times: { startTime, graceTime } } },
    { new: true }
  ).select('-__v -_id -doctorId');

  res.status(201).json(createdDate);
});

//
// Delete available time
const deleteAvailableTime = asyncHandler(async (req, res, next) => {
  if (!req.user.Role.includes('Doctor')) {
    return next(new AppError('Only Doctors Can Delete an Available Time', 403));
  }

  const day = extractDate(req.body.day);
  const timeId = req.body.timeId;
  const doctorId = req.user._id;

  // delete the time selected
  const updatedTimes = await AvailableTimes.findOneAndUpdate(
    { day, doctorId },
    { $pull: { times: { _id: timeId } } },
    { new: true }
  );

  // if there is no more times in that day delete the day
  if (updatedTimes.times.length == 0) {
    await AvailableTimes.findByIdAndDelete(updatedTimes._id);
  }

  res.status(200).json({ message: 'The Time Deleted Succesfully' });
});

//
//Clear all available times
const clearAvailableTimes = asyncHandler(async (req, res, next) => {
  if (!req.user.Role.includes('Doctor')) {
    next(new AppError('Only Doctors Can Clear Available Times', 403));
  }
  const doctorId = req.user._id;

  const ack = await AvailableTimes.deleteMany({ doctorId });

  res.status(201).json(ack);
});

//
// Get available Times for Doctor
const getAvailableTimes = asyncHandler(async (req, res, next) => {
  const doctorId = req.params.doctorId;

  if (!doctorId) {
    return next(new AppError('you have to provide Doctor Id 👌 in the url', 400));
  }
  const timesFound = await AvailableTimes.find({ doctorId }).select('-__v -_id -doctorId');

  res.status(200).json(timesFound);
});

//
// Book an appointment
const bookAppointment = asyncHandler(async (req, res, next) => {
  const { doctorId, patientId, timeId, price, note } = req.body;
  const day = extractDate(req.body.day);

  const timeSelected = await AvailableTimes.findOne({ day, doctorId, 'times._id': timeId }, { 'times.$': 1 });

  if (!timeSelected) {
    return next(new AppError('There is no Available time to book matches the data you provided', 404));
  }

  const { startTime, graceTime } = timeSelected.times[0];

  // delete the time selected in the appointment
  const result = await AvailableTimes.findOneAndUpdate(
    { day, doctorId },
    { $pull: { times: { _id: timeId } } },
    { new: true }
  );

  // if there is no more times in that day delete the day
  if (result.times.length == 0) {
    await AvailableTimes.findByIdAndDelete(result._id);
  }

  const createdAppointment = await Appointment.create({
    _id: uuidv4(),
    day,
    startTime,
    graceTime,
    patientId,
    doctorId,
    price,
    note,
  });

  res.status(200).json(createdAppointment);
});

//
// Delete booked appointment
const deleteBookedAppointment = asyncHandler(async (req, res, next) => {
  const { appointmentId } = req.params;

  const deletedAppointment = await Appointment.findByIdAndDelete(appointmentId);
  res.status(200).json({ deletedAppointment });
});

//
// Change the booked appointment status to approved or canceled
const changeBookedStatus = asyncHandler(async (req, res, next) => {
  const bookedAppointmentId = req.params.appointmentId;
  const status = req.body.status;

  const editedAppointment = await Appointment.findByIdAndUpdate(
    bookedAppointmentId,
    { $set: { status } },
    { new: true, runValidators: true }
  ).select('-__v');

  if (status == 'approved') {
    await User.findByIdAndUpdate(editedAppointment.doctorId, { $inc: { numOfPatients: 1 } });
    console.log('number of patients increased by 1');
    const message = JSON.stringify({
      DoctorId: editedAppointment.doctorId,
      PatientId: editedAppointment.patientId,
    });
    console.log('message sent:✅', message);
    sendToQueue('PatientsNum.Update', message);
  }

  res.status(201).json(editedAppointment);
});

//
//Get all booked appointments for specific user
const getAllBookedAppointments = asyncHandler(async (req, res) => {
  const userId = req.user._id;

  const appointments = await Appointment.find({
    $or: [{ patientId: userId }, { doctorId: userId }],
  })
    .select('-__v')
    .populate('doctorId', '-password -__v')
    .populate('patientId', '-passwords -__v')
    .sort('startTime');

  res.status(201).json(appointments);
});

const getAllBookingsAdmin = asyncHandler(async (req, res, next) => {
  console.log({ filter: req.body });
  const bookings = await Appointment.find(req.body);
  res.status(201).json({ bookings });
});

const getBookingStatistics = asyncHandler(async (req, res, next) => {
  const totalBooked = await Appointment.countDocuments();
  const canceled = await Appointment.countDocuments({ status: 'canceled' });
  const approvedResults = await Appointment.aggregate([
    {
      $match: { status: 'approved' },
    },
    {
      $group: {
        _id: '$status',
        total_price: {
          $sum: '$price',
        },
        approved: {
          $sum: 1,
        },
      },
    },
  ]);

  res.status(201).json({ totalBooked, canceled, approved: approvedResults[0] });
});

module.exports = {
  addAvailableTime,
  deleteAvailableTime,
  clearAvailableTimes,
  getAvailableTimes,
  bookAppointment,
  deleteBookedAppointment,
  changeBookedStatus,
  getAllBookedAppointments,
  getAllBookingsAdmin,
  getBookingStatistics,
};

//
// Adding available Repeated Dates for the doctor
// const addAvailableRepeatedDate = asyncHandler(async (req, res) => {
//   const userId = req.user._id;

//   // values needed
//   const { start_date, end_date, frequency, recurring_days } = req.body;
//   const times = req.body.times.map((obj) => {
//     obj.start_time = extractTime(obj.start_time);
//     obj.end_time = extractTime(obj.end_time);
//     return obj;
//   });

//   // update the calendar
//   const updatedCalender = await Calendar.findOneAndUpdate(
//     { doctorId: userId },
//     {
//       $push: { repeated_dates: { start_date, end_date, frequency, recurring_days, times } },
//     },
//     { new: true, runValidators: true }
//   );
//   res.status(201).json(updatedCalender);
// });

//
//Clear Repeated available Dates in the doctor's calendar
// const clearRepeatedDates = asyncHandler(async (req, res) => {
//   const userId = req.user._id;

//   const updatedCalendar = await Calendar.findOneAndUpdate(
//     { doctorId: userId },
//     {
//       repeated_dates: [],
//     },
//     { new: true }
//   );
//   res.status(201).json(updatedCalendar);
// });

//
// Update Repeated dates
// const updateRepeatedDate = asyncHandler(async (req, res) => {
//   const { dateId } = req.params;

//   // values needed
//   const { start_date, end_date, frequency, recurring_days } = req.body;
//   const times = req.body.times.map((obj) => {
//     obj.start_time = extractTime(obj.start_time);
//     obj.end_time = extractTime(obj.end_time);
//     return obj;
//   });

//   const updatedCalendar = await Calendar.findOneAndUpdate(
//     { doctorId: req.user._id, repeated_dates: { $elemMatch: { _id: dateId } } },
//     { $set: { 'repeated_dates.$': { _id: dateId, start_date, end_date, frequency, recurring_days, times } } },
//     {
//       new: true,
//       runValidators: true,
//     }
//   );
//   res.status(200).json(updatedCalendar);
// });

//
// Update individual dates
// const updateIndiviualDate = asyncHandler(async (req, res) => {
//   if (!req.user.Role.includes('Doctor') || req.user.Role.includes('Admin'))) {
//     next(new AppError('Only Doctors Can Add Available Dates', 403));
//   }

//   const { dateId } = req.params;

//   // values needed
//   const date = parseISO(req.body.date);
//   const times = req.body.times.map((obj) => {
//     obj.start_time = extractTime(obj.start_time);
//     obj.end_time = extractTime(obj.end_time);
//     return obj;
//   });

//   const updatedCalendar = await Calendar.findOneAndUpdate(
//     { doctorId: req.user._id, individual_dates: { $elemMatch: { _id: dateId } } },
//     { $set: { 'individual_dates.$': { _id: dateId, date, times } } },
//     {
//       new: true,
//       runValidators: true,
//     }
//   );
//   res.status(200).json(updatedCalendar);
// });

// const individual_dates = await Calendar.aggregate([
//   { $match: { doctorId } },
//   {
//     $project: {
//       _id: 0,
//       individual_dates: 1,
//     },
//   },
//   { $unwind: '$individual_dates' },
//   { $match: { 'individual_dates.date': { $gte: new Date() } } },

//   { $sort: { 'individual_dates.date': 1 } },
//   {
//     $replaceRoot: {
//       newRoot: '$individual_dates',
//     },
//   },
// ]);
