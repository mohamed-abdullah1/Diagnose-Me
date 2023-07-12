const amqp = require('amqplib');
const colors = require('colors');

async function sendToQueue(queueName, message) {
  const hostname = 'localhost'; // Replace with your RabbitMQ server hostname
  const port = 5672; // Replace with your RabbitMQ server port
  const username = 'DiagnoseMe'; // Replace with your RabbitMQ server username
  const password = 'DiagnoseMe'; // Replace with your RabbitMQ server password

  // Create connection URL
  const connectionUrl = `amqp://DiagnoseMe:DiagnoseMe@rabbitmq.diagnose.me:5672`;

  // Connect to RabbitMQ server
  try {
    const connection = await amqp.connect(connectionUrl);
    const channel = await connection.createChannel();

    // Ensure the queue exists
    await channel.assertQueue(queueName, { durable: true });

    // Send message to the queue
    channel.sendToQueue(queueName, Buffer.from(message));

    console.log(`Message sent by RabbitMQ to ${queueName}:\n ${message}`.blue);

    // Close the connection
    await channel.close();
    await connection.close();
  } catch (error) {
    console.log('Error occurred while sending a message:', error);
  }
}

module.exports = sendToQueue;

const queueName = {
  add: 'Auth.Chat.User.Add',
  update: 'Auth.Chat.User.Update',
  delete: 'Auth.Chat.User.Delete',
  notification: 'Global.Notification',
  doctor: 'MedicalServicies.Chat.Doctor.Update',
  patientNum: 'PatientsNum.Update',
};

const message = JSON.stringify({
  Title: '👋Notification Title👋',
  Message: 'Another notification comes from Admin✅🎉',
  RecipientId: '657cb6cb-abf2-00d1-5d46-939a7b3aff5f',
  SenderId: '972a1201-a9dc-2127-0827-560cb7d76af8',
});

// sendToQueue(queueName.notification, message);

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
