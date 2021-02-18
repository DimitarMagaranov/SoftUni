function solve(arrayInput) {
    let result = [];

    for(let person of arrayInput) {
        let [name, level, items] = person.split(' / ');
        level = Number(level);

        items = items ? items.split(', ') : [];

        const personObj = {
            name,
            level,
            items
        };

        result.push(personObj);
    }

    return JSON.stringify(result);
}

console.log(solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
))