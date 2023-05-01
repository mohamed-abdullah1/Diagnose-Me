const express = require('express');
const {
  allMessages,
  deleteAllMessages,
  sendMessage,
  setMessageRead,
  editMessage,
  setAllMessagesRead,
  deleteMessage,
} = require('../controllers/messageControllers');
const { protect } = require('../middleware/authMiddleware');

const router = express.Router();

router.route('/').post(protect, sendMessage);
router.route('/:chatId').get(protect, allMessages).delete(protect, deleteAllMessages);
router.route('/delete-message/:msgId').delete(protect, deleteMessage);
router.route('/set-read/:msgId').patch(protect, setMessageRead);
router.route('/edit-message/:msgId').patch(protect, editMessage);
router.route('/set-all-read/').patch(protect, setAllMessagesRead);

module.exports = router;
