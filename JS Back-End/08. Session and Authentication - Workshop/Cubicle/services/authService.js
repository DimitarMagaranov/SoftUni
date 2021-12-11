const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const { SALT_ROUNDS, JWT_SECRET } = require('../config');
const User = require('../models/User');

const register = async ({ username, password }) => {
    // TODO: Check if username exists

    // there is no need of try-catch block because of the block in the controller's function
    const salt = await bcrypt.genSalt(SALT_ROUNDS);
    const hash = await bcrypt.hash(password, salt);

    const user = new User({ username, password: hash });

    return await user.save();
};

const login = async ({username, password}) => {
    // get user from db
    // mongoose query => const user = await User.find({}).where('username').eq(username);
    const user = await User.findOne({username});
    if (!user) throw {message: 'User not found!'};

    // compare password hash
    const isMatch = await bcrypt.compare(password, user.password); 
    if (!isMatch) throw {message: 'The password is incorect!'};

    // generate token
    const token = jwt.sign({_id: user._id, username: user.username}, JWT_SECRET);

    return token;
}

module.exports = {
    register,
    login,
};