const asyncHandler = require('express-async-handler');
const { AppError } = require('../middleware/errorMiddleware');
const Notification = require('../models/notificationModel');
const { v4: uuidv4 } = require('uuid');
const notify = require('../utils/notify');
const User = require('../models/userModel');

const getUserNotifications = asyncHandler(async (req, res, next) => {
  const userId = req.user._id;
  const notifications = await Notification.find({ RecipientId: userId }).sort({ createdAt: 1 });
  // .populate('sender', 'name pic');
  res.status(200).json(notifications);
});

//

const getUserNotificationsAdmin = asyncHandler(async (req, res, next) => {
  if (!req.user.Role.includes('Admin')) {
    next(new AppError('Your are not Authorized, only Admin can access😉'));
  }

  const userId = req.params.id;
  if (!userId) {
    next(new AppError('you have to provide targeted user ID...🤷‍♂️', 500));
  }

  const notificationsList = await Notification.find({ RecipientId: userId }).sort('-createdAt');
  res.status(200).json(notificationsList);
});

//

// get all notifications grouped by user id
const getAllNotificationsAdmin = asyncHandler(async (req, res, next) => {
  if (!req.user.Role.includes('Admin')) {
    next(new AppError('Your are not Authorized, only Admin can access😉', 403));
  }

  const allNotifications = await Notification.aggregate([
    {
      $group: {
        _id: '$RecipientId',
        count: { $sum: 1 },
        notifications: { $push: { Title: '$Title', Message: '$Message', IsRead: '$IsRead' } },
      },
    },
  ]);
  res.status(200).json(allNotifications);
});

//

// Create Notification
const addUserNotification = asyncHandler(async (req, res, next) => {
  const { Message, RecipientId, Title } = req.body;
  if (!Message || !RecipientId) {
    next(new AppError('Notificatioin Message or RecipientId is Missed😕', 400));
  }
  const notificationAdded = await Notification.create({
    _id: uuidv4(),
    Title,
    Message,
    RecipientId,
    SenderId: req.user._id,
  });
  res.status(200).json({ status: 'sucess', notificationAdded });
});

//
const updateToken = asyncHandler(async (req, res, next) => {
  const { id, token } = req.body;

  if (!id) {
    next(new AppError('you have to provide user id', 400));
  }
  if (!token) {
    next(new AppError('you have to provide user token', 400));
  }

  const updatedUser = await User.findOneAndUpdate(
    { _id: id },
    { $set: { deviceToken: token } },
    { new: true }
  );

  res.status(200).json(updatedUser);
});

const sendNotification = asyncHandler(async (req, res, next) => {
  const { title, body, id } = req.body;

  // const tokensList = [
  //   'ExponentPushToken[ScAanXJN91RWbTTl7g9rh2]',
  //   'ExponentPushToken[UBN3nsJz0_QBoFjoxqCoyR]',
  // ];

  const fetchedUser = await User.findOne({ _id: id });
  const tokensList = [fetchedUser.deviceToken];

  let payload = {
    title,
    body,
    data: { time: new Date() },
  };
  notify(tokensList, payload, next);
  res.status(200).json({ message: 'notifications are sent succesfully' });
});

//

module.exports = {
  addUserNotification,
  getAllNotificationsAdmin,
  getUserNotifications,
  getUserNotificationsAdmin,
  sendNotification,
  updateToken,
};
