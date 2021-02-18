class Bank {
    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer(customer) {
        if (this.allCustomers.some(x => x.personalId === customer.personalId)) {
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`)
        }

        customer.totalMoney = 0;
        customer.information = [];

        this.allCustomers.push(customer);
        return { firstName: customer.firstName, lastName: customer.lastName, personalId: customer.personalId };
    }

    depositMoney(personalId, amount) {
        let customer = this.allCustomers.find((c) => c.personalId === personalId);

        if (customer === undefined) {
            throw new Error(`We have no customer with this ID!`);
        }

        let result = '';

        customer.totalMoney += amount;
        customer.information.push(`${customer.firstName} ${customer.lastName} made deposit of ${amount}$!`);
        result = `${customer.totalMoney}$`;

        return result;
    }

    withdrawMoney(personalId, amount) {
        let customer = this.allCustomers.find((c) => c.personalId === personalId);

        if (customer === undefined) {
            throw new Error(`We have no customer with this ID!`);
        }

        if (customer.totalMoney < amount) {
            throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`);
        }

        let result = '';

        customer.totalMoney -= amount;
        customer.information.push(`${customer.firstName} ${customer.lastName} withdrew ${amount}$!`);
        result = `${customer.totalMoney}$`;

        return result;
    }

    customerInfo(personalId) {
        let customer = this.allCustomers.find((c) => c.personalId === personalId);

        if (customer === undefined) {
            throw new Error(`We have no customer with this ID!`);
        }

        let result = [];

        result.push(`Bank name: ${this._bankName}`);
        result.push(`Customer name: ${customer.firstName} ${customer.lastName}`);
        result.push(`Customer ID: ${customer.personalId}`);
        result.push(`Total Money: ${customer.totalMoney}$`);

        if (customer.information.length > 0) {
            result.push(`Transactions:`);

            for (let i = customer.information.length - 1; i >= 0; i--) {
                result.push(`${i + 1}. ${customer.information[i]}`);
            }
        }

        return result.join('\n');
    }
}

let bank = new Bank('SoftUni Bank');

console.log(bank.newCustomer({ firstName: 'Svetlin', lastName: 'Nakov', personalId: 6233267 }));
console.log(bank.newCustomer({ firstName: 'Mihaela', lastName: 'Mileva', personalId: 4151596 }));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596, 555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(4151596));
