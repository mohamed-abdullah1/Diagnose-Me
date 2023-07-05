const { protect } = require('../middleware/authMiddleware');
const { checkout } = require('../controllers/bookingControllers');
const router = require('express').Router();

//

router.route('/payment').post(protect, checkout);

module.exports = router;
