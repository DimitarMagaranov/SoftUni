const router = require('express').Router();
const authService = require('../services/authService');

const isAuthenticatedMiddleware = require('../middlewares/isAuthenticated');
const isGuestMiddleware = require('../middlewares/isGuest');

const {JWT_COOKIE_NAME} = require('../config');

router.get('/login', isGuestMiddleware, (req, res) => {
    res.render('login');
});

router.post('/login', isGuestMiddleware, async (req, res) => {
    const {username, password} = req.body;

    try {
        const token = await authService.login({username, password});
        res.cookie(JWT_COOKIE_NAME, token);
        res.redirect('/products');
    } catch (error) {
        res.render('login', {error});
    }
});

router.get('/register', isGuestMiddleware, (req, res) => {
    res.render('register');
});

router.post('/register', isGuestMiddleware, async (req, res) => {
    const {username, password, repeatPassword} = req.body;

    if (password !== repeatPassword) {
        res.render('register', { message: 'Password missmatch!' });
        return;
    }

    try {
        const result = await authService.register({username, password});
        res.redirect('/auth/login');
    } catch (error) {
        res.render('register', {error});
    }
});

router.get('/logout', isAuthenticatedMiddleware, (req, res) => {
    res.clearCookie(JWT_COOKIE_NAME);
    res.redirect('/products');
})

module.exports = router;