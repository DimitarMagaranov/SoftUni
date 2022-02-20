const { Router } = require('express');
const productService = require('../services/productService');
const accessoryService = require('../services/accessoryService');
const productHelpers = require('./helpers/productHelpers');
const isAuthenticatedMiddleware = require('../middlewares/isAuthenticated');

const router = Router();

router.get('/', (req, res) => {
    productService.getAll(req.query)
        .then(products => {
            res.render('home', { title: 'Browse', products });
        })
        .catch(() => res.status(404).end())
});

router.get('/create', isAuthenticatedMiddleware, (req, res) => {
    res.render('create', { title: 'Create' });
});

router.post('/create', isAuthenticatedMiddleware, (req, res, next) => {
    // TODO: Validate inputs

    //with callback:
    // productService.create(req.body, (err) => {
    //     if (err) {
    //         return res.status(500).end();
    //     }

    //     res.redirect('/products');
    // });

    //with promise:
    productService.create(req.body, req.user._id)
        .then(() => res.redirect('/products'))
        .catch(next);
})

router.get('/details/:id', async (req, res) => {
    // productService.getById(req.params.id)
    //     .then(product => {
    //         res.render('details', {title: 'Details', product});
    //     })
    //     .catch(() => res.status(500).end());
    const product = await productService.getByIdWithAccessories(req.params.id);
    res.render('details', { title: 'Details', product });
});

router.get('/:productId/attach', isAuthenticatedMiddleware, async (req, res) => {
    const product = await productService.getById(req.params.productId);
    const accessories = await accessoryService.getAllUnChoosed(product.accessories);

    res.render('attachAccessory', { product, accessories });
});

router.post('/:productId/attach', isAuthenticatedMiddleware, (req, res) => {
    productService.attachAccessory(req.params.productId, req.body.accessory)
        .then(() => res.redirect(`/products/details/${req.params.productId}`))
        .catch(() => res.status(500).end());
});

router.get('/:productId/edit', isAuthenticatedMiddleware, async (req, res) => {
    const product = await productService.getById(req.params.productId);
    res.render('editCube', product);
});

router.post('/:productId/edit', isAuthenticatedMiddleware, productHelpers.validateInputs, async (req, res) => {
    await productService.updateOne(req.params.productId, req.body);
    res.redirect(`/products/details/${req.params.productId}`);
    // productService.updateOne(req.params.productId, req.body)
    //     .then(response => {
    //         res.redirect(`/products/details/${req.params.productId}`);
    //     });
});

router.get('/:productId/delete', isAuthenticatedMiddleware, async (req, res) => {
    const product = await productService.getById(req.params.productId);

    if (req.user._id != product.creator) return res.redirect('/products');

    res.render('deleteCube', product);
});

router.post('/:productId/delete', isAuthenticatedMiddleware, async (req, res) => {
    const product = await productService.getById(req.params.productId);

    if (req.user._id != product.creator) return res.redirect('/products');

    await productService.deleteOne(req.params.productId);

    res.redirect('/products');
})

module.exports = router;