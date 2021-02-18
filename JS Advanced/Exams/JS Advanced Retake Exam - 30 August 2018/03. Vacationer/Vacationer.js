class Vacationer {
    constructor(vacationerNames, creditCardInfo) {
        this.fullName = vacationerNames;
        this.idNumber = this.generateIDNumber();
        this.creditCard = creditCardInfo;
        this.wishList = [];
    }

    get fullName() {
        return this._fullName;
    }

    set fullName(value) {
        const regex = /^[A-Z][a-z]+ [A-Z][a-z]+ [A-Z][a-z]+$/;
        let string = `${value[0]} ${value[1]} ${value[2]}`;

        if (value.length !== 3) {
            throw new Error('Name must include first name, middle name and last name');
        }

        if (!regex.test(string)) {
            throw new Error('Invalid full name');
        }

        this._fullName = {
            firstName: value[0],
            middleName: value[1],
            lastName: value[2]
        };
    }

    get creditCard() {
        return this._creditCard;
    }

    set creditCard(value) {
        if (value === undefined) {
            this._creditCard = {
                cardNumber: 1111,
                expirationDate: '',
                securityNumber: 111
            };
        } else {
            this._creditCard = {
                cardNumber: value[0],
                expirationDate: value[1],
                securityNumber: value[2]
            };
        }
    }

    generateIDNumber() {
        let id = 231 * this.fullName.firstName.charCodeAt(0) + 139 * this.fullName.middleName.length;
        const LastCharOfLastName = this.fullName.lastName[this.fullName.lastName.length - 1];

        switch (LastCharOfLastName) {
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                id += '8';
                break;

            default:
                id += '7';
        }

        return id;
    }

    addCreditCardInfo(input) {
        if (input.length < 3) {
            throw new Error('Missing credit card information');
        }

        if (typeof input[0] !== 'number' || typeof input[2] !== 'number') {
            throw new Error('Invalid credit card details');
        }

        this._creditCard.cardNumber = Number(input[0]);
        this._creditCard.expirationDate = input[1];
        this._creditCard.securityNumber = Number(input[2]);
    }

    addDestinationToWishList(destination) {
        if (this.wishList.includes(destination)) {
            throw new Error('Destination already exists in wishlist');
        }

        this.wishList.push(destination);
        this.wishList.sort((a, b) => a.length - b.length);
    }

    getVacationerInfo() {
        const result = [];

        result.push(`Name: ${this._fullName.firstName} ${this._fullName.middleName} ${this._fullName.lastName}`);
        result.push(`ID number: ${this.idNumber}`);
        const wishList = this.wishList.length === 0 ? 'empty' : this.wishList.join(', ');
        result.push(`Wishlist:\n${wishList}`);
        result.push('Credit Card:');
        result.push(`Card Number: ${this._creditCard.cardNumber}`);
        result.push(`Expiration Date: ${this._creditCard.expirationDate}`);
        result.push(`Security Number: ${this._creditCard.securityNumber}`);

        return result.join('\n');
    }
}

// Initialize vacationers with 2 and 3 parameters
let vacationer1 = new Vacationer(["Vania", "Ivanova", "Zhivkova"]);
let vacationer2 = new Vacationer(["Tania", "Ivanova", "Zhivkova"],
    [123456789, "10/01/2018", 777]);

// Should throw an error (Invalid full name)
try {
    let vacationer3 = new Vacationer(["Vania", "Ivanova", "ZhiVkova"]);
} catch (err) {
    console.log("Error: " + err.message);
}

// Should throw an error (Missing credit card information)
try {
    let vacationer3 = new Vacationer(["Zdravko", "Georgiev", "Petrov"]);
    vacationer3.addCreditCardInfo([123456789, "20/10/2018"]);
} catch (err) {
    console.log("Error: " + err.message);
}

vacationer1.addDestinationToWishList('Spain');
vacationer1.addDestinationToWishList('Germany');
vacationer1.addDestinationToWishList('Bali');

// Return information about the vacationers
console.log(vacationer1.getVacationerInfo());
console.log(vacationer2.getVacationerInfo());
