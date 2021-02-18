function solve(input) {
    const result = [];

    for(let item of input) {
        if(item < 0) {
            result.unshift(item);
        } else {
            result.push(item);
        }
    }

    return result.join('\n');
}

console.log(solve([3, -1, 0, -2]));