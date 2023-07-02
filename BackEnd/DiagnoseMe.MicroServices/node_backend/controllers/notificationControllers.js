const asyncHandler = require('express-async-handler');
const { AppError } = require('../middleware/errorMiddleware');
const Notification = require('../models/notificationModel');
const { v4: uuidv4 } = require('uuid');

const getUserNotifications = asyncHandler(async (req, res, next) => {
  const userId = req.user._id;
  const notifications = await Notification.find({ RecipientId: userId });
  // .populate('sender', 'name pic');
  res.status(200).json(notifications);
});

const getUserNotificationsAdmin = asyncHandler(async (req, res, next) => {
  if (req.user.Role != 'Admin') {
    next(new AppError('Your are not Authorized, only Admin can access😉'));
  }

  const userId = req.params.id;
  if (!userId) {
    next(new AppError('you have to provide targeted user ID...🤷‍♂️'), 500);
  }

  const notificationsList = await Notification.find({ RecipientId: userId }).sort('-createdAt');
  res.status(200).json(notificationsList);
});

// get all notifications grouped by user id
const getAllNotificationsAdmin = asyncHandler(async (req, res, next) => {
  if (req.user.Role != 'Admin') {
    next(new AppError('Your are not Authorized, only Admin can access😉'));
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

// Create Notification
const addUserNotification = asyncHandler(async (req, res, next) => {
  const { Message, RecipientId, Title } = req.body;
  if (!Message || !RecipientId) {
    next(new AppError('Notificatioin Message or RecipientId is Missed😕', 500));
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

module.exports = {
  addUserNotification,
  getAllNotificationsAdmin,
  getUserNotifications,
  getUserNotificationsAdmin,
};
