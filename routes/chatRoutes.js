const router = require('express').Router();
const { accessChat, fetchAllChats, deleteChat, adminDeleteChat } = require('../controllers/chatControllers');
const { protect } = require('../middleware/authMiddleware');

//

router.route('/').post(protect, accessChat).get(protect, fetchAllChats); // potect needs req.header.authuerzation = "Bearer jdfjhksgabh" and this header is send in the request from the front end
router.route('/delete-chat').delete(protect, deleteChat); // Delete my id from users list in a chat
router.route('/admin-delete-chat').delete(protect, adminDeleteChat); // Delete the complete chat document (admin ability)

module.exports = router;

// router.route('/group').post(protect, createGroupChat);
// router.route('/rename').put(protect, renameGroup);
// router.route('/groupremove').put(protect, removeFromGroup);
// router.route('/groupadd').put(protect, addToGroup);
