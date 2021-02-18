function solve(...params) {
    let number = Number(params[0]);
    let command;

    for (i = 1; i < params.length; i++) {
        command = params[i];

        if(command === 'chop'){
            number /= 2;
        }else if(command === 'dice'){
            number = Math.sqrt(number);
        }else if(command === 'spice'){
            number += 1;
        }else if(command === 'bake'){
            number *= 3;
        }else if(command === 'fillet'){
            number -= number * 0.2;
        }

        console.log(number);
    }
}

solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');