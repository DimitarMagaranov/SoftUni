class Person {
    constructor(name) {
        this.name = name;
    }

    sayHi() {
        console.log(`${this.name} says hi!`);
    }
}

class Employee extends Person {
    constructor(name, salary) {
        super(name);
        this.salary = salary;
    }

    collectSalary() {
        this.sayHi();
        console.log(`${this.name} collected ${this.salary}`);
    }
}

const myEmpl = new Employee('Pesho', 500);
myEmpl.collectSalary();