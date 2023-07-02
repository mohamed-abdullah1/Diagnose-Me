const mongoose = require('mongoose');
const { v4: uuidv4 } = require('uuid');

const calendarSchema = mongoose.Schema(
  {
    _id: String,
    doctorId: { type: String, ref: 'User', required: [true, 'you need to provide the doctor ID 😶'] },
    repeated_dates: [
      {
        start_date: { type: Date, default: new Date() },
        end_date: { type: Date, default: new Date() },
        frequency: { type: String, enum: ['daily', 'weekly'] },
        recurring_days: [{ type: String, enum: ['sat', 'sun', 'mon', 'tue', 'wed', 'thu', 'fri'] }],
        times: [{ start_time: { type: Date }, end_time: { type: Date } }],
      },
    ],
    individual_dates: [
      {
        date: { type: Date, required: [true, 'you have to add date😐'], default: new Date() },
        times: [{ start_time: { type: Date }, end_time: { type: Date } }],
      },
    ],
  },
  { timestamps: true }
);

const Calendar = mongoose.model('Calendar', calendarSchema);
module.exports = Calendar;
