// first way
function returnLargestNumber(a, b, c) {
    let result;

    if(a > b && a > c) {
        result = a;
    } else if(b > a && b > c) {
        result = b;
    } else {
        result = c;
    }

    console.log(`The largest number is ${result}.`);
}

returnLargestNumber(5, 7, 10);


//second way
function returnLargestNumberSecondWay(...params) {
    console.log(`The largest number is ${Math.max(...params)}.`);
}

returnLargestNumberSecondWay(5, 7, 20);