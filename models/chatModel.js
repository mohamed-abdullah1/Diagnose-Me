const mongoose = require('mongoose');
const { v4: uuidv4 } = require('uuid');

const chatModel = mongoose.Schema(
  {
    _id: { type: String, default: uuidv4 },
    chatName: { type: String, trim: true },
    isGroupChat: { type: Boolean, default: false },
    users: [{ type: String, default: uuidv4, ref: 'User' }],
    latestMessage: {
      type: String,
      ref: 'Message',
    },
    groupAdmin: { type: String, default: uuidv4, ref: 'User' },
  },
  { timestamps: true }
);

const Chat = mongoose.model('Chat', chatModel);

module.exports = Chat;
