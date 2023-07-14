const mongoose = require('mongoose');

const AppointmentSchema = mongoose.Schema(
  {
    _id: String,
    day: { type: Date, required: [true, 'you have to provide day of the appointment🙃'] },
    startTime: { type: Date, required: [true, 'you have to provide start Time to the appointment🙃'] },
    graceTime: { type: Date, required: [true, 'the developler have to provide grace Time'] },

    patientId: { type: String, required: [true, '🙃 where is the patient ID 😑'], ref: 'User' },
    doctorId: { type: String, required: [true, '🙃 where is the doctor ID 😑'], ref: 'User' },

    status: {
      type: String,
      default: 'waiting',
      enum: {
        values: ['waiting', 'approved', 'canceled'], // pending - confirmed - canceled
        message: '🙃🙃{VALUE} is not a vaild status 😫😕',
      },
    },

    price: { type: Number, default: 0 },
    note: { type: String, default: '' },
  },
  { timestamps: true }
);

const Appointment = mongoose.model('Appointment', AppointmentSchema);
module.exports = Appointment;
