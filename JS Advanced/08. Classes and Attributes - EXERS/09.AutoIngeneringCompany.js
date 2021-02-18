function solve(input) {
    const companies = {};
    let result = [];

    for (let line of input) {
        const tokens = line.split(' | ');
        const brand = tokens[0];
        const model = tokens[1];
        const producedCarsCount = Number(tokens[2]);
        let isFounded = false;

        if (companies[brand]) {
            for (let key in companies) {
                const models = companies[key];

                for (let obj of models) {
                    if (obj.carModel === model) {
                        isFounded = true;
                        obj.carCount += producedCarsCount;
                    }
                }
            }

            if(isFounded === false) {
                companies[brand].push({ carModel: model, carCount: producedCarsCount });
            }
        } else {
            companies[brand] = [{ carModel: model, carCount: producedCarsCount }];
        }
    }

    for(const [key, value] of Object.entries(companies)) {
        let currBrandWithModels = `${key}`;

        for(let modelObj of value) {
            currBrandWithModels += `\n###${modelObj.carModel} -> ${modelObj.carCount}`;
        }

        result.push(currBrandWithModels);
    }

    return result.join('\n');
}

console.log(solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']
))