const { expect } = require('chai');
const HolidayPackage = require('./HolidayPackage');

describe('Tests', function () {
    describe('constructor', function () {
        it('check if constructor accepts parameters correctly', function () {
            const instance = new HolidayPackage('Plovdiv', 'Winter');
            expect(instance.destination).to.equal('Plovdiv');
            expect(instance.season).to.equal('Winter');
            expect(instance.insuranceIncluded).to.be.false;
            expect(instance.vacationers.length).to.equal(0);
        });
    });

    describe('seeterOfinsuranceIncludedProperty', function () {
        it('check if seeter throw error', function () {
            const instance = new HolidayPackage('Plovdiv', 'Winter');
            expect(function () { instance.insuranceIncluded = 'test' }).throw(Error);
        });

        it('check if setter working with right parameter', function () {
            const instance = new HolidayPackage('Plovdiv', 'Winter');
            instance.insuranceIncluded = true;
            expect(instance.insuranceIncluded).to.be.true;
        });
    });

    describe('addVacationer', function () {
        it('check if addVacationer throws error', function () {
            const instance = new HolidayPackage('Plovdiv', 'Winter');
            expect(function () { instance.addVacationer(0) }).to.throw(Error);
            expect(function () { instance.addVacationer(' ') }).to.throw(Error);
            expect(function () { instance.addVacationer('Pesho') }).to.throw(Error);
            expect(function () { instance.addVacationer('Pesho Peshev Peshev') }).to.throw(Error);
        });

        it('check if addVacationer works correctly', function () {
            const instance = new HolidayPackage('Plovdiv', 'Winter');
            instance.addVacationer('Pesho Peshev');
            expect(instance.vacationers.length).to.equal(1);
            expect(instance.vacationers[0]).to.equal('Pesho Peshev');
        });
    });

    describe('showVacationers', function () {
        it('check if vacationers array is not empty', function () {
            const instance = new HolidayPackage('Plovdiv', 'Winter');
            instance.addVacationer('Pesho Peshev');
            instance.addVacationer('Sasho Sashev');
            const result = "Vacationers:\nPesho Peshev\nSasho Sashev";
            expect(instance.showVacationers()).to.equal(result);
        });

        it('check if vacationers array is empty', function() {
            const instance = new HolidayPackage('Plovdiv', 'Winter');
            expect(instance.showVacationers()).to.equal("No vacationers are added yet");
        });
    });

    describe('generateHolidayPackage', function() {
        it('check if generateHolidayPackage throws error', function() {
            const instance = new HolidayPackage('Plovdiv', 'Winter');
            expect(function() {instance.generateHolidayPackage()}).to.throw(Error);
        });

        it('check if the method is working correctly in winter', function() {
            const instance = new HolidayPackage('Plovdiv', 'Winter');
            instance.addVacationer('Pesho Peshev');
            instance.addVacationer('Sasho Sashev');
            const result = "Holiday Package Generated\n" +
            "Destination: " + 'Plovdiv' + "\n" +
            "Vacationers:\nPesho Peshev\nSasho Sashev" + "\n" +
            "Price: " + '1000';

            expect(instance.generateHolidayPackage()).to.equal(result);
        });

        it('check if the method is working correctly in summer', function() {
            const instance = new HolidayPackage('Plovdiv', 'Summer');
            instance.addVacationer('Pesho Peshev');
            instance.addVacationer('Sasho Sashev');
            const result = "Holiday Package Generated\n" +
            "Destination: " + 'Plovdiv' + "\n" +
            "Vacationers:\nPesho Peshev\nSasho Sashev" + "\n" +
            "Price: " + '1000';

            expect(instance.generateHolidayPackage()).to.equal(result);
        });

        it('check if the method is working correctly in autumn', function() {
            const instance = new HolidayPackage('Plovdiv', 'Autumn');
            instance.addVacationer('Pesho Peshev');
            instance.addVacationer('Sasho Sashev');
            const result = "Holiday Package Generated\n" +
            "Destination: " + 'Plovdiv' + "\n" +
            "Vacationers:\nPesho Peshev\nSasho Sashev" + "\n" +
            "Price: " + '800';

            expect(instance.generateHolidayPackage()).to.equal(result);
        });

        it('check if the method is working correctly in summer with insurance', function() {
            const instance = new HolidayPackage('Plovdiv', 'Summer');
            instance.insuranceIncluded = true;
            instance.addVacationer('Pesho Peshev');
            instance.addVacationer('Sasho Sashev');
            const result = "Holiday Package Generated\n" +
            "Destination: " + 'Plovdiv' + "\n" +
            "Vacationers:\nPesho Peshev\nSasho Sashev" + "\n" +
            "Price: " + '1100';

            expect(instance.generateHolidayPackage()).to.equal(result);
        });
    });
});