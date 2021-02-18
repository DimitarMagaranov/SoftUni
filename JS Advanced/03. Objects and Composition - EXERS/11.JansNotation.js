function solve(input) {
    let operands = [];
    let operators = [];


    for(let i = 0; i < input.length; i ++) {
        if (typeof input[i] === 'number') {
            operands.push(input[i]);
        }
        else {
            operators.push(input[i]);
        }
    }

    while(true) {
        if(operands.length > 1) {
            let second = operands.pop();
            let first = operands.pop();

            if(operators.length > 0) {
                let operator = operators[0];
                operators.shift();

                let result = getResult(first, second, operator);

                operands.push(result);
            }
        }
        
        if(operands.length === 1 && operators.length === 0) {
            console.log(operands[0]);
            break;
        } else if(operands.length > 1 && operators.length === 0) {
            console.log('Error: too many operands!')
            break;
        }
        else if (operands.length <= 1 && operators.length > 0) {
            console.log('Error: not enough operands!');
            break;
        }
    }

    function getResult(first, second, operator) {
        if (operator === '+') {
            return first + second;
        } else if(operator === '-') {
            return first - second; 
        } else if(operator === '*') {
            return first * second;
        } else if(operator === '/') {
            return first / second;
        }
    }
}

solve([15,
    '/']
   )