const { expect } = require('chai');
const mathEnforcer = require('./mathEnforcer');

describe('mathEnforcer', () => {
    describe('addFive', () => {
        it('returns undefined if the passed number to addFive is not a number', () => {
            expect(mathEnforcer.addFive('s')).to.be.undefined;
        });

        it('returns NaN dor addFive', () => {
            expect(mathEnforcer.addFive(NaN)).to.be.NaN;
        })

        it('returns valid value for addFive', () => {
            expect(mathEnforcer.addFive(0)).to.equal(5);
            expect(mathEnforcer.addFive(-3)).to.equal(2);
            expect(mathEnforcer.addFive(3)).to.equal(8);
            expect(mathEnforcer.addFive(3.75)).to.equal(8.75);
        })
    });

    describe('subtractTen', () => {
        it('returns undefined if the passed number to subtractTen is not a number', () => {
            expect(mathEnforcer.subtractTen('s')).to.be.undefined;
        });

        it('returns NaN dor subtractTen', () => {
            expect(mathEnforcer.subtractTen(NaN)).to.be.NaN;
        })

        it('returns valid value for subtractTen', () => {
            expect(mathEnforcer.subtractTen(0)).to.equal(-10);
            expect(mathEnforcer.subtractTen(-3)).to.equal(-13);
            expect(mathEnforcer.subtractTen(13)).to.equal(3);
            expect(mathEnforcer.subtractTen(13.75)).to.equal(3.75);
        })
    });

    describe('sum', () => {
        it('returns undefined if the first parameter is not a number', () => {
            expect(mathEnforcer.sum('s', 1)).to.be.undefined;
        });

        it('returns NaN for first parameter', () => {
            expect(mathEnforcer.sum(NaN, 5)).to.be.NaN;
        });

        it('returns undefined if the second parameter is not a number', () => {
            expect(mathEnforcer.sum(1, 's')).to.be.undefined;
        });

        it('returns NaN for second parameter', () => {
            expect(mathEnforcer.sum(5, NaN)).to.be.NaN;
        })

        it('returns valid value for sum', () => {
            expect(mathEnforcer.sum(1, 2)).to.equal(3);
            expect(mathEnforcer.sum(-1, 2)).to.equal(1);
            expect(mathEnforcer.sum(-1, -2)).to.equal(-3);
            expect(mathEnforcer.sum(2, -1)).to.equal(1);
            expect(mathEnforcer.sum(0.33, 0.33)).to.equal(0.66);
        });
    });
})