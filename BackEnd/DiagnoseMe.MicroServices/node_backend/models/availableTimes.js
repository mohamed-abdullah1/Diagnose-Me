const mongoose = require('mongoose');

const AvailableTimesSchema = mongoose.Schema(
  {
    _id: String,
    day: { type: Date, required: [true, 'you need to provide a day 😶'] },
    times: [
      {
        startTime: Date,
        graceTime: Date,
      },
    ],
    doctorId: { type: String, ref: 'User', required: [true, 'you need to provide the doctor ID 😶'] },
  },
  { timestamps: true }
);

const AvailableTimes = mongoose.model('Available Dates', AvailableTimesSchema);
module.exports = AvailableTimes;

// repeated_dates: [
//   {
//     start_date: { type: Date, default: new Date() },
//     end_date: { type: Date, default: new Date() },
//     frequency: { type: String, enum: ['daily', 'weekly'] },
//     recurring_days: [{ type: String, enum: ['sat', 'sun', 'mon', 'tue', 'wed', 'thu', 'fri'] }],
//     times: [{ start_time: { type: Date }, end_time: { type: Date } }],
//   },
// ],
