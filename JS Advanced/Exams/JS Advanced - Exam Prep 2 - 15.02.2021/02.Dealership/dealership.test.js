const { expect } = require('chai');
const dealership = require('./dealership');

describe('Tests', function () {
    describe('newCarCost', function () {
        it('check if its passed old car', function () {
            expect(dealership.newCarCost('Audi A4 B8', 30000)).to.equal(15000);
        });

        it('check if its passed new car', function () {
            expect(dealership.newCarCost('Audi A7', 30000)).to.equal(30000);
        });
    });

    describe('carEquipment', function () {
        it('single element, single pick', () =>  {
            expect(dealership.carEquipment(['a'], [0])).to.deep.equal(['a']);
        });

        it('three elements, 2 picks', () =>  {
            expect(dealership.carEquipment(['a', 'b', 'c'], [0, 2])).to.deep.equal(['a', 'c']);
        });

        it('three elements, 1 pick', () =>  {
            expect(dealership.carEquipment(['a', 'b', 'c'], [1])).to.deep.equal(['b']);
        });
    });

    describe('euroCategory', function () {
        it('add 5% discount with category 4', function () {
            const total = 15000 - (15000 * 0.05);
            expect(dealership.euroCategory(4)).to.equal(`We have added 5% discount to the final price: ${total}.`);
        });

        it('add 5% discount with category 5', function () {
            const total = 15000 - (15000 * 0.05);
            expect(dealership.euroCategory(4)).to.equal(`We have added 5% discount to the final price: ${total}.`);
        });

        it('less than 4', function () {
            expect(dealership.euroCategory(3)).to.equal('Your euro category is low, so there is no discount from the final price!');
        })
    })
})