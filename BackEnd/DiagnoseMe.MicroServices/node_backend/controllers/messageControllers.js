const asyncHandler = require('express-async-handler');
const Message = require('../models/messageModel');
const Chat = require('../models/chatModel');
const { v4: uuidv4 } = require('uuid');
const { AppError } = require('../middleware/errorMiddleware');

//@description     Get all Messages
//@route           GET /api/Message/:chatId
const allMessages = asyncHandler(async (req, res, next) => {
  const messages = await Message.find({ chat: req.params.chatId }).sort('createdAt');
  // .populate('sender', 'name pic ')
  // .populate('chat');
  if (!messages) {
    return next(new AppError('the provided chat id is not valid', 400));
  }
  res.json(messages);
});

//@description     Delete ALL Messages
//@route           POST /api/Message/:chatId
const deleteAllMessages = asyncHandler(async (req, res) => {
  const { chatId } = req.params;
  const acknowledgement = await Message.deleteMany({ chat: chatId });
  res.status(200).send(acknowledgement);
});

//@description     Delete single Message
//@route           POST /api/Message/delete-message/:msgId
const deleteMessage = asyncHandler(async (req, res) => {
  const { msgId } = req.params;
  const deletedMsg = await Message.findByIdAndDelete(msgId);
  res.json({ deletedMsg });
});

//@description     Create New Message
//@route           POST /api/Message/
const sendMessage = asyncHandler(async (req, res) => {
  const { content, chatId, isRead } = req.body;

  // if (!content || !chatId) {
  //   // replaced in schema schema validation
  //   console.log('Invalid data passed into request🙄');
  //   return res.sendStatus(400);
  // }
  let newMessage = {
    _id: uuidv4(),
    sender: req.user._id,
    chat: chatId,
    content,
    isRead,
  };

  let message = await Message.create(newMessage);
  message = await message.populate('sender', 'Name pic');

  const counter = isRead ? 0 : 1;
  const chatUpdated = await Chat.findByIdAndUpdate(
    req.body.chatId,
    { latestMessage: message, $inc: { unReadMsgCount: counter } },
    { runValidators: true, new: true }
  );
  // message = await message.populate('chat');
  // message = await User.populate(message, {
  //   path: 'chat.users',
  //   select: 'name pic',
  // });

  res.json(message);
});

//@description     Edit isRead field in Message
//@route           POST /api/Message/set-read/:msgId

const setMessageRead = asyncHandler(async (req, res, next) => {
  const msgId = req.params.msgId;
  const editedMsg = await Message.findByIdAndUpdate(msgId, { $set: { isRead: true } }, { new: true });
  if (!editMessage) {
    return next(new AppError('There is no message matches provided id', 400));
  }
  res.json(editedMsg);
});

//@description     Edit isRead field for all un-read Messages in a chat
//@route           POST /api/Message/set-all-read/
const setAllMessagesRead = asyncHandler(async (req, res) => {
  const { chatId } = req.body;
  if (!chatId) {
    res.status(400).json('shit where is the chat id 😑');
  }
  const result = await Message.updateMany({ chat: chatId, isRead: false }, { isRead: true });
  await Chat.findByIdAndUpdate(chatId, { unReadMsgCount: 0 }, { new: true });
  res.status(200).json(result);
});

//@description     edit Message
//@route           POST /api/Message/editmessage/:msgId
const editMessage = asyncHandler(async (req, res) => {
  const { msgId } = req.params;
  const msgContent = req.body.content;

  const editedMsg = await Message.findByIdAndUpdate(msgId, { content: msgContent }, { new: true });
  res.json(editedMsg);
});

module.exports = {
  allMessages,
  deleteAllMessages,
  sendMessage,
  editMessage,
  setMessageRead,
  setAllMessagesRead,
  deleteMessage,
};
