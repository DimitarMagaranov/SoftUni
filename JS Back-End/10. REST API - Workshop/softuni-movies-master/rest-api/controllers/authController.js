const router = require('express').Router();
const jwt = require('jsonwebtoken');

const User = require('../models/User');

router.post('/login', (req, res, next) => {
    User.findOne({ username: req.body.username, password: req.body.password })
        .then(user => {
            // generate JWT:
            const token = jwt.sign({
                _id: user._id,
                username: user.username,
            }, 'SOMESECRET', { expiresIn: '1h' });

            res.status(200).json({
                _id: user._id,
                username: user.username,
                token,
            });
        })
        .catch(err => {
            next({status: 404, message: 'No such user or password!', type: 'ERROR'});
        });
})

router.post('/register', (req, res) => {
    // TODO: Check if user exists

    const user = new User(req.body);

    user.save()
        .then(createdUser => {
            console.log(createdUser);
            res.status(201).json({ _id: createdUser._id });
        });
});

module.exports = router;