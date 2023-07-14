const mongoose = require('mongoose');
const { v4: uuidv4 } = require('uuid');

const userSchema = mongoose.Schema(
  {
    _id: { type: String, default: uuidv4 },
    name: { type: 'String', required: [true, 'Enter the Name feild 🔑'] },
    pic: {
      type: 'String',
      default: 'https://icon-library.com/images/anonymous-avatar-icon/anonymous-avatar-icon-25.jpg',
    },
    IsDoctor: { type: Boolean, default: false },
    specialization: String,
    Rating: Number,
    numOfPatients: { type: Number, default: 0 },
    deviceToken: { type: String, default: '' },
  },
  { timestamps: true }
);

const User = mongoose.model('User', userSchema);

module.exports = User;
