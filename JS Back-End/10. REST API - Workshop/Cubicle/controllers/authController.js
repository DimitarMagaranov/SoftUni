const router = require('express').Router();
const authService = require('../services/authService');
const validator = require('validator');
const { check, validationResult, body } = require('express-validator');

const isAuthenticatedMiddleware = require('../middlewares/isAuthenticated');
const isGuestMiddleware = require('../middlewares/isGuest');

const { JWT_COOKIE_NAME } = require('../config');

router.get('/login', isGuestMiddleware, (req, res) => {
    res.render('login');
});

router.post('/login', isGuestMiddleware, async (req, res) => {
    const { username, password } = req.body;

    try {
        const token = await authService.login({ username, password });
        res.cookie(JWT_COOKIE_NAME, token);
        res.redirect('/products');
    } catch (error) {
        res.render('login', { error });
    }
});

router.get('/register', isGuestMiddleware, (req, res) => {
    res.render('register');
});

router.post(
    '/register',
    isGuestMiddleware,
    //body('username', 'Username field is empty!').notEmpty(),
    //body('password', 'Password too short!').isLength({ min: 5, max: 10 }),
    //body('email', 'Your email is not valid!').isEmail().normalizeEmail(),
    async (req, res) => {
        const { username, password, repeatPassword } = req.body;

        // const isStrongPassword = validator.isStrongPassword(password, {
        //     minLength: 8,
        //     minLowercase: 1,
        //     minUppercase: 1,
        //     minNumbers: 1,
        //     minSymbols: 1
        // });

        if (password !== repeatPassword) {
            res.render('register', { error: { message: 'Password missmatch!' }});
            return;
        }

        // let errors = validationResult(req);
        // if (errors.errors.length > 0) {
        //     return res.render('register', errors);
        // }

        try {
            // if (!isStrongPassword) {
            //     return res.render('register', { error: { message: 'You should have strong password!' }, username: req.body.username });
            // }

            const result = await authService.register({ username, password });
            res.redirect('/auth/login');
        } catch (err) {
            let error = Object.keys(err?.errors).map(x => ({message: err.errors[x].properties.message}))[0];
            res.render('register', { error });
        }
    });

router.get('/logout', isAuthenticatedMiddleware, (req, res) => {
    res.clearCookie(JWT_COOKIE_NAME);
    res.redirect('/products');
})

module.exports = router;