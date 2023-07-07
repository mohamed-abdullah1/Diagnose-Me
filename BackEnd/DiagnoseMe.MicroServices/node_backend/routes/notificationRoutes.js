const { Router } = require('express');
const {
  getUserNotifications,
  addUserNotification,
  getAllNotificationsAdmin,
  getUserNotificationsAdmin,
} = require('../controllers/notificationControllers');
const { protect } = require('../middleware/authMiddleware');

const router = Router();

router.get('/', protect, getUserNotifications);
router.get('/all', protect, getAllNotificationsAdmin);
router.get('/:id', protect, getUserNotificationsAdmin);

router.post('/', protect, addUserNotification);

module.exports = router;
