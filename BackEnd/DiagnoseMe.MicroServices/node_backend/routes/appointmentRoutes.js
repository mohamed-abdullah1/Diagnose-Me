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
  getAllBookedAppointmentsAdmin,
  getAvailableTimes,
  getAllBookingsAdmin,
  getBookingStatistics,
} = require('../controllers/appointmentControllers');

router.route('/add-available-time/').post(protect, addAvailableTime);
router.route('/delete-available-time/').post(protect, deleteAvailableTime);
router.route('/clear-available-times/').delete(protect, clearAvailableTimes);
router.route('/get-available-times/:doctorId').get(protect, getAvailableTimes);

router.route('/book-appointment').post(protect, bookAppointment);
router.route('/delete-booked-appointment/:appointmentId').delete(protect, deleteBookedAppointment);
router.route('/change-booked-status/:appointmentId').post(protect, changeBookedStatus);
router.route('/get-all-booked-appointments/').get(protect, getAllBookedAppointments);
router.route('/get-all-bookings-admin/').get(protect, getAllBookedAppointmentsAdmin);
router.get('/get-all-bookings-admin/', protect, getAllBookingsAdmin);
router.get('/booking-statistics', protect, getBookingStatistics);

module.exports = router;

// router.route('/add-available-repeated-date/').post(protect, addAvailableRepeatedDate);
// router.route('/update-available-repeated-date/:dateId').post(protect, updateRepeatedDate);
// router.route('/clear-repeated-dates/').post(protect, clearRepeatedDates);
// router.route('/update-available-individual-date/:dateId').post(protect, updateIndiviualDate);
