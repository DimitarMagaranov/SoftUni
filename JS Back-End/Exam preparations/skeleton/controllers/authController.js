const router = require('express').Router();
const { body, validationResult } = require('express-validator');
const authService = require('../services/authService');

router.get('/', (req, res) => {
    res.send('Auth Controller is here')
});

router.get('/login', (req, res) => {
    res.render('auth/login');
});

router.post('/login', (req, res) => {
    console.log(req.body);

    res.redirect('/');
})

router.get('/register', (req, res) => {
    res.render('auth/register');
});

router.post('/register',
    // body('passwordRepeat')
    // .trim()
    // .custom((value, {req}) => {
    //     if (value != req.body.password) {
    //         return Promise.reject('Password missmatch!');
    //     }
    // }),
    (req, res, next) => {
        // console.log(body('passwordRepeat'));
        // let errors = validationResult(req).array();

        // if (errors.length > 0) {
        //     let error = errors[0];
        //     error.message = error.msg;
        //     return next(error);
        // }
        
        const { username, password, repeatPassword } = req.body;

        if (password != repeatPassword) {
            throw new Error('Password mismatch!');
        }

        authService.register(username, password)
            .then(createdUser => {
                console.log('Created User::::::::');
                console.log(createdUser);

                res.redirect('/auth/login');
            })
            .catch(err => next(err));   // or .catch(next);
    }
 );

module.exports = router;