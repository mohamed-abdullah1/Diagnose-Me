const router = require('express').Router();

const { protect } = require('../middleware/authMiddleware');
const {
  addAvailableTime,
  deleteAvailableTime,
  clearAvailableTimes,
  bookAppointment,
  deleteBookedAppointment,
  changeBookedStatus,
  getAllBookedAppointments,
  getAvailableTimes,
} = require('../controllers/appointmentControllers');

router.route('/add-available-time/').patch(protect, addAvailableTime);
router.route('/delete-available-time/').patch(protect, deleteAvailableTime);
router.route('/clear-available-times/').delete(protect, clearAvailableTimes);
router.route('/get-available-times/:doctorId').get(protect, getAvailableTimes);

router.route('/book-appointment').post(protect, bookAppointment);
router.route('/delete-booked-appointment/:appointmentId').delete(protect, deleteBookedAppointment);
router.route('/change-booked-status/:appointmentId').patch(protect, changeBookedStatus);
router.route('/get-all-booked-appointments/').get(protect, getAllBookedAppointments);

module.exports = router;

// router.route('/add-available-repeated-date/').patch(protect, addAvailableRepeatedDate);
// router.route('/update-available-repeated-date/:dateId').patch(protect, updateRepeatedDate);
// router.route('/clear-repeated-dates/').patch(protect, clearRepeatedDates);
// router.route('/update-available-individual-date/:dateId').patch(protect, updateIndiviualDate);
