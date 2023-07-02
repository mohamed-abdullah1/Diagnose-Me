const express = require('express');
const { allUsers, deleteAllUsers, deleteUsers } = require('../controllers/userControllers');
const { protect } = require('../middleware/authMiddleware');

const router = express.Router();

router.route('/').get(protect, allUsers);
router.route('/delete-all').delete(protect, deleteAllUsers);

module.exports = router;
