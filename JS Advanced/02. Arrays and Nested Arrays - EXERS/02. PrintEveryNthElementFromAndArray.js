function solve(array, number) {

    return array.filter((el, i) => i % number === 0);

    /*const resultArray = [];

    for(let i = 0; i < array.length; i++) {
        if(i % number === 0) {
            resultArray.push(array[i]);
        }
    }

    return resultArray;*/
}

console.log(solve([
    '5',
    '20',
    '31',
    '4',
    '20'],
    2
))