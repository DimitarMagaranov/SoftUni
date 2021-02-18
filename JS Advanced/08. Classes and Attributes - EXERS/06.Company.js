class Company {
    constructor(){
        this.departments = [];
    }

    addEmployee(username, salary, position, department) {
        if([...arguments].some(a => a === null || a === undefined || a === '') || salary < 0) {
            throw new Error('Invalid input!');
        }

        const person = {
            username,
            salary,
            position
        }

        let itExist = false;

        if(this.departments.length > 0) {
            for(let dep of this.departments) {
                if(dep.name === department) {
                    itExist = true;
                    dep.employees.push(person);
                    dep.totalSalary += salary;
                    return `New employee is hired. Name: ${person.username}. Position: ${person.position}`
                }
            }
        }

        if(itExist === false) {
            this.departments.push({
                name: department,
                employees: [person],
                totalSalary: salary,
                averageSalary() {
                    return this.totalSalary / this.employees.length;
                }
            });

            return `New employee is hired. Name: ${person.username}. Position: ${person.position}`
        }
    }

    bestDepartment() {
        this.departments = this.departments.sort((a, b) => b.averageSalary() - a.averageSalary());

        let result = `Best Department is: ${this.departments[0].name}\nAverage salary: ${this.departments[0].averageSalary().toFixed(2)}`;

        for(let person of this.departments[0].employees.sort((a, b) => b.salary - a.salary || a.username.localeCompare(b.username))) {
            result += `\n${person.username} ${person.salary} ${person.position}`;
        }

        return result;
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());