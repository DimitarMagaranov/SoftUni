function solve(speed, area) {
    let awolledKmH = 0;
    let speeding = 0;
    let status;
    let result;

    switch (area) {
        case 'city':
            awolledKmH = 50;
            speeding = speed - awolledKmH;

            getResult(speeding);
            break;

        case 'residential':
            awolledKmH = 20;
            speeding = speed - awolledKmH;

            getResult(speeding);
            break;

        case 'interstate':
            awolledKmH = 90;
            speeding = speed - awolledKmH;

            getResult(speeding);
            break;

        case 'motorway':
            awolledKmH = 130;
            speeding = speed - awolledKmH;

            getResult(speeding);
            break;
    }

    function getResult(speeding) {
        if (speeding <= 0) {
            result = `Driving ${speed} km/h in a ${awolledKmH} zone`;
        } else {
            if (speeding <= 20) {
                status = 'speeding';
            } else if (speeding <= 40) {
                status = 'excessive speeding';
            } else if (speeding > 40) {
                status = 'reckless driving';
            }

            result = `The speed is ${speeding} km/h faster than the allowed speed of ${awolledKmH} - ${status}`;
        }
    }

    return result;
}

console.log(solve(40, 'city'));
console.log(solve(21, 'residential'));
console.log(solve(120, 'interstate'));
console.log(solve(200, 'motorway'));