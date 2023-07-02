const { default: mongoose } = require('mongoose');

const NotificationSchema = mongoose.Schema({
  _id: String,
  Title: String,
  SenderId: { type: String, ref: 'User' },
  RecipientId: { type: String, ref: 'User' },
  IsRead: { type: Boolean, default: false },
  Message: { type: String, default: '' },
});

const Notification = mongoose.model('Notification', NotificationSchema);
module.exports = Notification;
