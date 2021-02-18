function solve(input) {
    let result = [];
    let dictionary = {};

    while (input.length > 0) {
        let part = input.shift();
        let tokens = part.split(' : ');
        part = `${tokens[0]}: ${tokens[1]}`;

        let firstLetter = part.charAt(0);

        if (dictionary[firstLetter] == undefined) {
            dictionary[firstLetter] = [];
        }

        dictionary[firstLetter].push(part);

        dictionary = Object.keys(dictionary).sort().reduce(
            (obj, key) => {
                obj[key] = dictionary[key];
                return obj;
            },
            {}
        );
    }

    for (const [key, value] of Object.entries(dictionary)) {
        const letter = key;
        const array = value.sort((a, b) => a.localeCompare(b));

        result.push(letter);

        for (let item of array) {
            result.push(`  ${item}`);
        }
    }

    return result.join('\n');
}

console.log(solve(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
))