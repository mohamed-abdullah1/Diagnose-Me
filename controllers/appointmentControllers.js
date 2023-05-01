const asyncHandler = require('express-async-handler');
const Calendar = require('../models/calendarModel');
const Appointment = require('../models/appointmentModel');
const User = require('../models/userModel');
const { parseISO } = require('date-fns');
const { v4: uuidv4 } = require('uuid');

const parsing = (dateString) => {
  return dateString.length == 8 ? parseISO(`1970-01-01T${dateString}Z`) : parseISO(dateString);
};

//
// Adding available Individual Dates for the doctor
const addAvailableIndividualDate = asyncHandler(async (req, res) => {
  const userId = req.user._id;

  // values needed
  const date = parseISO(req.body.date);
  const times = req.body.times.map((obj) => {
    obj.start_time = parsing(obj.start_time);
    obj.end_time = parsing(obj.end_time);
    return obj;
  });

  // update the calendar
  const updatedCalendar = await Calendar.findOneAndUpdate(
    { doctorId: userId },
    {
      $push: { individual_dates: { date, times } },
    },
    { new: true, runValidators: true, returnOriginal: false }
  );
  res.status(201).json(updatedCalendar);
});

//
// Adding available Repeated Dates for the doctor
const addAvailableRepeatedDate = asyncHandler(async (req, res) => {
  const userId = req.user._id;

  // values needed
  const { start_date, end_date, frequency, recurring_days } = req.body;
  const times = req.body.times.map((obj) => {
    obj.start_time = parsing(obj.start_time);
    obj.end_time = parsing(obj.end_time);
    return obj;
  });

  // update the calendar
  const updatedCalender = await Calendar.findOneAndUpdate(
    { doctorId: userId },
    {
      $push: { repeated_dates: { start_date, end_date, frequency, recurring_days, times } },
    },
    { new: true, runValidators: true }
  );
  res.status(201).json(updatedCalender);
});

//
// Update individual dates
const updateIndiviualDate = asyncHandler(async (req, res) => {
  const { dateId } = req.params;

  // values needed
  const date = parseISO(req.body.date);
  const times = req.body.times.map((obj) => {
    obj.start_time = parsing(obj.start_time);
    obj.end_time = parsing(obj.end_time);
    return obj;
  });

  const updatedCalendar = await Calendar.findOneAndUpdate(
    { doctorId: req.user._id, individual_dates: { $elemMatch: { _id: dateId } } },
    { $set: { 'individual_dates.$': { _id: dateId, date, times } } },
    {
      new: true,
      runValidators: true,
    }
  );
  res.status(200).json(updatedCalendar);
});

//
// Update Repeated dates
const updateRepeatedDate = asyncHandler(async (req, res) => {
  const { dateId } = req.params;

  // values needed
  const { start_date, end_date, frequency, recurring_days } = req.body;
  const times = req.body.times.map((obj) => {
    obj.start_time = parsing(obj.start_time);
    obj.end_time = parsing(obj.end_time);
    return obj;
  });

  const updatedCalendar = await Calendar.findOneAndUpdate(
    { doctorId: req.user._id, repeated_dates: { $elemMatch: { _id: dateId } } },
    { $set: { 'repeated_dates.$': { _id: dateId, start_date, end_date, frequency, recurring_days, times } } },
    {
      new: true,
      runValidators: true,
    }
  );
  res.status(200).json(updatedCalendar);
});

//
// Delete available dates
const deleteAvailableDate = asyncHandler(async (req, res) => {
  const { dateId } = req.body;
  const userId = req.user._id;
  const updatedCalender = await Calendar.findOneAndUpdate(
    { doctorId: userId },
    {
      $pull: { repeated_dates: { _id: dateId }, individual_dates: { _id: dateId } },
    },
    { new: true }
  ).exec();
  res.status(200).json(updatedCalender);
});

//
// Get available dates for Doctor
const getAvailableDates = asyncHandler(async (req, res) => {
  const doctorId = req.user._id;
  const calendarFetched = await Calendar.findOne({ doctorId });
  res.status(200).json({ calendarFetched });
});
//
// Book an appointment
const bookAppointment = asyncHandler(async (req, res) => {
  const start_date = parseISO(req.body.start_date);
  const end_date = parseISO(req.body.end_date);
  const doctor_id = req.body.doctor_id;
  const patient_id = req.body.patient_id;
  //
  const createdAppointment = await Appointment.create({
    _id: uuidv4(),
    start_date,
    end_date,
    doctor_id,
    patient_id,
  });
  res.status(200).json(createdAppointment);
});

//
// Delete booked appointment
const deleteBookedAppointment = asyncHandler(async (req, res) => {
  const { appointmentId } = req.body;
  if (!appointmentId) {
    res.status(400).json('were is the appointment ID ?? 😐');
  }
  const deletedAppointment = await Appointment.findByIdAndDelete(appointmentId);
  res.status(200).json({ deletedAppointment });
});

//
//Clear Repeated Individual Dates in the doctor's calendar
const clearIndividualDates = asyncHandler(async (req, res) => {
  const userId = req.user._id;

  const updatedCalendar = await Calendar.findOneAndUpdate(
    { doctorId: userId },
    {
      individual_dates: [],
    },
    { new: true }
  );
  res.status(201).json(updatedCalendar);
});

//
//Clear Repeated available Dates in the doctor's calendar
const clearRepeatedDates = asyncHandler(async (req, res) => {
  const userId = req.user._id;

  const updatedCalendar = await Calendar.findOneAndUpdate(
    { doctorId: userId },
    {
      repeated_dates: [],
    },
    { new: true }
  );
  res.status(201).json(updatedCalendar);
});

//
// Change the booked appointment status to approved or canceled
const changeBookedStatus = asyncHandler(async (req, res) => {
  const bookedAppointmentId = req.params.bookedId;
  const status = req.body.status;

  const editedAppointment = await Appointment.findByIdAndUpdate(
    bookedAppointmentId,
    { $set: { status } },
    { new: true, runValidators: true }
  );

  res.status(201).json(editedAppointment);
});

//
//Get all booked appointments for specific user
const getAllBookedAppointments = asyncHandler(async (req, res) => {
  const userId = req.user._id;

  const appointments = await Appointment.find({ $or: [{ patient_id: userId }, { doctor_id: userId }] });

  res.status(201).json(appointments);
});

module.exports = {
  addAvailableIndividualDate,
  addAvailableRepeatedDate,
  updateIndiviualDate,
  updateRepeatedDate,
  deleteAvailableDate,
  clearIndividualDates,
  clearRepeatedDates,
  getAvailableDates,
  bookAppointment,
  deleteBookedAppointment,
  changeBookedStatus,
  getAllBookedAppointments,
};
