const asyncHandler = require('express-async-handler');
const Chat = require('../models/chatModel');
const User = require('../models/userModel');

const { v4: uuidv4 } = require('uuid');

//@description     Create or fetch single Chat
//@route           POST /api/chat/
const accessChat = asyncHandler(async (req, res) => {
  // if (!secondUserId) {
  //   console.log('UserId param not sent with request');
  //   return res.sendStatus(400);
  // }
  const { id: secondUserId } = req.params;

  var isChat = await Chat.find({
    $and: [
      { users: { $elemMatch: { $eq: req.user._id } } },
      { users: { $elemMatch: { $eq: secondUserId } } },
    ],
  })
    .select('-__v')
    .populate('users', '-password')
    .populate('latestMessage');

  isChat = await User.populate(isChat, {
    path: 'latestMessage.sender',
    select: 'name pic',
  });

  if (isChat.length > 0) {
    res.send(isChat[0]);
  } else {
    var chatData = {
      _id: uuidv4(),
      chatName: 'new chat',
      users: [req.user._id, secondUserId],
    };

    // create the chat
    let createdChat = await Chat.create(chatData);
    createdChat = await Chat.findById(createdChat._id) // this part for populating the users in chat created
      .select('-__v')
      .populate('users', '-password')
      .populate('latestMessage');
    console.log('😀created');

    // const FullChat = await Chat.findOne({ _id: createdChat._id }).populate('users', '-password');
    res.status(200).json(createdChat);
  }
});

//@description     Fetch all chats for authenticated user
//@route           GET /api/chat/
const fetchAllChats = asyncHandler(async (req, res) => {
  try {
    Chat.find({ users: { $elemMatch: { $eq: req.user._id } } }) // find all chats that my id exist in it.
      .select('-__v -updatedAt')
      .populate('users', '-password -__v -updatedAt')
      .populate('latestMessage', '-__v -updatedAt')
      .sort({ updatedAt: -1 })
      .then(async (results) => {
        results = await User.populate(results, {
          path: 'latestMessage.sender',
          select: 'name pic',
        });
        res.status(200).send(results);
      });
  } catch (error) {
    res.status(400);
    throw new Error(error.message);
  }
});

//
//@description      Delete Single Chat (Remove the user id from the users list in Chat document)
//@route            DELETE  /delete-chat/
const deleteChat = asyncHandler(async (req, res) => {
  const { chatId, customUserId } = req.body;

  const userId = customUserId || req.user._id; //the registered user or the provided user id

  const updatedChat = await Chat.findByIdAndUpdate(
    chatId,
    { $pull: { users: { $eq: userId } } }, // can be used  witout $eq operator
    { new: true, projection: { users: 1 } }
  );

  // check if the updatedChat != null, if the the chat is not exist
  if (updatedChat) {
    if (updatedChat.users.length == 0) {
      const deletedChat = await Chat.findByIdAndDelete(chatId);
      res.status(200).send('The Entire Chat document is removed:', deletedChat);
    }
    res.status(200).send('The user is removed from the Chat');
  } else {
    res.status(200).send('The Chat is not exist🙄');
  }
});

//@description      Delete Single Chat completely
//@route            DELETE  /admin-delete-chat/
const adminDeleteChat = asyncHandler(async (req, res) => {
  const { chatId } = req.body;
  try {
    const deletedChat = await Chat.findByIdAndDelete(chatId);
    if (deletedChat) {
      res.status(200).json(deletedChat);
    } else {
      console.log('😑', deletedChat);
      res.status(200).json('chat is aleady not exist🙄');
    }
  } catch (error) {
    res.status(400);
    throw new Error(error.message);
  }
});

//

module.exports = {
  accessChat,
  fetchAllChats,
  deleteChat,
  adminDeleteChat,
};
