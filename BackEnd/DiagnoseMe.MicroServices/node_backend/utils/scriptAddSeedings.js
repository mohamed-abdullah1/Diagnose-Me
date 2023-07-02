const Calendar = require('../models/calendarModel');
const User = require('../models/userModel');
const { v4: uuidv4 } = require('uuid');

const seedings = [
  { _id: '00edafe3-b047-5980-d0fa-da10f400c1e5', name: 'Admin', IsDoctor: false, Role: 'Admin' },
  {
    _id: '657cb6cb-abf2-00d1-5d46-939a7b3aff5f',
    name: 'Doctor',
    IsDoctor: true,
    Role: 'Doctor',
  },
  { _id: '972a1201-a9dc-2127-0827-560cb7d76af8', name: 'Patient', IsDoctor: false, Role: 'Patient' },
  { _id: 'e4196c3d-5b37-400a-be46-3cb239cfbcb9', name: 'mox', IsDoctor: false, Role: 'Patient' },
];

const checkAndAdd = () => {
  seedings.forEach(async (user) => {
    try {
      const foundUser = await User.findById(user._id);
      if (!foundUser) {
        const createdUser = await User.create(user);

        if (user.IsDoctor) {
          await Calendar.create({ _id: uuidv4(), doctorId: user._id });
        }
        console.log(createdUser, '\n👈👉\n');
      }
    } catch (error) {
      console.log('error in creating seedings👉', error);
    }
  });
};

module.exports = checkAndAdd;
