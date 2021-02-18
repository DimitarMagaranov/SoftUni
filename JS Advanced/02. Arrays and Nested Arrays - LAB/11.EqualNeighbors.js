function solve(matrix) {
    let count = 0;

    for(let row = 0; row < matrix.length; row++) {
        for( let col = 0; col < matrix[0].length; col++) {
            if(row === matrix.length - 1) {
                if(matrix[row][col] === matrix[row][col + 1]) {
                    count++;
                }
            } else if(col === matrix[0].length - 1) {
                if(matrix[row][col] === matrix[row + 1][col]) {
                    count++;
                }
            } else {
                if(matrix[row][col] === matrix[row][col + 1]) {
                    count++;
                }
    
                if(matrix[row][col] === matrix[row + 1][col]) {
                    count++;
                }
            }
        }
    }

    return count;
}

console.log(solve([['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]

));