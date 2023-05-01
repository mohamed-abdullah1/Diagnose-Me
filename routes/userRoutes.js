const express = require('express');
const {
  allUsers,
  registerUser,
  authUser,
  deleteAllUsers,
  deleteUsers,
} = require('../controllers/userControllers');
const { protect } = require('../middleware/authMiddleware');

const router = express.Router();

router.route('/').post(registerUser).get(protect, allUsers);
router.route('/login').post(authUser);
router.route('/delete-all').delete(protect, deleteAllUsers);
router.route('/delete').delete(protect, deleteUsers); // deletes array of users

module.exports = router;
