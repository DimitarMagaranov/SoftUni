import express from 'express';

const app = express();

app.get('/', (req, res) => {
    res.send('Hello world!');
});

app.get('/about', (req, res) => {
    res.send('ABOUT US');
});

app.listen(8080, () => {
    console.log('Server is listening on port 8080');
    
});