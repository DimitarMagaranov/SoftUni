const express = require('express');
const mongoose = require('mongoose');
//const cors = require('./middlewares/cors');
const cors = require('cors');

const routes = require('./routes');
const { auth } = require('./middlewares/auth');
const errorHandler = require('./middlewares/errorHandler');

const app = express();

mongoose.connect('mongodb://localhost/softuni-movies', {useNewUrlParser: true, useUnifiedTopology: true});
const db = mongoose.connection;
db.on('error', console.error.bind(console, 'connection error:'));
db.once('open', function() {
    console.log('DB connected!');
})

//app.use(cors);
app.use(cors());

// body parser for multipage app because of the sending html forms:
//app.use(express.urlencoded({extended: true}));

// body parser for json (IMPORTANT FOR REST API!!!):
app.use(express.json());

app.use(auth);

app.use('/api', routes);
app.use(errorHandler);

app.listen(5000, console.log.bind(console, 'Server is listening on port 5000...'));