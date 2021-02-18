function solve(matrix) {
    
    let rowSums = [];
    // let rowSums = matrix.map((el) => el.reduce((a, b) => a + b), 0);

    for (let row = 0; row < matrix.length; row++) {
        let rowSum = matrix[row].reduce((result, currValue) => (result + currValue), 0);

        rowSums.push(rowSum);
    }

    let colSums = [];
    // let colSums = arr[0].map((_, col) => arr.map((row) => row[col])).map(row => row.reduce((a, b) => a + b));

    for (let col = 0; col < matrix.length; col++) {
        let newRow = [];
        for (let row = 0; row < matrix.length; row++) {
            newRow.push(matrix[row][col])
        }
 
        let sum = newRow.reduce((result, curr) => (result + curr), 0);
        colSums.push(sum);
    }

    return rowSums.concat(colSums).every((el, i, arr) => el === arr[0]);
}

console.log(solve([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
))