const mongoose = require('mongoose');
const { v4: uuidv4 } = require('uuid');

const messageSchema = mongoose.Schema(
  {
    _id: { type: String, default: uuidv4 },
    sender: { type: String, default: uuidv4, ref: 'User' },
    // readBy: [{ type: String, default: uuidv4, ref: 'User' }], // readBy
    content: { type: String, trim: true, required: [true, 'you have to provide content for the message 😶'] },
    chat: { type: String, required: [true, 'you have to provide chat ID 😶'], ref: 'Chat' },
    isRead: { type: Boolean, default: false },
  },
  { timestamps: true }
);

const Message = mongoose.model('Message', messageSchema);
module.exports = Message;
