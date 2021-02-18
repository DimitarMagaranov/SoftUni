// Take three integer numbers, representing the red, green and blue values of an RGB color, each within range [0…255]
// Return the same color in hexadecimal format as a string (e.g. '#FF9EAA')
// Return undefined if any of the input parameters are of invalid type or not in the expected range

const { expect } = require('chai');
const rgbToHexColor = require('./RGBtoHEX');

describe('rgbToHexColor', () => {
    it('converts red to hex', () => {
        expect(rgbToHexColor(255, 0, 0)).to.equal('#FF0000');
    });

    it('converts green to hex', () => {
        expect(rgbToHexColor(0, 255, 0)).to.equal('#00FF00');
    });

    it('converts blue to hex', () => {
        expect(rgbToHexColor(0, 0, 255)).to.equal('#0000FF');
    });

    it('returns undefined for string params', () => {
        expect(rgbToHexColor('a', 'b', 'c')).to.be.undefined;
    });

    it('returns undefined for negative red value', () => {
        expect(rgbToHexColor(-1, 0, 0)).to.be.undefined;
    });

    it('returns undefined for red value which is more than 255', () => {
        expect(rgbToHexColor(256, 0, 0)).to.be.undefined;
    });

    // test overloading
    it('returns undefined for negative green value', () => {
        expect(rgbToHexColor(0, -1, 0)).to.be.undefined;
    });

    it('returns undefined for negative blue value', () => {
        expect(rgbToHexColor(0, 0, -1)).to.be.undefined;
    });

    it('returns undefined for green value which is more than 255', () => {
        expect(rgbToHexColor(0, 256, 0)).to.be.undefined;
    });

    it('returns undefined for blue value which is more than 255', () => {
        expect(rgbToHexColor(0, 0, 256)).to.be.undefined;
    });

    it('converts 212, 217, 179 to hex', () => {
        expect(rgbToHexColor(212, 217, 179)).to.equal('#D4D9B3');
    });
});