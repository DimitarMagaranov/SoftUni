// const myObj = {
//     name: 'Peter',
//     age: 21
// };

// console.log(Object.getOwnPropertyDescriptor(myObj, 'name')); - взимаме прпъртитата на пропъртито 'name'

// define property with property descriptor
// Object.defineProperty(myObj, 'lastName', {
//     value: 'Jonson',
//     writable: true,
//     enumerable: true,
//     configurable: true
// });

// for(let key in myObj) {
//     console.log(key, myObj[key]);
// }


const myCollection = {};

Object.defineProperty(myCollection, 'size', {
    enumerable: false,
    get: function() {
        return Object.keys(this).length;
    }
});

myCollection['John'] = '+1-555-7894';
myCollection['Peter'] = '+1-555-7834';
myCollection['May'] = '+1-555-7594';

console.log(myCollection.size);