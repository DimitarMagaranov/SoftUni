const fs = require('fs');
const catsData = require('./cats.json');

const cats = catsData.slice();

function add(name) {
    let id = 1;

    if (cats.length > 0) {
        id = cats[cats.length - 1].id + 1;
    }

    cats.push({id, name});
    fs.writeFile('./cats.json', JSON.stringify(cats), (err) => {
        if (err) {
            console.log('some error' + err);
            return;
        }

        console.log('successful added cat');
    });
}

function getAll() {
    return cats.slice();
}

function getById(id) {
    return cats.find(x => x.id == id);
}

module.exports = {
    add,
    getAll,
    getById,
}