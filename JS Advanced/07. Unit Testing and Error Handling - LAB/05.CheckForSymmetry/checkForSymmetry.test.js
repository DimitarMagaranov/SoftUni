const { expect } = require('chai');
const isSymmetryc = require('./checkForSymetry');

describe('check', () => {
    // Take an array as argument
    it('returns true with valid symmetryc input', () => {
        expect(isSymmetryc([1, 1])).to.be.true;
    });

    it('returns false with valid non-symmetryc input', () => {
        expect(isSymmetryc([1, 2])).to.be.false;
    });

    // Return false for any input that isn't of the correct type
    it('returns false for invalid input', () => {
        expect(isSymmetryc('a')).to.be.false;
    });

    it('returns false for array with diference types', () => {
        expect(isSymmetryc(['1', 1])).to.be.false;
    });

    // Test overloading
    it('returns true for valid symmetric odd-element array', () => {
        expect(isSymmetryc([1,1,1])).to.be.true;
    });

    it('returns true for valid symmetric string array', () => {
        expect(isSymmetryc(['a', 'a'])).to.be.true;
    });

    it('returns false for valid non-symmetric string array', () => {
        expect(isSymmetryc(['a', 'b'])).to.be.false;
    });
});