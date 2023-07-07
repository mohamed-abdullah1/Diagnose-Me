const mongoose = require('mongoose');
const { v4: uuidv4 } = require('uuid');

const messageSchema = mongoose.Schema(
  {
    _id: { type: String, default: uuidv4 },
    chat: { type: String, required: [true, 'you have to provide chat ID 😶'], ref: 'Chat' },
    sender: { type: String, default: uuidv4, ref: 'User' },
    content: { type: String, trim: true, required: [true, 'you have to provide content for the message 😶'] },
    isRead: { type: Boolean, default: false },
    // readBy: [{ type: String, default: dv4, ref: 'User' }], // readBy
  },
  { timestamps: true }
);

const Message = mongoose.model('Message', messageSchema);
module.exports = Message;
