function solve(input) {
    let result = [];

    let [columns, ...table] = input;

    columns = splitLine(columns);

    let firstColumnName = columns[0];
    let secondColumnName = columns[1];
    let thirdColumnName = columns[2];

    for(let i = 0; i < table.length; i++) {
        let tokens = splitLine(table[i]);
        
        const town = tokens[0];
        const latitude = Number(tokens[1]).toFixed(2);
        const longtitude = Number(tokens[2]).toFixed(2);

        let obj = {
            [firstColumnName]: town,
            [secondColumnName]: parseFloat(latitude),
            [thirdColumnName]: parseFloat(longtitude),
        }

        result.push(obj);
    }

    return JSON.stringify(result);

    function splitLine(input) {
        return input.split('|').filter(x => x !== '').map(x => x.trimStart()).map(x => x.trimEnd());
    }
}

console.log(solve(['| Town | Latitude | Longitude |',
'| Veliko Turnovo | 43.0757 | 25.6172 |',
'| Monatevideo | 34.50 | 56.11 |']
))