const { expect } = require('chai');
const PaymentPackage = require('./PaymentPackage');

describe('paymentPackage', () => {
    let instance = undefined;

    it('constructor', () => {
        instance = new PaymentPackage('Pesho', 100);
        expect(instance._name === 'Pesho').to.be.true;
        expect(instance._value === 100).to.be.true;
        expect(instance._VAT === 20).to.be.true;
        expect(instance._active === true).to.be.true;
    })

    it('name', () => {
        instance = new PaymentPackage('Pesho', 100);
        expect(function () { instance.name = 0 }).to.throw(Error);
        expect(function () { instance.name = '' }).to.throw(Error);
        instance.name = 'Mitio';
        expect(instance.name).to.equal('Mitio');
    })

    it('value', () => {
        instance = new PaymentPackage('Pesho', 100);
        expect(function () { instance.value = 's' }).to.throw(Error);
        expect(function () { instance.value = -1 }).to.throw(Error);
        instance.value = 1;
        expect(instance.value).to.equal(1);
        instance.value = 0;
        expect(instance.value).to.equal(0);
    })

    it('VAT', () => {
        instance = new PaymentPackage('Pesho', 100);
        expect(function () { instance.VAT = 's' }).to.throw(Error);
        expect(function () { instance.VAT = -1 }).to.throw(Error);
        instance.VAT = 10;
        expect(instance.VAT).to.equal(10);
    })

    it('active', () => {
        instance = new PaymentPackage('Pesho', 100);
        expect(instance.active).to.equal(true);
        instance.active = false;
        expect(instance.active).to.equal(false);
        expect(function () { instance.active = 1 }).to.throw(Error);
    })

    it('toString', () => {
        function getString(name, value, VAT = 20, active = true) {
            const output = [
                `Package: ${name}` + (active === false ? ' (inactive)' : ''),
                `- Value (excl. VAT): ${value}`,
                `- Value (VAT ${VAT}%): ${value * (1 + VAT / 100)}`
            ];

            return output.join('\n');
        }

        instance = new PaymentPackage('Pesho', 100);
        expect(getString('Pesho', 100)).to.equal(instance.toString());
        instance.VAT = 30;
        expect(getString('Pesho', 100, 30)).to.equal(instance.toString());
        instance.active = false;
        expect(getString('Pesho', 100, 30, false)).to.equal(instance.toString());
        instance.active = true;
        expect(getString('Pesho', 100, 30, true)).to.equal(instance.toString());
    })
})
