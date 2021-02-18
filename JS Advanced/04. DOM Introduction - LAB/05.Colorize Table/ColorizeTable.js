function colorize() {
    const rows = document.querySelectorAll('table tr');

    let index = 0;

    // for (let row of rows) {
    //     index++;
    //     if(index % 2 === 0) {
    //         row.style.background = 'teal';
    //     }
    // }

    for (let i = 1; i < rows.length; i+=2){
        rows[i].style.background = 'teal';
    }
}