const jwt = require('jsonwebtoken');

function auth(req, res, next) {
    const authorizationHeader = req.get('Authorization');

    if (authorizationHeader) {
        const token = authorizationHeader.split(' ')[1];

        try {
            const decoded = jwt.verify(token, 'SOMESECRET');

            req.user = decoded;
        } catch (error) {
            return next();
        }
    }

    next();
}

function isAuth(req, res, next) {
    if (!req.user) {
        res.status(401).json({ errorData: 'You cannot perform this action.' });
    }

    next();
}

module.exports = {
    isAuth,
    auth,
};
