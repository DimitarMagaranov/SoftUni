const {Router} = require('express');
const productService = require('../services/productService');
const accessoryService = require('../services/accessoryService');
const productHelpers = require('./helpers/productHelpers');

const router = Router();

router.get('/', (req, res) => {
    productService.getAll(req.query)
        .then(products => {
            res.render('home', {title: 'Browse', products});
        })
        .catch(() => res.status(404).end())
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

router.get('/details/:id', async (req, res) => {
    // productService.getById(req.params.id)
    //     .then(product => {
    //         res.render('details', {title: 'Details', product});
    //     })
    //     .catch(() => res.status(500).end());
    const product = await productService.getByIdWithAccessories(req.params.id);
    res.render('details', {title: 'Details', product});
});

router.get('/:productId/attach', async (req, res) => {
    const product = await productService.getById(req.params.productId);
    const accessories = await accessoryService.getAllUnChoosed(product.accessories);

    res.render('attachAccessory', {product, accessories});
});

router.post('/:productId/attach', (req, res) => {
    productService.attachAccessory(req.params.productId, req.body.accessory)
        .then(() => res.redirect(`/products/details/${req.params.productId}`))
        .catch(() => res.status(500).end());
})

module.exports = router;