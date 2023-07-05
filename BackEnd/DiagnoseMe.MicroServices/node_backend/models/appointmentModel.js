const mongoose = require('mongoose');

const AppointmentSchema = mongoose.Schema(
  {
    _id: String,
    start_date: { type: Date, required: [true, 'you have to provide start date to the appointment🙃'] },
    end_date: { type: Date, required: [true, 'you have to provide end date to the appointment🙃'] },
    status: {
      type: String,
      default: 'waiting',
      enum: {
        values: ['waiting', 'approved', 'canceled'],
        message: '🙃🙃{VALUE} is not a vaild status 😫😕',
      },
    },
    patient_id: { type: String, required: [true, '🙃 where is the patient ID 😑'], ref: 'User' },
    doctor_id: { type: String, required: [true, '🙃 wh-ere is the doctor ID 😑'], ref: 'User' },
  },
  { timestamps: true }
);

const Appointment = mongoose.model('Appointment', AppointmentSchema);
module.exports = Appointment;
