function getAggResult(input) {
    let result1 = 0
    let result2 = 0;
    let result3 = '';

    for(i = 0; i <= input.length - 1; i++) {
        let currNum = Number(input[i]);
        result1 = result1 + currNum;
        result2 = result2 + 1 / currNum;
        result3 = result3 + input[i];
    }

    console.log(result1);
    console.log(result2);
    console.log(result3);
}

getAggResult([1, 2, 3]);