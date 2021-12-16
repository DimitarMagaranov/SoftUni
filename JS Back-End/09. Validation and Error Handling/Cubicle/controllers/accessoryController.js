const {Router} = require('express');
const accessoryService = require('../services/accessoryService');

const router = Router();

router.get('/create', (req, res) => {
    res.render('createAccessory');
});

// TODO: create validation middleware or just validate incomming data
router.post('/create', async (req, res) => {
    await accessoryService.create(req.body);

    res.redirect('/products');
})

module.exports =  router;