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
  const { secondUserId } = req.body;

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
    select: 'name pic email',
  });

  if (isChat.length > 0) {
    res.send(isChat[0]);
  } else {
    var chatData = {
      _id: uuidv4(),
      chatName: 'chat',
      users: [req.user._id, secondUserId],
    };

    try {
      let createdChat = await Chat.create(chatData);
      createdChat = await Chat.findById(createdChat._id)
        .select('-__v')
        .populate('users', '-password')
        .populate('latestMessage');
      console.log('😀created');
      // const FullChat = await Chat.findOne({ _id: createdChat._id }).populate('users', '-password');
      res.status(200).json(createdChat);
    } catch (error) {
      res.status(400);
      throw new Error(error.message);
    }
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
          select: 'name pic email',
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
  try {
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
  } catch (error) {
    res.status(400);
    throw new Error(error.message);
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

//@description     Create New Group Chat
// //@route           POST /api/chat/group
//
// const createGroupChat = asyncHandler(async (req, res) => {
//   if (!req.body.users || !req.body.name) {
//     return res.status(400).send({ message: 'Please Fill all the feilds' });
//   }

//   var users = JSON.parse(req.body.users);

//   if (users.length < 2) {
//     return res.status(400).send('More than 2 users are required to form a group chat');
//   }

//   users.push(req.user);

//   const groupChat = await Chat.create({
//     _id: uuidv4(),
//     chatName: req.body.name,
//     users: users,
//     isGroupChat: true,
//     groupAdmin: req.user,
//   });

//   const fullGroupChat = await Chat.findOne({ _id: groupChat._id })
//     .populate('users', '-password')
//     .populate('groupAdmin', '-password');

//   res.status(200).json(fullGroupChat);
// });

// // @desc    Rename Group
// // @route   PUT /api/chat/rename
// // @access  Protected
// const renameGroup = asyncHandler(async (req, res) => {
//   const { chatId, chatName } = req.body;

//   const updatedChat = await Chat.findByIdAndUpdate(
//     chatId,
//     {
//       chatName: chatName,
//     },
//     {
//       new: true,
//     }
//   )
//     .populate('users', '-password')
//     .populate('groupAdmin', '-password');

//   if (!updatedChat) {
//     res.status(404);
//     throw new Error('Chat Not Found');
//   } else {
//     res.json(updatedChat);
//   }
// });

// // @desc    Remove user from Group
// // @route   PUT /api/chat/groupremove
// // @access  Protected
// const removeFromGroup = asyncHandler(async (req, res) => {
//   const { chatId, userId } = req.body;

//   // check if the requester is admin

//   const removed = await Chat.findByIdAndUpdate(
//     chatId,
//     {
//       $pull: { users: userId },
//     },
//     {
//       new: true,
//     }
//   )
//     .populate('users', '-password')
//     .populate('groupAdmin', '-password');

//   if (!removed) {
//     res.status(404);
//     throw new Error('Chat Not Found');
//   } else {
//     res.json(removed);
//   }
// });

// // @desc    Add user to Group / Leave
// // @route   PUT /api/chat/groupadd
// // @access  Protected
// const addToGroup = asyncHandler(async (req, res) => {
//   const { chatId, userId } = req.body;

//   // check if the requester is admin

//   const added = await Chat.findByIdAndUpdate(
//     chatId,
//     {
//       $push: { users: userId },
//     },
//     {
//       new: true,
//     }
//   )
//     .populate('users', '-password')
//     .populate('groupAdmin', '-password');

//   if (!added) {
//     res.status(404);
//     throw new Error('Chat Not Found');
//   } else {
//     res.json(added);
//   }
// });
