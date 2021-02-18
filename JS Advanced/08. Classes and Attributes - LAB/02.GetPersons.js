function returnPersons() {
    class Person {
        constructor(firstName, lastName, age, email) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.email = email;
        }
    
        toString() {
            return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`;
        }
    }
    
    let Anna = new Person('Anna', 'Simpson', 22, 'anna@yahoo.com');
    let SoftUni = new Person('SoftUni');
    let Stephan = new Person('Stephan', 'Johnson', 25);
    let Gabriel = new Person('Gabriel', 'Peterson', 24, 'g.p@gmail.com');
    
    let array = [];
    array.push(Anna);
    array.push(SoftUni);
    array.push(Stephan);
    array.push(Gabriel);
    
    return array;
}