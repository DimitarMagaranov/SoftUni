/*1-во решение:
function solve(array) {
    const result = [];

    array.sort((a, b) => {
        return a.localeCompare(b);
    });   

    for(let i = 0; i < array.length; i++) {
        result.push(`${i+1}.${array[i]}`);
    }

    return result.join('\n');
}*/

//2-ро решение:
function solve(array) {
    let result = array
        .sort((a, b) => a.localeCompare(b))
        .map((name, index) => {
            return `${index + 1}.${name}`;
        });

    return result.join('\n');
}

console.log(solve(["John", "Bob", "Christina", "Ema"]));