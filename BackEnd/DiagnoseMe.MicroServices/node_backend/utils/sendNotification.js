let admin = require('firebase-admin'); // check if it will work without the initilizaion for credentials and also check for topics
let FCM = require('fcm-node');

function sendNotification1(token, title, body) {
  let payload = {
    notification: {
      title,
      body,
    },
    token,
  };
  admin
    .messaging()
    .send(payload)
    .then(function (response) {
      console.log('Successfully sent notification:', response);
    })
    .catch(function (error) {
      console.log('Error sending notification:', error);
    });
  // admin
  //   .messaging()
  //   .sendToDevice(token, payload)
}

function sendNotification2(token, title, body) {
  let fcm = new FCM(process.env.Server_Key);
  let message = {
    to: token, // '/topics/' + req.body.topic
    notification: {
      title,
      body,
      sound: 'default',
      click_action: 'FCM_PLUGIN_ACTIVITY',
      icon: 'fcm_push_icon',
    },
  };

  fcm.send(message, (err, respose) => {
    if (err) {
      console.log('error during notifications:', err);
    } else {
      return respose;
    }
  });
}

module.exports = { sendNotification1, sendNotification2 };
