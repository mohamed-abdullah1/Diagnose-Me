const router = require('express').Router();
const { accessChat, fetchAllChats, deleteChat, adminDeleteChat } = require('../controllers/chatControllers');
const { protect } = require('../middleware/authMiddleware');

//

router.route('/').get(protect, fetchAllChats); // potect needs req.header.authuerzation = "Bearer jdfjhksgabh" and this header is send in the request from the front end
router.route('/:id').post(protect, accessChat); // create chat between me and another user
router.route('/delete-chat').delete(protect, deleteChat); // Delete my id from users list in a chat
router.route('/admin-delete-chat').delete(protect, adminDeleteChat); // Delete the complete chat document (admin ability)

module.exports = router;
