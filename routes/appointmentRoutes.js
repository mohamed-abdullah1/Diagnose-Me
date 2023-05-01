const router = require('express').Router();

const { protect } = require('../middleware/authMiddleware');
const {
  addAvailableIndividualDate,
  addAvailableRepeatedDate,
  deleteAvailableDate,
  clearIndividualDates,
  clearRepeatedDates,
  bookAppointment,
  deleteBookedAppointment,
  changeBookedStatus,
  getAllBookedAppointments,
  getAvailableDates,
  updateIndiviualDate,
  updateRepeatedDate,
} = require('../controllers/appointmentControllers');

router.route('/add-available-individual-date/').patch(protect, addAvailableIndividualDate);
router.route('/add-available-repeated-date/').patch(protect, addAvailableRepeatedDate);
router.route('/update-available-individual-date/:dateId').patch(protect, updateIndiviualDate);
router.route('/update-available-repeated-date/:dateId').patch(protect, updateRepeatedDate);
router.route('/delete-available-date/').patch(protect, deleteAvailableDate);
router.route('/clear-individual-dates/').patch(protect, clearIndividualDates);
router.route('/clear-repeated-dates/').patch(protect, clearRepeatedDates);
router.route('/get-available-dates/').get(protect, getAvailableDates);

router.route('/book-appointment').post(protect, bookAppointment);
router.route('/delete-booked-appointment/').delete(protect, deleteBookedAppointment);
router.route('/change-booked-status/:bookedId').patch(protect, changeBookedStatus);
router.route('/get-all-booked-appointments/').get(protect, getAllBookedAppointments);

module.exports = router;
