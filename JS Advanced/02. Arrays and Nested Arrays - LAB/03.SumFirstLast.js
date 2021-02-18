function solve(input) {
    const first = Number(input[0]);
    const last = Number(input[input.length - 1]);

    return first + last;
}

console.log(solve(['20', '30', '40']));