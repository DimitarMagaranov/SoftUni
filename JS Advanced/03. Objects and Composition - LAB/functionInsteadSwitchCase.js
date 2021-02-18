function solve(...params) {
    let number = Number(params[0]);
    let command;

    for (i = 1; i < params.length; i++) {
        command = params[i];

        let functionLibrary = {
            chop() {number /= 2},
            dice() {number = Math.sqrt(number)},
            spice() {number += 1},
            bake() {number *= 3},
            fillet() {number -= number * 0.2}
        }

        functionLibrary[command]();

        console.log(number);
    }
}