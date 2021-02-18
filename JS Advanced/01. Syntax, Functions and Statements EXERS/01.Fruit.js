function solve(fruitType, weight, pricePerKg) {
    const fruit = fruitType.toString();
    const weightInKg = weight/1000;
    const neededMoney = pricePerKg * weightInKg;

    return `I need $${neededMoney.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`
}

console.log(solve('apple', 1563, 2.35));