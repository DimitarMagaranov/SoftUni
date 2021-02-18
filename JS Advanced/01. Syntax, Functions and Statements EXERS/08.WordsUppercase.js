function solve(input) {
    const matchArr = input.match(/\w+/g);
    let resultArr = new Array;
    let result = '';

    for(let i = 0; i<= matchArr.length - 1; i++) {
        resultArr.push(matchArr[i].toUpperCase());
    }

    result = resultArr[0];

    for(let i = 1; i <= resultArr.length - 1; i++) {
        result = `${result}` + ', ' + `${ resultArr[i]}`;
    }

    return result;
}

console.log(solve('Hi, how are you?'));