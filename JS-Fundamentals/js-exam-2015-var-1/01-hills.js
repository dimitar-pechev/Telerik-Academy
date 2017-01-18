'use strict';

function solve(params) {
    let heights = params[0].split(' ').map(Number),
        count = 0,
        bestCount = -1;

    for (let i = 1; i < heights.length; i += 1) {
        count += 1;
        bestCount = Math.max(count, bestCount);

        if (heights[i] > heights[i - 1] && heights[i + 1] < heights[i]) {
            count = 0;
        }
    }

    console.log(bestCount);
}

solve(['5 1 7 4 8']);
solve(['5 1 7 6 3 6 4 2 3 8']);
solve(['10 1 2 3 4 5 4 3 2 1 10']);