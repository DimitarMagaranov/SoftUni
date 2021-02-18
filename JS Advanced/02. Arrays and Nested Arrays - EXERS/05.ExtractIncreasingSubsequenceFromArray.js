/* 1-во решение:
function solve(array) {
const resultArray = [];

for(let i = 0; i < array.length; i++) {
    if(array[i] >= resultArray[resultArray.length - 1] || i === 0) {
        resultArray.push(array[i]);
    }
}

return resultArray;
}*/


/*2-ро решение:
function solve(array) {
return array.reduce(function(result, currValue, index, initialArray){
    if(currValue >= result[result.length - 1] || result.length === 0) {
        result.push(currValue);
    }
    return result;
}, [])
}*/


//3-то решение с подадена функция отвън:
function solve(array) {
    return array.reduce(extractEncreasing, []);

    function extractEncreasing(result, currValue, index, initialArray) {
        if (currValue >= result[result.length - 1] || result.length === 0) {
            return [...result, currValue];
        }
        return result;
    }
}

console.log(solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]
));