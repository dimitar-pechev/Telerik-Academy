'use strict';

function solve(params) {
    params.shift();
    let numbers = params.map(Number),
        result = numbers[0] % 2 === 0 ? 0 : 1;

    for (let i = 0; i < numbers.length; i += 1) {
        if (numbers[i] % 2 !== 0) {
            result *= numbers[i];
            result = result % 1024;
        } else if (numbers[i] % 2 === 0) {
            result += numbers[i];
            result = result % 1024;
            i += 1;
        } 
    }

    console.log(result);
}

solve([
    '10',
    '1',
    '2',
    '3',
    '4',
    '5',
    '6',
    '7',
    '8',
    '9',
    '0'
]);
solve([
    '9',
    '9',
    '9',
    '9',
    '9',
    '9',
    '9',
    '9',
    '9',
    '9'
]);