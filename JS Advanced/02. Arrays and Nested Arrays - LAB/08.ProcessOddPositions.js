function solve(input) {
    let oddArray = [];

    for(let i = 1; i < input.length; i+=2) {
        oddArray.unshift(input[i] + input[i]);
    }

    return oddArray.join(' ');
}

console.log(solve([3, 0, 10, 4, 7, 3]));