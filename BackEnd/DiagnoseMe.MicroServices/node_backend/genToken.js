const jwt = require('jsonwebtoken');
require('dotenv').config();

const generateToken = (id) => {
  return jwt.sign({ ID: id, roles: 'Doctor' }, process.env.JWT_SECRET, {
    expiresIn: '12d',
    issuer: process.env.Issuer,
    audience: process.env.Audience,
  });
};
console.log('😴✅', process.env);
console.log(generateToken('657cb6cb-abf2-00d1-5d46-939a7b3aff5f'));

// https://chat.openai.com/share/0fcdda15-6afc-488b-8b8a-1fbe7703b0b3
