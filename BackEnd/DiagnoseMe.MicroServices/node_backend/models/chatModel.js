const mongoose = require('mongoose');

const chatModel = mongoose.Schema(
  {
    _id: { type: String },
    latestMessage: {
      type: String,
      ref: 'Message',
    },
    unReadMsgCount: { type: Number, default: 0 },
    users: [{ type: String, ref: 'User' }],
  },
  { timestamps: true }
);

const Chat = mongoose.model('Chat', chatModel);

module.exports = Chat;
