'use strict';

function solve(params) {
    let heights = params[0].split(' ').map(Number);

    let result = 0;
    for (let i = 1; i < heights.length - 1; i += 1) {
        if (heights[i] < heights[i - 1] && heights[i] < heights[i + 1]) {
            if (i - 2 >= 0 && i + 2 <= heights.length - 1 && heights[i - 1] > heights[i - 2] && heights[i + 1] > heights[i + 2]) {
                result += heights[i];
            }
        }
    }

    console.log(result);
}

solve([
    '53 20 1 30 2 40 3 10 1'
]);