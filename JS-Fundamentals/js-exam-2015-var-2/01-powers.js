'use strict';

// each 0 - with the absolute difference of its neighboring numbers
// all other even numbers - with the maximum of its neighboring numbers
// each 1 - with the sum of its neighboring numbers
// all other odd numbers - with the minimum of its neighboring numbers

function solve(params) {
    let count = +params[0].split(' ')[0],
        transformations = +params.shift().split(' ')[1],
        numbers = params[0].split(' ').map(Number),
        transformed = [];

    for (let i = 0, len = transformations; i < len; i += 1) {
        for (let j = 0; j < count; j += 1) {
            let prev = j - 1 >= 0 ? numbers[j - 1] : numbers[count - 1],
                next = j + 1 < count ? numbers[j + 1] : numbers[0];

            if (numbers[j] === 0) {
                transformed[j] = Math.abs(prev - next);
            } else if (numbers[j] % 2 === 0) {
                transformed[j] = Math.max(prev, next);
            } else if (numbers[j] === 1) {
                transformed[j] = prev + next;
            } else {
                transformed[j] = Math.min(prev, next);
            }
        }

        numbers = transformed;
        transformed = [];
    }

    console.log(numbers.reduce((a, b) => a + b));
}

solve([
    '5 1',
    '9 0 2 4 1'
]);
solve([
    '10 3',
    '1 9 1 9 1 9 1 9 1 9'
]);
solve([
    '10 10',
    '0 1 2 3 4 5 6 7 8 9'
]);