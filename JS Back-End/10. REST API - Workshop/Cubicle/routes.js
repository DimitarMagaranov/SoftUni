const { Router } = require('express');

const productController = require('./controllers/productController');
const homeController = require('./controllers/homeController');
const authController = require('./controllers/authController');
const accessoryController = require('./controllers/accessoryController');

const router = Router();

router.use('/', homeController);
router.use('/auth', authController);
router.use('/products', productController);
router.use('/accessories', accessoryController);
router.get('*', (req, res) => {
    res.render('404', {title: 'Page not found'})
});

module.exports = router;