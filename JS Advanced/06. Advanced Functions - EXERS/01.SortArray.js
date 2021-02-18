function solve(array, command) {
    let sortedArray = [];

    sortArray(command);

    return sortedArray;

    function sortArray(command) {
        if(command === 'asc') {
            sortedArray = array.sort((a, b) => a - b);
        } else if (command === 'desc') {
            sortedArray = array.sort((a, b) => b - a);
        }
    }
}

function solve2(array, command) {
    let map = {
        'asc': (a, b) => a - b,
        'desc': (a, b) => b - a,
    };

    return array.sort(map[command]);
}

console.log(solve2([14, 7, 17, 6, 8], 'desc'));