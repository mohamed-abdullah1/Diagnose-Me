const amqp = require('amqplib');
const User = require('../models/userModel');
const Calendar = require('../models/calendarModel');

// Define the RabbitMQ connection URL
const connectionURL = 'amqp://localhost:5672';

// Function to consume messages from the queue
async function consumeMessages(queueName, handlerFunc) {
  try {
    // Connect to RabbitMQ server
    const connection = await amqp.connect(connectionURL);
    const channel = await connection.createChannel();

    // Create the queue if it doesn't already exist
    await channel.assertQueue(queueName);

    console.log('Waiting for messages...');

    // Consume messages from the queue
    channel.consume(queueName, (message) => {
      let messages_sent = message.content.toString();
      console.log('👉', messages_sent, '👈');
      handlerFunc(messages_sent);

      // Acknowledge the message
      channel.ack(message);
    });

    // Close the connection
    // Note: This will not execute until the consumer is cancelled by press Ctrl+C in the terminal
    process.once('SIGINT', () => {
      channel.close();
      connection.close();
    });
  } catch (error) {
    console.error('Error occurred while consuming messages:', error);
  }
}

const MyControllers = {
  async startConsumingMessages() {
    const handlerCreateUser = async (msg) => {
      // console.log(`Received message: ${JSON.stringify(message)}`);
      // console.log(message);
      // Handle incoming message
      try {
        const user = await User.create({
          _id: msg.Id,
          name: msg.Name,
          pic: msg.pic,
          IsDoctor: msg.IsDoctor,
          Role: msg.Role,
        });

        if (msg.IsDoctor) {
          await Calendar.create({ _id: uuidv4(), doctorId: user._id });
        }
      } catch (err) {
        console.log(err);
      }
    };

    const handlerUpdateUser = async (msg) => {
      // DO WE NEED CHECK FOR AUTH BEFORE ALLOW UPDATE USER ????
      const userId = msg.Id;
      const { Name, ProfilePictureUrl, IsDoctor, Role } = msg.data;
      const updatedUser = User.findOneAndUpdate(
        { _id: userId },
        { name: Name, pic: ProfilePictureUrl, IsDoctor, Role },
        { runValidators: true }
      );
    };

    const handlerDeleteUser = async (msg) => {
      const usersList = msg.users;
      const acknowledgement = await User.deleteMany({ _id: { $in: usersList } });
    };

    consumeMessages('Auth.User.Add', handlerCreateUser);
    consumeMessages('Auth.User.Update', handlerUpdateUser);
    consumeMessages('Auth.User.Delete', handlerDeleteUser);
  },
};

module.exports = MyControllers;
