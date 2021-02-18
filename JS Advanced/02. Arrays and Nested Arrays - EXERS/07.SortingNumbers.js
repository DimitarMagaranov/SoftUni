function solve(array) {
    array.sort((a, b) => a - b);

    let resultArray = [];

    while(array.length !== 0) {
        resultArray.push(array.shift());
        resultArray.push(array.pop());
    }

    return resultArray;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));

[-3, 65, 1, 63, 3, 56, 18, 52, 31, 48]