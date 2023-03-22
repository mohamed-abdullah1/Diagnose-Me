const mongoose = require('mongoose');

const connectDB = async () => {
  try {
    mongoose.set('strictQuery', true);
    const conn = await mongoose.connect(process.env.MONGO_URI, {
      useUnifiedTopology: true,
    });
    console.log(`MongoDB Connected to the host:`.blue, `${conn.connection.host}`.white);
  } catch (err) {
    console.log('ERROR IN DB CONNECTION: '.red, err.message);
    process.exit();
  }
};

module.exports = connectDB;
