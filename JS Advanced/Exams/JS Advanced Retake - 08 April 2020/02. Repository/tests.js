let { Repository } = require("./solution.js");
const { expect } = require('chai');

describe("Tests …", function () {
    const props = { name: "string", age: "number", birthday: "object" };
    let instance = undefined;

    describe('constructor', () => {
        instance = new Repository(props);

        it('check props', () => {
            expect(instance.props === props).to.be.true;
        })
    })

    describe("Count", function () {
        it("Check returned count if is right", function () {
            expect(instance.count).to.equal(0);

            instance = new Repository(props);
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            instance.add(entity);
            expect(instance.count).to.equal(1);

            let secondEntity = {
                name: "Gosho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            instance.add(secondEntity);
            expect(instance.count).to.equal(2);
        });
    });

    describe('add', function() {
        it('check if the returned id is correct', function() {
            instance = new Repository(props);

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            expect(instance.add(entity)).to.equal(0);
            expect(instance.add(entity)).to.equal(1);
        });

        it('check if the add works correctly', function() {
            instance = new Repository(props);

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            let id = instance.add(entity);
            expect(instance.data.get(id)).to.equal(entity);
        })
    });

    describe('Get', function () {
        it('Check if returned entity is the right one', function () {
            instance = new Repository(props);
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            instance.add(entity);
            expect(instance.getId(0)).to.equal(entity);

            let secondEntity = {
                name: "Gosho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            instance.add(secondEntity);
            expect(instance.getId(1)).to.equal(secondEntity);
        });

        it('If getId returns error correctly', function() {
            instance = new Repository(props);
            expect(function(){instance.getId(0)}).to.throw(Error);

            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            instance.add(entity);
            expect(function(){instance.getId(1)}).to.throw(Error);
        })
    });

    describe('_validate', function() {
        it('check if returns error', function() {
            instance = new Repository(props);
            let entity = {
                username: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            expect(function(){instance.add(entity)}).to.throw(Error);

            let entity4 = {
                name: 20,
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            expect(function(){instance.add(entity4)}).to.throw(Error);
        })
    })

    describe('del', function() {
        it('check if del returns Error', function() {
            instance = new Repository(props);
            expect(function(){instance.del(0)}).to.throw(Error);
        })

        it('check if del is working correctly', function() {
            instance = new Repository(props);
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            instance.add(entity);
            expect(instance.data.size).to.equal(1);
            instance.del(0);
            expect(instance.data.size).to.equal(0);
        })
    })

    describe('update', function() {
        it('check if update returns Error', function() {
            instance = new Repository(props);
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            instance.add(entity);

            let newEntity = {
                name: "Pesho",
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            expect(function(){instance.update(1, newEntity)}).to.throw(Error);
            
            instance.update(0, newEntity);
            expect(instance.getId(0)).to.equal(newEntity);
        })
    })
});
