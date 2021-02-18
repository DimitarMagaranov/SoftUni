function solve(input) {
    let resultArray = new Array;

    for(let i = 0; i <= input.length - 1; i+=2) {
        resultArray.push(input[i]);
    }

    return resultArray.join(' ');
}