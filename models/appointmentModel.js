const mongoose = require('mongoose');
const { v4: uuidv4 } = require('uuid');

const appointmentSchema = mongoose.Schema({
  _id: {
    type: String,
  },

  date: { day: Date, time: [{ start: Date, end: Date }] },

  appointmentStatus: {
    type: String,
    default: 'available', //available || booked
  },

  bookingStatus: {
    type: String,
    default: 'waiting', //"approved" || "canceled" || "waiting"
  },

  doctorId: { type: String, default: uuidv4, ref: 'User' },

  patientId: {
    type: String,
    default: '',
    ref: 'User',
  },
});

const Appointment = mongoose.model('Appointment', appointmentSchema);
module.exports = Appointment;
