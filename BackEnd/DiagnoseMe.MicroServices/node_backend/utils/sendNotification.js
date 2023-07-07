let admin = require('firebase-admin'); // check if it will work without the initilizaion for credentials and also check for topics
let FCM = require('fcm-node');

function sendNotification1(token, title, body) {
  let payload = {
    notification: {
      title,
      body,
    },
  };
  admin
    .messaging()
    .sendToDevice(token, payload)
    .then(function (response) {
      console.log('Successfully sent notification:', response);
    })
    .catch(function (error) {
      console.log('Error sending notification:', error);
    });
}

function sendNotification2(token, title, body, data, next) {
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
    data,
  };

  fcm.send(message, (err, respose) => {
    if (err) {
      next(err);
    } else {
      return respose;
    }
  });
}

module.exports = { sendNotification1, sendNotification2 };
