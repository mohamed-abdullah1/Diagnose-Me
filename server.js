require('dotenv').config();
const express = require('express');
const connectDB = require('./config/db');
const colors = require('colors');
const userRoutes = require('./routes/userRoutes');
const chatRoutes = require('./routes/chatRoutes');
const messageRoutes = require('./routes/messageRoutes');
const bookingRoutes = require('./routes/bookingRoutes');
const appointmentRoutes = require('./routes/appointmentRoutes');
const MyControllers = require('./controllers/Consumer');
const User = require('./models/userModel');

connectDB();
const app = express();

app.use(express.static('public'));
app.use(express.json()); //   to accept JSON data from frontend

// Middlewares
app.use('/api/user', userRoutes);
app.use('/api/chat', chatRoutes);
app.use('/api/message', messageRoutes);
app.use('/api/booking', bookingRoutes);
app.use('/api/appointment', appointmentRoutes);

const seedings = [
  { _id: '00edafe3-b047-5980-d0fa-da10f400c1e5', name: 'Admin' },
  { _id: '657cb6cb-abf2-00d1-5d46-939a7b3aff5f', name: 'Doctor' },
  { _id: '972a1201-a9dc-2127-0827-560cb7d76af8', name: 'Patient' },
];

User.create({ _id: '657cb6cb-abf2-00d1-5d46-939a7b3aff5f', name: 'Doctor' })
  .then((createdDocuments) => {
    console.log('created Docs:🧓👉👉', createdDocuments);
  })
  .catch((err) => console.log(err));

MyControllers.startConsumingMessages();

const PORT = process.env.PORT || 6969;
const server = app.listen(PORT, console.log(`server is listening on port ${PORT}...`.yellow.bold));

// app.use(notFound);
// app.use(errorHandler);

const io = require('socket.io')(server, {
  pingTimeout: 60000,
  cors: {
    origin: 'http://localhost:3000',
    // credentials: true,
  },
});

io.on('connection', (socket) => {
  console.log('Connected to socket.io SOCKET ID :: ', socket.id);
  // socket.on("setup", (userData) => {
  //     console.log("👉", userData._id);
  //     socket.join(userData._id); //socket.join(room): adds the client socket to the specified room.
  //     socket.emit("connected");
  // });

  //at creating a new chat or access it
  //////////////////////
  socket.on('join chat', (room) => {
    socket.join(room);
    console.log('User Joined Room: CHAT_ID: ' + room);
  });

  socket.on('typing', (room) => {
    console.log('👉', 'typing: ', room);
    socket.to(room).emit('typing');
  });
  socket.on('stop typing', (room) => {
    console.log('👉', 'stop typing: ', room);
    socket.to(room).emit('stop typing');
  });

  socket.on('new message', (room) => {
    console.log('👉', 'user send a message !!!', room);
    socket.to(room).emit('message received');
  });

  socket.on('message readed', (room) => {
    console.log('👉', 'user read the latest message !!!', room);
    socket.to(room).emit('message readed');
  });

  socket.on('disconnect', () => {
    console.log('USER DISCONNECTED', socket.id);
  });
});
