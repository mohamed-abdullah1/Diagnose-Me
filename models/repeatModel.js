const mongoose = require('mongoose');

const recurringEventsSchema = mongoose.Schema(
  {
    _id: String,
    doctor_id: { type: String, ref: 'User' },
    start_date: Date,
    end_date: Date,
    frequency: String, // "daily" or "weekly"
    recurring_days: [String], // for weekly events only, e.g. ["Monday", "Wednesday", "Friday"]
  },
  { timestamps: true }
);

const RecuringEvnet = mongoose.model('recurringevent', recurringEventsSchema);

module.exports = RecuringEvnet;
