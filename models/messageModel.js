const mongoose = require('mongoose');
const { v4: uuidv4 } = require('uuid');

const messageSchema = mongoose.Schema(
  {
    _id: { type: String, default: uuidv4 },
    sender: { type: String, default: uuidv4, ref: 'User' },
    content: { type: String, trim: true },
    chat: { type: String, default: uuidv4, ref: 'Chat' },
    readBy: [{ type: String, default: uuidv4, ref: 'User' }],
  },
  { timestamps: true }
);

const Message = mongoose.model('Message', messageSchema);
module.exports = Message;
