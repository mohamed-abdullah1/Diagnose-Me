const mongoose = require('mongoose');
const { v4: uuidv4 } = require('uuid');

const availableAppointmentSchema = mongoose.Schema(
  {
    _id: { type: String },
    doctor_id: { type: String, ref: 'User' },
    date: { type: String, required: true, default: new Date() },
    times: [{ start: Date, end: Date }],
  },
  { timestamps: true }
);

const Appointment = mongoose.model('Appointment', availableAppointmentSchema);
module.exports = Appointment;
