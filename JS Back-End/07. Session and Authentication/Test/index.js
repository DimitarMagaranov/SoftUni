const express = require('express');
const cookieParser = require('cookie-parser');
const expressSession = require('express-session');
const uniqid = require('uniqid');
const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');

const app = express();

// const sessionData = {};
// const session = function () {
//     return (req, res, next) => {
//         if (!req.cookies.id) {
//             let cookieId = uniqid();

//             sessionData[cookieId] = {};
//             req.session = {};

//             res.cookie('id', cookieId);
//         } else {
//             const cookieId = req.cookies.id;
//             req.session = sessionData[cookieId];
//         }

//         next();
//     }
// }

//app.use(session());

app.use(express.urlencoded({ extended: true }));
app.use(cookieParser());
app.use(expressSession({
    secret: 'navcho',
    resave: false,
    saveUninitialized: true,
    cookie: { secure: false }
}));

app.get('/register/:username/:password', (req, res) => {
    // res.cookie('username', req.params.username);

    let plainTextPassword = req.params.password;
    req.session.username = req.params.username;

    bcrypt.genSalt(9, (err, salt) => {
        if (err) {
            return console.log(err);
        }

        bcrypt.hash(plainTextPassword, salt, (err, hash) => {
            if (err) {
                return console.log(err);
            }

            req.session.passwordHash = hash;
            console.log(hash);
        });
    });

    res.send('You have been logged!');
});

app.get('/', (req, res) => {
    res.send(`<h1>Hello ${req.session?.username || 'n\\a'}</h1>`);
})

app.get('/session', (req, res) => {
    res.send(req.session);
})

app.get('/login/:password', (req, res) => {
    console.log(req.session);

    bcrypt.compare(req.params.password, req.session.passwordHash, (err, isIdentical) => {
        if (err) {
            return console.log(err);
        }

        res.send(isIdentical ? 'Logged In' : 'Error login');
    })
})

app.get('/token/create', (req, res) => {
    res.send(`
    <form action="/token/create" method="post">
        <div>
            <label>Username:</label>
            <input type="text" name="username"/>
        </div>
        <div>
            <label>Password:</label>
            <input type="password" name="password"/>
        </div>
        <div>
            <input type="submit" value="Log In"/>
        </div>
    </form>
    `);
});

app.post('/token/create', (req, res) => {
    bcrypt.hash(req.body.password, 2, (err, hash) => {
        const payloads = {
            _id: uniqid(),
            username: req.body.username,
            password: hash,
        };

        const options = { expiresIn: '2d' };

        const secret = 'mysecret';

        const token = jwt.sign(payloads, secret, options);

        res.cookie('jwt', token);
        res.redirect('/token/show');
    })


})

app.get('/token/show', (req, res) => {
    const token = req.cookies.jwt;

    const decodedToken = jwt.verify(token, 'mysecret');

    res.json(decodedToken);
})

app.get('/token/login', (req, res) => {
    res.send(`
    <form action="/token/login" method="post">
        <div>
            <label>Username:</label>
            <input type="text" name="username"/>
        </div>
        <div>
            <label>Password:</label>
            <input type="password" name="password"/>
        </div>
        <div>
            <input type="submit" value="Log In"/>
        </div>
    </form>
    `);
});

app.post('/token/login', (req, res) => {
    const token = req.cookies.jwt;

    const decodedToken = jwt.verify(token, 'mysecret');

    if (req.body.username !== decodedToken.username) {
        return res.status(400).send('Not valid user!');
    }

    bcrypt.compare(req.body.password, decodedToken.password, (err, isIdentical) => {
        console.log(isIdentical);

        if (isIdentical) {
            res.send('You are logged in! Wellcome ' + decodedToken.username);
        } else {
            res.status(400).send('Not valid password!');
        }
    })

     
})


app.listen(5005, function () {
    console.log('Server is listening on port 5005...');
})