const Cube = require('../models/Cube');
const Accessory = require('../models/Accessory');


function getById(id) {
    return Cube.findById(id).lean();
}

function getByIdWithAccessories(id) {
    return Cube.findById(id).populate('accessories').lean();
}

async function getAll(query) {
    let products = await Cube.find({}).lean();

    if (query.search) {
        products = products.filter(x => x.name.toLowerCase().includes(query.search));
    }

    if (query.from) {
        products = products.filter(x => Number(x.level) >= Number(query.from));
    }

    if (query.to) {
        products = products.filter(x => Number(x.level) <= Number(query.to));
    }

    return products;
}

function create(data, userId) {
    let cube = new Cube({...data, creator: userId});

    // return productData.create(cube);
    return cube.save();
}

async function attachAccessory(cubeId, accessoryId) {
    let cube = await Cube.findById(cubeId);
    let accessory = await Accessory.findById(accessoryId);

    cube.accessories.push(accessory);
    return cube.save();
};

function updateOne(productId, productData) {
    return Cube.updateOne({_id: productId}, productData);
}

function deleteOne(productId) {
    return Cube.deleteOne({_id: productId});
}

module.exports = {
    create,
    getById,
    getAll,
    attachAccessory,
    getByIdWithAccessories,
    updateOne,
    deleteOne,
};