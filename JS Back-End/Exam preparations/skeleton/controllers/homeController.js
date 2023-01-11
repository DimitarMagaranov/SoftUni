const router = require('express').Router();

router.get('/', (req, res) => {
    // the folder is home and the view is index:
    res.render('home/index', {name: 'Pesho'});
});


module.exports = router;