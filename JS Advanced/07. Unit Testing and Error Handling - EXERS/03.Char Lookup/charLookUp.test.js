const { expect } = require('chai');
const lookupChar = require('./charLookUp');

describe('lookupChar', () => {
    it('retursn undefined when the passed string is not of type string', () => {
        expect(lookupChar(5,5)).to.be.undefined;
    });

    it('retursn undefined when the passed index is not a integer', () => {
        expect(lookupChar('Mitko', 2.34)).to.be.undefined;
    });

    it('retursn undefined when the passed index is not of type number', () => {
        expect(lookupChar('Mitko','s')).to.be.undefined;
    });

    it('returns incorect index if string length is <= of the passed index', () => {
        expect(lookupChar("Mitko", 5)).to.equal('Incorrect index');
    });

    it('returns incorect index if index is less than zero', () => {
        expect(lookupChar("Mitko", -1)).to.equal('Incorrect index');
    });

    it('returns the right char', () => {
        expect(lookupChar('Mitko', 0)).to.equal('M');
    });

    it('returns the right char', () => {
        expect(lookupChar('Mitko', 3)).to.equal('k');
    });
});