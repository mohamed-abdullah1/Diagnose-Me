const asyncHandler = require('express-async-handler');
const User = require('../models/userModel');
const generateToken = require('../config/generateToken');
const { v4: uuidv4 } = require('uuid');

//@description     Get or Search all users
//@route           GET /api/user?search=
//@access          Public
const allUsers = asyncHandler(async (req, res) => {
  const keyword = req.query.search ? { name: { $regex: req.query.search, $options: 'i' } } : {};

  const users = await User.find(keyword).find({ _id: { $ne: req.user?._id } }); // the optional chaningin here if there is no users exists
  res.send(users);
});

//@description     Register new user
//@route           POST /api/user/
//@access          Public
// const registerUser = asyncHandler(async (req, res) => {
//   const { name, email, password, pic, isDoctor } = req.body;

//   const userExists = await User.findOne({ email }); // we can't use unique option in schema instead as it is not a validator.
//   if (userExists) {
//     res.status(400);
//     throw new Error('this email is already exists 🙄');
//   }

//   const user = await User.create({
//     _id: uuidv4(),
//     name,
//     email,
//     password,
//     pic, // this is undefined if not provided so the default will be set
//     isDoctor, // this is undefined if not provided so the default will be set
//   });

//   if (isDoctor) {
//     await Calendar.create({ _id: uuidv4(), doctorId: user._id });
//   }

//   if (user) {
//     res.status(201).json({
//       _id: user._id,
//       name: user.name,
//       email: user.email,
//       isDoctor: user.isDoctor,
//       pic: user.pic,
//       calendar: user.calendar,
//       token: generateToken(user._id),
//     });
//   } else {
//     res.status(400);
//     throw new Error('User failed to be created 😱');
//   }
// });

//@description     Auth the user
//@route           POST /api/users/login
//@access          Public
// const authUser = asyncHandler(async (req, res) => {
//   const { email, password } = req.body;

//   const user = await User.findOne({ email });
//   if (user && (await user.matchPassword(password))) {
//     res.json({
//       _id: user._id,
//       name: user.name,
//       email: user.email,
//       isDoctor: user.isDoctor,
//       calendar: user.calendar,
//       // pic: user.pic,
//       token: generateToken(user._id),
//     });
//   } else {
//     res.status(401);
//     throw new Error('Invalid Email or Password  😱');
//   }
// });

const deleteAllUsers = asyncHandler(async (req, res) => {
  await User.deleteMany({});
  res.send('All Users Deleted');
});

// const deleteUsers = asyncHandler(async (req, res) => {
//   const usersList = req.body.users;
//   const acknowledgement = await User.deleteMany({ _id: { $in: usersList } });
//   res.send(`${acknowledgement.deletedCount} users is deleted`);
// });

module.exports = { allUsers, deleteAllUsers };
