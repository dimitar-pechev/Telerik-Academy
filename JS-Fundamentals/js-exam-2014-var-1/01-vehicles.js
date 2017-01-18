'use strict';

function solve(params) {
    var wheels = params.map(Number)[0],
        count = 0,
        vehiclesTypes = [10, 4, 3];
    
    for (var i = 0; i < wheels; i += 1) {
        for (var j = 0; j < wheels; j += 1) {
            for (var k = 0; k < wheels; k += 1) {
                if (i * vehiclesTypes[0] + j * vehiclesTypes[1] + k * vehiclesTypes[2] === wheels) {
                    count += 1;
                }
            }
        }
    }

    console.log(count);
}

solve(['7']);
solve(['10']);
solve(['40']);