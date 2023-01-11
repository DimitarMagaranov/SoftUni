const config = {
    development: {
        PORT: 5000,
        DB_CONNECTION_STRING: 'mongodb://localhost/cubicle',
        SALT_ROUNDS: 1,
        JWT_SECRET: 'somesecret',
        JWT_COOKIE_NAME: 'USER_SESSION',
    },
    production: {
        PORT: 80,
        DB_CONNECTION_STRING: 'mongodb+srv://DimitarMagaranov:Dd73194655!@cubicle.ovkcc.mongodb.net/test',
        SALT_ROUNDS: 10,
        JWT_SECRET: 'somesecret',
        JWT_COOKIE_NAME: 'USER_SESSION',
    }
};

module.exports = config[process.env.NODE_ENV.trim()];