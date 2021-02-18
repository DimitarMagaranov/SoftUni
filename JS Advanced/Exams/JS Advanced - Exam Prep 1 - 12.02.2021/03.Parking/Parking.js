class Parking {
    constructor(capacity) {
        this.capacity = capacity;
        this.vehicles = [];
        this.sortedVehicles = [];
    }

    addCar(carModel, carNumber) {
        if (this.capacity === 0) {
            throw new Error('Not enough parking space.');
        }

        const car = {
            carModel,
            carNumber,
            payed: false
        };

        this.vehicles.push(car);
        this.sortedVehicles.push(car);
        this.capacity--;
        return `The ${carModel}, with a registration number ${carNumber}, parked.`;
    }

    removeCar(carNumber) {
        const car = this.vehicles.find(x => x.carNumber === carNumber);

        if (car === undefined) {
            throw new Error("The car, you're looking for, is not found.");
        }

        if (car.payed === false) {
            throw new Error(`${car.carNumber} needs to pay before leaving the parking lot.`);
        }

        const index = this.vehicles.indexOf(car);
        this.vehicles.splice(index, 1);
        return `${carNumber} left the parking lot.`;
    }

    pay(carNumber) {
        const car = this.vehicles.find(x => x.carNumber === carNumber);

        if (car === undefined) {
            throw new Error(`${carNumber} is not in the parking lot.`);
        }

        if (car.payed === true) {
            throw new Error(`${carNumber}` + "'s driver has already payed his ticket.");
        }

        this.vehicles.find(x => x.carNumber === carNumber).payed = true;
        this.sortedVehicles.find(x => x.carNumber === carNumber).payed = true;
        return `${carNumber}` + "'s driver successfully payed for his stay.";
    }

    getStatistics(carNumber) {
        if (carNumber === undefined) {
            const resultArray = [];

            resultArray.push(`The Parking Lot has ${this.capacity} empty spots left.`);

            this.sortedVehicles.sort((a, b) => a.carModel.localeCompare(b.carModel));

            for (let i = 0; i < this.sortedVehicles.length; i++) {
                const payedResult = this.sortedVehicles[i].payed === true ? 'Has payed' : 'Not payed';
                resultArray.push(`${this.sortedVehicles[i].carModel} == ${this.sortedVehicles[i].carNumber} - ${payedResult}`);
            }

            return resultArray.join('\n');
        } else {
            const car = this.sortedVehicles.find(x => x.carNumber === carNumber);
            const payedResult = car.payed === true ? 'Has payed' : 'Not payed';

            return `${car.carModel} == ${car.carNumber} - ${payedResult}`;
        }
    }
}

const parking = new Parking(12);

console.log(parking.addCar("Volvo t600", "TX3691CA"));
console.log(parking.getStatistics());

console.log(parking.pay("TX3691CA"));
console.log(parking.removeCar("TX3691CA"));
