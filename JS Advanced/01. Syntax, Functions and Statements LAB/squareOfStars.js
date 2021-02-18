function getSquareOfStars(input) {
    let square;

    if(input == undefined) {
        for(i = 0; i < 5; i++){
            console.log('* * * * *');
        }
    } else {
        let number = Number(input);

        for(i = 0; i < number; i++) {
            let line = '*';

            for(j = 0; j < number - 1; j++) {
                line = line + ' *';
            }

            console.log(line);
        }
    }
}

getSquareOfStars();