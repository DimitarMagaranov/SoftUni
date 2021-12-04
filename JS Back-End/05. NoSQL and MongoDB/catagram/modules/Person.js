const mongoose = require('mongoose');

// creating a model:
const personSchema = new mongoose.Schema({
    name: {type: String, required: true, minlength: 3},
    age: Number,
});

// adding custom methods to the schema:
// (we are using function declaration because of THIS)
personSchema.methods.getInfo = function() {
    return `Hello! My name is ${this.name}. I am ${this.age} years old.`;
}

// adding virtual property which is not added to the database schema:
personSchema.virtual('birthYear')
    .get(function() {
        return new Date().getFullYear() - this.age;
    });

// adding custom validation of property which is in the schema:
personSchema.path('age')
    .validate(function() {
        return this.age >= 18
    }, 'Age must be more or equal than 18!');

const Person = mongoose.model('Person', personSchema);


module.exports = Person;