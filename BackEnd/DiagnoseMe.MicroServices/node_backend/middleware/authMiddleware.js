const jwt = require('jsonwebtoken');
const User = require('../models/userModel.js');
const asyncHandler = require('express-async-handler');
const { AppError } = require('./errorMiddleware.js');

const protect = asyncHandler(async (req, res, next) => {
  let token;

  if (req.headers.authorization && req.headers.authorization.startsWith('Bearer')) {
    //   0        1
    token = req.headers.authorization.split(' ')[1]; // Bearer kdjfasjkj
    // decodes token id
    // const decoded = jwt.verify(token, process.env.JWT_SECRET); // will verify the token if valid will return decoded payload if not will throw error
    const nameIdentifier = 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier';
    const decoded = jwt.verify(token, process.env.JWT_SECRET, {
      issuer: process.env.Issuer,
      audience: process.env.Audience,
    });
    req.user = await User.findById(decoded[nameIdentifier][0]).select('-password');
    req.user.Role = decoded.roles;
    res.setHeader('Access-Control-Allow-Origin', '*');
    next();
  }

  if (!token) {
    next(new AppError('Not authorized, no token provided 😴', 500));
  }
});

module.exports = { protect };
