const jwt = require('jsonwebtoken');
const { JWT_COOKIE_NAME, JWT_SECRET } = require('../config');

module.exports = function () {
    return (req, res, next) => {
        const jwtToken = req.cookies[JWT_COOKIE_NAME];
        if (jwtToken) {
            jwt.verify(jwtToken, JWT_SECRET, function (err, decoded) {
                if (err) {
                    res.clearCookie(JWT_COOKIE_NAME);
                } else {
                    req.user = decoded;
                    res.locals.user = decoded;
                    res.locals.isAuthenticated = true;
                }
            });
        }

        next();
    };
}