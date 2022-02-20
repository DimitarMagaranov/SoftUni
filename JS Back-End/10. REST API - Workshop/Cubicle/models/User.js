const mongoose = require('mongoose');

const bcrypt = require('bcrypt');
const { SALT_ROUNDS, JWT_SECRET } = require('../config');

const ENGLISH_ALPHANUMERIC_PATTERN = /^[a-zA-Z0-9]+$/;

const userSchema = new mongoose.Schema({
    id: mongoose.Types.ObjectId,
    username: {
        type: String,
        required: true,
        unique: true,
        minlength: 5,
        validate: {
            validator: (value) => {
                return ENGLISH_ALPHANUMERIC_PATTERN.test(value);
            },
            message: props =>
                `${props.value} is invalid username. Username should consist only english letters and digits!`
        }
    },
    password: {
        type: String,
        required: true,
        minlength: 5,
        validate: {
            validator: (value) => {
                return ENGLISH_ALPHANUMERIC_PATTERN.test(value);
            },
            message: props =>
                'Username should consist only english letters and digits!'
        }
    }
});

// with promise:
userSchema.pre('save', function (next) {
    bcrypt.genSalt(SALT_ROUNDS)
        .then(salt => {
            return bcrypt.hash(this.password, salt);
        })
        .then(hash => {
            this.password = hash;
            next();
        })
        .catch(err => {
            // TODO:
            console.log(err);
        });
});

// with async/await:
// userSchema.pre('save', async function(next) {
//     const salt = await bcrypt.genSalt(SALT_ROUNDS);
//     const hash = await bcrypt.hash(this.password, salt);
//     this.password = hash;
//     next();
// });

module.exports = mongoose.model('User', userSchema);