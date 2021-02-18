function solve(juicesArray) {
    const juices = {};
    const result = {};
    const quantityForOneBottle = 1000;

    for(let juice of juicesArray) {
        const tokens = juice.split(' => ');
        const name = tokens[0];
        let quantity = Number(tokens[1]);

        if(juices[name]) {
            juices[name] += quantity;

            while(juices[name] >= quantityForOneBottle) {
                juices[name] -= quantityForOneBottle;

                result[name] = result[name] ? result[name] + 1 : 1;
            }
        } else {
            if(quantity >= quantityForOneBottle) {
                result[name] = 0;

                while(quantity >= quantityForOneBottle) {
                    quantity -= quantityForOneBottle;
                    result[name]++;
                }
            }

            juices[name] = quantity;
        }
    }

    let stringResult = '';

    for (let key in result) {
        let value = result[key];
        stringResult += `${key} => ${value}\n`;
    }

    return stringResult;
}

console.log(solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']
))