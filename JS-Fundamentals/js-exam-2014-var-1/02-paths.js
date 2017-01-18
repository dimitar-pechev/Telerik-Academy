'use strict';

function solve(params) {
    var rows = +params[0].split(' ')[0],
        cols = +params.shift().split(' ')[1],
        board = [];

    for (let i = 0; i < params.length; i += 1) {
        var currentRow = [];
        params[i].split(' ').forEach(x => {
            currentRow.push({
                dir: x,
                isSteppedOn: false
            });
        });

        board.push(currentRow);
    }

    var result = 1,
        row = 0,
        col = 0;
    while (true) {
        var deltaRow = board[row][col].dir[0] === 'd' ? 1 : -1,
            deltaCol = board[row][col].dir[1] === 'r' ? 1 : -1;
        row = row + deltaRow;
        col = col + deltaCol;

        if (row < 0 || row >= rows || col < 0 || col >= cols) {
            break;
        }

        if (board[row][col].isSteppedOn) {
            break;
        }

        board[row][col].isSteppedOn = true;
        result += Math.pow(2, row) + col;
    }

    if (row < 0 || row >= rows || col < 0 || col >= cols) {
        console.log('successed with ' + result);
    } else {
        console.log('failed at (' + row + ', ' + col + ')');
    }
}

solve([
    '3 5',
    'dr dl dr ur ul',
    'dr dr ul ur ur',
    'dl dr ur dl ur'
]);

solve([
    '3 5',
    'dr dl dl ur ul',
    'dr dr ul ul ur',
    'dl dr ur dl ur'
]);