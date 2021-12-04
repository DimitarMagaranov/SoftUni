// NATIVE WORK WITH MONGODB: 


const mongodb = require('mongodb');

const MongoClient = mongodb.MongoClient;

const uri = 'mongodb://localhost:27017';

const client = new MongoClient(uri, { useUnifiedTopology: true });


//1st way with callback:
// client.connect(err => {
//     if (err) {
//         console.log(err);
//         return;
//     }

//     let db = client.db('catagram');
//     let cats = db.collection('cats');

//     cats.find({}, (err, result) => {
//         if (err) {
//             console.log(err);
//             return;
//         }

//         result.toArray((err, result) => {
            
//             console.log(result);
//         })
//     });
// });


//2nd way with promise:
// client.connect()
//     .then(res => {
//         const db = client.db('catagram');
//         const cats = db.collection('cats');

//         return cats.findOne({});
//     })
//     .then(res => {
//         console.log(res);
//     });


//3th way with async function:
async function run() {
    await client.connect();

    const db = client.db('catagram');
    const cats = db.collection('cats');

    const firstCat = await cats.findOne({});
    console.log(firstCat);
}

run();