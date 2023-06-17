const jwt = require('jsonwebtoken'); // npm i jsonwebtoken      to install packages of jwt

const generateToken = (id) => {
  return jwt.sign({ id }, process.env.JWT_SECRET, {
    expiresIn: '12h',
    issuer: process.env.Issuer,
    audience: process.env.Audience,
  });
};

module.exports = generateToken;
