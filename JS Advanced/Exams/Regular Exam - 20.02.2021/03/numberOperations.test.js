const { expect } = require('chai');
const numberOperations = require('./numberOperations');

describe("Tests …", function () {
    describe("powNumber", function () {
        it("check if func works correctly", function () {
            expect(numberOperations.powNumber(2)).to.equal(4);
        });
    });

    describe("numberChecker", function () {
        it("check if func throw error with NaN", function () {
            expect(function () { numberOperations.numberChecker('a') }).to.throw(Error);
        });

        it('check if number is under 100', function () {
            expect(numberOperations.numberChecker(99.9)).to.equal('The number is lower than 100!');
        })

        it('check if number is greater ot equal 100', function () {
            expect(numberOperations.numberChecker(100)).to.equal('The number is greater or equal to 100!');
            expect(numberOperations.numberChecker(100.1)).to.equal('The number is greater or equal to 100!');
        })
    });

    describe('sumArrays', function() {
        it('1', function() {
            const result = [2, 4, 6, 4, 5];
            expect(numberOperations.sumArrays([1,2,3,4,5], [1,2,3])).to.deep.equal(result);
        })
    })
});
