const mongoose = require('mongoose');
const { v4: uuidv4 } = require('uuid');

const chatModel = mongoose.Schema(
  {
    _id: { type: String },
    chatName: { type: String, trim: true },
    latestMessage: {
      type: String,
      ref: 'Message',
    },
    unReadMsgCount: { type: Number, default: 0 },
    users: [{ type: String, ref: 'User' }],
    // isGroupChat: { type: Boolean, default: false },
    // groupAdmin: { type: String, ref: 'User' },
  },
  { timestamps: true }
);

const Chat = mongoose.model('Chat', chatModel);

module.exports = Chat;
