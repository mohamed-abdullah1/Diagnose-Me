const amqp = require('amqplib');
const colors = require('colors');

async function sendToQueue(queueName, message) {
  try {
    const hostname = 'localhost'; // Replace with your RabbitMQ server hostname
    const port = 5672; // Replace with your RabbitMQ server port
    const username = 'DiagnoseMe'; // Replace with your RabbitMQ server username
    const password = 'DiagnoseMe'; // Replace with your RabbitMQ server password

    // Create connection URL
    const connectionUrl = `amqp://${username}:${password}@${hostname}:${port}`;

    // Connect to RabbitMQ server
    const connection = await amqp.connect(connectionUrl);
    const channel = await connection.createChannel();

    // Ensure the queue exists
    await channel.assertQueue(queueName, { durable: true });

    // Send message to the queue
    channel.sendToQueue(queueName, Buffer.from(message));

    console.log(`Message sent to ${queueName}:\n ${message}`.blue);

    // Close the connection
    await channel.close();
    await connection.close();
  } catch (error) {
    console.error('Error:🙃', error);
  }
}

// // Usage: node send.js [queueName] [message]
// const queueName = process.argv[2];
// const message = process.argv[3];

// if (!queueName || !message) {
//   console.error('Usage: node send.js [queueName] [message]');
//   process.exit(1);
// }

const queueName = { add: 'Auth.Add', update: 'Auth.Update', delete: 'Auth.Delete' };

const message = JSON.stringify('hello from Rabit MQ👋, How Are You🙃');

sendToQueue(queueName.add, message);

//

//

//

//

//

//

// hello from Rabit MQ👋, How Are You🙃
// userId: 'a92f383a-aded-4117-bd9a-61cd777bc255',
/*
{
  _id: '',
  Name: 'Hamza',
  ProfilePictureUrl: 'https://cdn-icons-png.flaticon.com/512/3135/3135715.png',
}
*/

/*
string Id,
string Name,
string FullName,
string Gender,
string DateOfBirth,
string BloodType,
string ProfilePictureUrl,
string PhoneNumber,
string NationalID,
bool   IsDoctor
*/

/*
public const string ChatAddingUserQueue = "Auth.Chat.User.Add";
public const string ChatDeletingUserQueue = "Auth.Chat.User.Delete";
public const string ChatUpdatingUserQueue = "Auth.Chat.User.Update";
public const string AuthAddExchange = "Auth.Add";
public const string AuthDeleteExchange = "Auth.Delete";
public const string AuthUpdateExchange = "Auth.Update";
*/
