const mongoose = require('mongoose');
const { v4: uuidv4 } = require('uuid');
const Appointment = require('./calendarModel');

const userSchema = mongoose.Schema(
  {
    _id: { type: String, default: uuidv4 },
    name: { type: 'String', required: [true, 'Enter the Name feild 🔑'] },
    pic: {
      type: 'String',
      required: true,
      default: 'https://icon-library.com/images/anonymous-avatar-icon/anonymous-avatar-icon-25.jpg',
    },
    IsDoctor: { type: Boolean, default: false },
    Role: {
      type: String,
      enum: {
        values: ['Doctor', 'Patient', 'Admin'],
        message: 'Please select a valid Role.',
      },
    },

    // isAdmin: {
    //   type: Boolean,
    //   required: true,
    //   default: false,
    // },
    // email: {
    //   type: 'String',
    //   unique: false, // unique option is not a validator so there is no validation message
    //   required: [true, 'Enter the Email feild 🔑'],
    // },
    // password: { type: 'String', required: [true, 'Enter the Password feild 🔑'] },
  },
  { timestamps: true }
);

// userSchema.methods.matchPassword = async function (enteredPassword) {
//   return await bcrypt.compare(enteredPassword, this.password);
// };

// userSchema.pre('save', async function (next) {
//   if (!this.isModified) {
//     next();
//   }

//   const salt = await bcrypt.genSalt(10);
//   this.password = await bcrypt.hash(this.password, salt);
//   // console.log('the password encrypted by bcrypt: ', this.password);
//   // console.log(
//   //   'the password encrypted by crypto SHA256: ',
//   //   crypto.createHmac('sha256', process.env.JWT_SECRET).update(this.password).digest('hex')
//   // );
// });

const User = mongoose.model('User', userSchema);

module.exports = User;
