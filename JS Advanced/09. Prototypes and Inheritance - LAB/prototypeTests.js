function Person(firstname, lastName) {
    this.firstName = firstname;
    this.lastName = lastName;
}

Person.prototype.write = function(message) {
    console.log(`Person wrote: ${message}`);
}

const myPerson = new Person('John', 'Abbot');

console.log(myPerson);

myPerson.write('Hello, World!');

console.log(myPerson.hasOwnProperty('write'));