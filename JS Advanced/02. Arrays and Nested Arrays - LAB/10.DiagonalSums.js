function solve(input) {
    let sum1 = 0;
    let sum2 = 0;

    for(let i = 0; i < input.length; i++) {
        sum1 += input[i][i];
        sum2 += input[input.length - 1 - i][i];
    }

    return `${sum1} ${sum2}`;
}

console.log(solve([[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]
   
   ));