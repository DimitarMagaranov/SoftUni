function solve(input) {
    const towns = {};
    const result = [];

    for(let item of input) {
        let [name, population] = item.split(' <-> ');
        population = Number(population);

        if(towns[name] != undefined) {
            population += towns[name];
        }

        towns[name] = population;
    }

    for(const key in towns) {
        result.push(`${key} : ${towns[key]}`)
    }

    return result.join('\n');
}

console.log(solve(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']

))

// `${obj.TownName} : ${obj.Population}`