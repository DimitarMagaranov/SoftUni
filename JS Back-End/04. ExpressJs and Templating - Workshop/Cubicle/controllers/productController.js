const {Router} = require('express');
const productService = require('../services/productService');
const productHelpers = require('./helpers/productHelpers');

const router = Router();

router.get('/', (req, res) => {
    let products = productService.getAll(req.query);
    res.render('home', {title: 'Browse', products});
});

router.get('/create', (req, res) => {
    res.render('create', {title: 'Create'});
});

router.post('/create', productHelpers.validateInputs, (req, res) => {
    // TODO: Validate inputs

    //with callback:
    // productService.create(req.body, (err) => {
    //     if (err) {
    //         return res.status(500).end();
    //     }

    //     res.redirect('/products');
    // });

    //with promise:
    productService.create(req.body)
        .then(() => res.redirect('/products'))
        .catch(() => res.status(500).end());
})

router.get('/details/:id', (req, res) => {
    let product = productService.getById(req.params.id);
    res.render('details', {title: 'Details', product});
});

module.exports = router;