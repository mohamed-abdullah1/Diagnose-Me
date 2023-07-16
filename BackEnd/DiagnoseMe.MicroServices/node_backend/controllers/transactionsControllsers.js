const asyncHandler = require('express-async-handler');
const Bookings = require('../models/bookingModel');
const { v4: uuidv4 } = require('uuid');

const getTransactions = asyncHandler(async (req, res, next) => {
  const { page } = req.body;
  const transactions = await Bookings.find()
    .skip(10 * page || 0)
    .select('-__v');
  res.status(200).json(transactions);
});

const addTransactions = asyncHandler(async (req, res, next) => {
  const { amount, date, description, transType } = req.body;
  const createdTransaction = await Bookings.create({
    _id: uuidv4(),
    amount,
    date,
    description,
    transType,
  });
  res.status(200).json(createdTransaction);
});
module.exports = { getTransactions, addTransactions };
