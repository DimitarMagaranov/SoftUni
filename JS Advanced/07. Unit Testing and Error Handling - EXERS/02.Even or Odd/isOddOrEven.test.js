const { expect } = require('chai');
const isOddOrEven = require('./isOddOrEven');

describe('isOddOrEven', () => {
    it('returns undefined if input is not a string', () => {
        expect(isOddOrEven(5)).to.be.undefined;
    });

    it('returns even result if the length of the input string is even', () => {
        expect(isOddOrEven('asdf')).to.equal('even');
    });

    it('returns odd result if the length of the odd string is odd', () => {
        expect(isOddOrEven('asf')).to.equal('odd');
    });
});