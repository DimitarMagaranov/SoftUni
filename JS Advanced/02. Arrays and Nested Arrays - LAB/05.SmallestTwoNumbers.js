function solve(input) {
    let sortedArray = input.sort((a, b) => a - b);
    let smallestTwoNumbers = sortedArray.slice(0, 2);
    return smallestTwoNumbers.join(' ');
}

console.log(solve([30, 15, 50, 5]));