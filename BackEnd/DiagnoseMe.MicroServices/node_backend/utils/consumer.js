const amqp = require('amqplib');
const User = require('../models/userModel');
const Calendar = require('../models/calendarModel');
const colors = require('colors');
const Notification = require('../models/notificationModel');
const { v4: uuidv4 } = require('uuid');

// 127.0.0.1   rabbitmq.diagnose.me             C:\Windows\System32\drivers\etc\hosts
// https://chat.openai.com/share/09a0aa74-3838-48a7-b8ad-f3cd6f03a2ac

// Function to consume messages from the queue
async function consumeMessages(queueName, handlerFunc) {
  try {
    const hostname = 'localhost'; // Replace with your RabbitMQ server hostname
    const port = 5672; // Replace with your RabbitMQ server port
    const username = 'DiagnoseMe'; // Replace with your RabbitMQ server username
    const password = 'DiagnoseMe'; // Replace with your RabbitMQ server password

    const connectionUrl = `amqp://DiagnoseMe:DiagnoseMe@rabbitmq.diagnose.me:5672`;

    // Connect to RabbitMQ server
    const connection = await amqp.connect(connectionUrl);
    const channel = await connection.createChannel();

    // Create the queue if it doesn't already exist
    await channel.assertQueue(queueName, { durable: true });

    console.log('Waiting for messages...'.magenta);

    // Consume messages from the queue
    channel.consume(queueName, (message) => {
      let messages_sent = JSON.parse(message.content.toString());
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
      // Handle incoming message
      try {
        const user = await User.create({
          _id: msg.Id,
          name: msg.Name,
          pic: msg.ProfilePictureUrl,
          IsDoctor: msg.IsDoctor,
        });

        if (msg.IsDoctor) {
          const newCalendar = await Calendar.create({ _id: uuidv4(), doctorId: user._id });
          console.log('A new calender created:✅', newCalendar);
        }

        if (user) {
          console.log('A new user created:✅', user);
        }
      } catch (err) {
        console.log('Error During Creating User:❌', err);
      }
    };

    const handlerUpdateUser = async (msg) => {
      const { Id, Name, ProfilePictureUrl, IsDoctor } = msg;
      try {
        const updatedUser = await User.findOneAndUpdate(
          { _id: Id },
          { name: Name, pic: ProfilePictureUrl, IsDoctor },
          { runValidators: true, new: true }
        );
        console.log('The user is updated:✅', updatedUser);
      } catch (error) {
        console.log('Error During Updating User:❌', error);
      }
    };

    const handlerDeleteUser = async (msg) => {
      try {
        console.log('message sent to delete👉', msg);
        const deletedUser = await User.findByIdAndDelete(msg);
        console.log('The user is Deleted successfuly:✅', deletedUser);
      } catch (error) {
        console.log('Error During Deleting User:❌', error);
      }
    };

    const handleAddNotificatioin = async (msg) => {
      // const { Message, RecipientId, SenderId, Title } = msg;
      try {
        const notificationAdded = await Notification.create({ _id: uuidv4(), ...msg });
        console.log('Notification Created: 👉', notificationAdded);
      } catch (error) {
        console.log('Error During Creating Notification:❌', error);
      }
    };

    const hadnleUpdateDoctor = async (msg) => {
      try {
        const { Id, Specialization, Rating } = msg;
        const updatedUser = await User.findOneAndUpdate(
          { _id: Id },
          { Specialization, Rating },
          { runValidators: true, new: true }
        );
        console.log('The user is updated successfuly:✅', updatedUser);
      } catch (error) {
        console.log('Error During Updating Doctor:❌', error);
      }
    };

    consumeMessages('Auth.Chat.User.Add', handlerCreateUser);
    consumeMessages('Auth.Chat.User.Update', handlerUpdateUser);
    consumeMessages('Auth.Chat.User.Delete', handlerDeleteUser);
    consumeMessages('Global.Notification', handleAddNotificatioin);
    consumeMessages('MedicalServicies.Chat.Doctor.Update', hadnleUpdateDoctor);
  },
};

module.exports = MyControllers;
