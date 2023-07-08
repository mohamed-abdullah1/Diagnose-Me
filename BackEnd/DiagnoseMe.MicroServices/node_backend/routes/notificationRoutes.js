const { Router } = require('express');
const {
  getUserNotifications,
  addUserNotification,
  getAllNotificationsAdmin,
  getUserNotificationsAdmin,
  sendNotification,
} = require('../controllers/notificationControllers');
const { protect } = require('../middleware/authMiddleware');

const router = Router();

router.get('/', protect, getUserNotifications);
router.post('/', protect, addUserNotification);
router.post('/send', protect, sendNotification);
router.get('/all', protect, getAllNotificationsAdmin);
router.get('/:id', protect, getUserNotificationsAdmin);

module.exports = router;
