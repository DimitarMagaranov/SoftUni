function solve(commandsArray) {
    const resultArray = [];
    let initialNumber = 1;

    for(let i = 0; i < commandsArray.length; i++) {
        
        

        if(commandsArray[i] === 'add') {
            resultArray.push(initialNumber);
        } else if(commandsArray[i] === 'remove') {
            resultArray.pop();
        }

        initialNumber++;
    }

    return(resultArray.length != 0 ? resultArray.join('\n') : 'Empty');
}

console.log(solve(['add', 
'add', 
'remove', 
'add', 
'add']
));