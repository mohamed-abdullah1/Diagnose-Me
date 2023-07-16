const mongoose = require('mongoose');

const BookingsSchema = mongoose.Schema({
  _id: String,
  date: Date,
  amount: Number,
  description: String,
  transType: String,
});

const Bookings = mongoose.model('Bookings', BookingsSchema);
module.exports = Bookings;
