const mongoose = require('mongoose');

const connectionString = 'mongodb://localhost:27017/catagram';

mongoose.connect(connectionString, { useNewUrlParser: true, useUnifiedTopology: true });

const db = mongoose.connection;
// unnecessary events when the connection is open:
db.on('error', console.error.bind(console, 'connection error:'));
db.once('open', () => {
    console.log('Connected to database!');
});