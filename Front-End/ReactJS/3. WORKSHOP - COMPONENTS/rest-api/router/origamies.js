const express = require('express');
const router = express.Router();
const { auth } = require('../utils');
const { origamiController } = require('../controllers');

router.get('/', origamiController.getOrigamies);

router.post('/', auth(), origamiController.createOrigami);

router.put('/:id', auth(), origamiController.editOrigami);

router.delete('/:id', auth(), origamiController.deleteOrigami);

module.exports = router;