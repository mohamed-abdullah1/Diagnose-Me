const mongoose = require('mongoose');

const connectDB = async () => {
  try {
    mongoose.set('strictQuery', true);
    const connString = process.env.MONGO_URI.replace('<PASSWORD>', process.env.DATABASE_PASSWORD);

    const conn = await mongoose.connect(connString, {
      useUnifiedTopology: true,
    });
    console.log(`MongoDB Connected to the host:`.blue, `${conn.connection.host}`.white);
    // replacement without try catch but only promises
    // mongoose.connect(connString, {useUnifiedTopology:true})
    //         .then(conn=>{console.log(conn.connection.host)})
    //         .catch(err=>{console.log(err)})
  } catch (err) {
    console.log('ERROR IN DB CONNECTION: '.red, err.message);
    process.exit();
  }
};

module.exports = connectDB;
