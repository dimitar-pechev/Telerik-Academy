'use strict';

function solve(params) {
    let heights = params[0].split(' ').map(Number),
        peaks = [];

    for (let i = 1, len = heights.length - 1; i < len; i += 1) {
        if (heights[i] > heights[i - 1] && heights[i] > heights[i + 1]) {
            peaks.push(i);
        }
    }

    peaks.unshift(0);
    peaks.push(heights.length - 1);

    let biggestSum = Number.MIN_VALUE,
        sum = 0;
    for (let i = 0; i < peaks.length - 1; i += 1) {
        for (let j = peaks[i]; j <= peaks[i + 1]; j += 1) {
            sum += heights[j];
        }

        biggestSum = Math.max(sum, biggestSum);
        sum = 0;
    }

    console.log(biggestSum);
}

solve(['5 1 7 4 8']);
solve(['5 1 7 6 5 6 4 2 3 8']);