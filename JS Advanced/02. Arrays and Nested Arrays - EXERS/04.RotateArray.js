function solve(array, rotateCount) {
    for(let i = 0; i < rotateCount; i++) {
        array.unshift(array.pop());
    }

    return array.join(' ');
}

console.log(solve(['1', 
'2', 
'3', 
'4'], 
200001543
))