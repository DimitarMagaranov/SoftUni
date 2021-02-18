// class Person {
//     constructor(firstName, lastName) {
//         this.firstName = firstName;
//         this.lastName = lastName;
//     }

//     get fullName() {
//         return `${this.firstName} ${this.lastName}`;
//     }

//     set fullName(value) {
//         [this.firstName, this.lastName] = value.split(' ');
//     }
// }

function Person(firstName, lastName) {
    this.firstName = firstName;
    this.lastName = lastName;

    Object.defineProperty(this, 'fullName', {
        enumerable: true,
        get: function() {
            return `${this.firstName} ${this.lastName}`;
        },
        set: function(value) {
            [this.firstName, this.lastName] = value.split(' ');
        }
    });
}

const myPerson = new Person('Peter', 'Johnson');
console.log(myPerson);