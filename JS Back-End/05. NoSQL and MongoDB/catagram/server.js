const express = require('express');
const handlebars = require('express-handlebars');
const bodyParser = require('body-parser');
const createCat = require('./services/createCat');
require('./config/db');
const checkCatIdMiddleware = require('./middlewares/middleware');
const loggerMiddleware = require('./middlewares/loggerMiddleware');

const cats = require('./cats');

const app = express();

//if we want to use middware before all
//app.use(checkCatIdMiddleware);

//middlewares before all:
app.use('/static', express.static('public'));
//app.use(express.static('public'));
app.use(loggerMiddleware);

app.use(bodyParser.urlencoded({extended: false}));

app.engine('hbs', handlebars({
    extname: 'hbs',
}));
app.set('view engine', 'hbs');

app.get('/', (req, res) => {
    //res.sendFile(__dirname + '/views/home.html');

    createCat('Navcho', 'Dimitar');

    let name = 'Pesho';

    res.render('home', {
        name,
    });
});

app.get('/download', (req, res) => {
    res.download('./public/cats.html');
});

app.get('/cats/:id?', /*checkCatIdMiddleware, */ (req, res) => {
    let id = parseInt(req.params.id);

    if (id) {
        let cat = cats.getById(id);
        return res.render('catDetails', {cat});
    }

    res.render('cats', {cats: cats.getAll()});
    console.log(cats.getAll());
});

app.post('/cats', (req, res) => {
    let catName = req.body.name;
    cats.add(catName);
    
    res.redirect('/cats');
});

app.put('/cats/:id', checkCatIdMiddleware, (req, res) => {
    const paramsObj = req.params;
    res.send(`update cat with id:${paramsObj.id}`);
});

app.all('/', (req, res) => {
    console.log('handle all requests');
});


app.listen(5000, () => {
    console.log('Server is running on port 5000');
});