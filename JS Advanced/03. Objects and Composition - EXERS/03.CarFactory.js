function solve(input) {
    const carObj = {
        model: input.model,
        engine: getEngine(input.engine),
        carriage: getCarriage(),
        wheels: getWheels(input.wheelsize)
    };

    return carObj;

    function getEngine(power) {
        const engineTypes = {
            'Small engine': { power: 90, volume: 1800 },
            'Normal engine': { power: 120, volume: 2400 },
            'Monster engine': { power: 200, volume: 3500 }
        };

        // for (let engineType of Object.values(engineTypes)) {
        //     if (input.power <= engineType['power']) {
        //         return engineType;
        //     }
        // }

        return Object.values(engineTypes).find(x => x.power >= input.power);
    }

    function getCarriage() {
        return {
            type: input.carriage,
            color: input.color
        };
    }

    function getWheels(wheelSize) {
        if (wheelSize % 2 == 0) {
            wheelSize -= 1;
        }

        return Array(4).fill(wheelSize, 0, 4);
    }
}

console.log(solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}
))