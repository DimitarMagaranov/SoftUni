const mongoose = require('mongoose');
const Person = require('./modules/Person');

const connectionString = 'mongodb://localhost:27017/mongoTest';

mongoose.connect(connectionString, { useNewUrlParser: true, useUnifiedTopology: true });

const db = mongoose.connection;
// unnecessary events when the connection is open:
db.on('error', console.error.bind(console, 'connection error:'));
db.once('open', () => {
    console.log('Connected to database!');
});


// CRUD operations:
// 1) create

// let person = new Person({name: 'Dimitar', age: 18});

// first way to save whit callback:
// person.save((err, result) => {
//     if (err) {
//         return console.log(err);
//     }

//     console.log(result);
// });

// second way to save whit promise:
// person.save()
//     .then(result => {
//         console.log(result);
//     });

//third way to save whit async function:
// async function save() {
//     const savedPerson = await person.save();
//     console.log(savedPerson);
//     console.log(savedPerson.getInfo());
//     console.log(savedPerson.birthYear);
// }
// save();



// 2) read:

// Person.find({})
//     .then((people) => {
//         people.forEach(x => {
//             console.log(x.getInfo());
//             console.log(x.birthYear);
//         });
//     });

// async function getById() {
//     const result =  await Person.findById('616f0b9faa5f823140f2061a');
//     console.log(result);
// }

// getById();

// async function counter() {
//     let count = await Person.count({age: {$gte: 18}});
//     console.log(count);
// }

// counter();

// async function select() {
//     let names = await Person.find({}).select('name');
//     console.log(names);
// }

// select();


async function sort() {
    let sortedPeopleByYear = await Person.find({}).sort({age: 1});
    console.log(sortedPeopleByYear);
}

sort();


// 3) update:

// Person.updateOne({_id: '616f0b9faa5f823140f2061a'}, {$set: {name: 'Stamatcho'}})
//     .then(res => {
//         console.log(res);
//     })



// 4) delete:

// Person.remove({name: 'Stamatcho'})
//     .then(res => {
//         console.log(res);
//     })