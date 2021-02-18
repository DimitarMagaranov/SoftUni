function solve(number) {
    const inputAsString = number.toString();
    let booleanResult = true;
    const firstLetter = inputAsString[0];
    let numberResult = 0;

    for(i = 0; i <= inputAsString.length - 1; i++) {
        if(firstLetter !== inputAsString[i]) {
            booleanResult = false;
        }

        numberResult += Number(inputAsString[i]);
    }

    return `${booleanResult}\n${numberResult}`;
}

console.log(solve(2222222));
console.log(solve(1234));