const { expect } = require('chai');
const pizzUni = require('./PizzaPlace');

describe("pizzUni", function() {
    describe("makeAnOrder", function() {
        it("check if there is no orderedPizza", function() {
            const object = {
                orderedDrink: 'coke'
            };

            expect(function(){pizzUni.makeAnOrder(object)}).to.throw(Error);
        });

        it("check if there is orderedPizza", function() {
            const result = pizzUni.makeAnOrder({orderedPizza: 'pizza'});
            expect(result).to.equal('You just ordered pizza');
        });

        it("check if there is orderedDrink", function() {
            const result = pizzUni.makeAnOrder({orderedPizza: 'pizza', orderedDrink: 'coke'});
            expect(result).to.equal('You just ordered pizza and coke.');
        });
     });

     describe('getRemainingWork', function() {
        it('check if all orders are complete', function() {
            const array = [
                {pizzaName: 'Pizza1', status: 'ready'},
                {pizzaName: 'Pizza2', status: 'ready'},
                {pizzaName: 'Pizza3', status: 'ready'},
                {pizzaName: 'Pizza4', status: 'ready'}
            ];

            expect(pizzUni.getRemainingWork(array)).to.equal('All orders are complete!');
        });

        it('check if there are stipp preparing pizzas', function() {
            const array = [
                {pizzaName: 'Pizza1', status: 'preparing'},
                {pizzaName: 'Pizza2', status: 'ready'},
                {pizzaName: 'Pizza3', status: 'preparing'},
                {pizzaName: 'Pizza4', status: 'ready'}
            ];

            expect(pizzUni.getRemainingWork(array)).to.equal(`The following pizzas are still preparing: Pizza1, Pizza3.`);
        });
     });

     describe('orderType', function() {
         it('check if function returs right value if typeOfOrder is Carry Out', function() {
             expect(pizzUni.orderType(10, 'Carry Out')).to.equal(9);
         });

         it('check if function returs right value if typeOfOrder is Delivery', function() {
            expect(pizzUni.orderType(10, 'Delivery')).to.equal(10);
        });
     });
});
