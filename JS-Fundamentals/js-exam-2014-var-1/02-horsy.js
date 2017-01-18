'use strict';

function solve(params) {
    var rows = +params[0].split(' ')[0],
        cols = +params.shift().split(' ')[1],
        board = params,
        boolArr = [];

    for (let i = 0; i < board.length; i += 1) {
        boolArr.push([]);
        for (let j = 0; j < board[0].length; j += 1) {
            boolArr[i].push(false);
        }
    }

    var result = Math.pow(2, rows - 1) - (cols - 1),
        jumps = 1,
        moves = [
            [-2, 1], [-1, 2], [1, 2], [2, 1], [2, -1], [1, -2], [-1, -2], [-2, -1]
        ],
        row = rows - 1,
        col = cols - 1;
    boolArr[rows - 1][cols - 1] = true;

    while (true) {
        var currentRow = row;
        row = row + moves[board[row][col] - 1][0];
        col = col + moves[board[currentRow][col] - 1][1];

        if (row < 0 || row >= rows || col < 0 || col >= cols) {
            break;
        }

        if (boolArr[row][col]) {
            break;
        }

        boolArr[row][col] = true;

        result += Math.pow(2, row) - col;
        jumps += 1;
    }

    if (row < 0 || row >= rows || col < 0 || col >= cols) {
        console.log('Go go Horsy! Collected ' + result + ' weeds');
    } else {
        console.log('Sadly the horse is doomed in ' + jumps + ' jumps');
    }
}

solve([
    '3 5',
    '54561',
    '43328',
    '52388'
]);
solve([
    '3 5',
    '54361',
    '43326',
    '52188'
]);
solve(['3 85',
    '4228545871361134531572665621474876581741275177843485425355845655786786648413761278158',
    '1181657584763731717511721264164454722344645442681745185234814452255462867574787853385',
    '7463838874877143724175233317747581136752233532656667528668843246726138585172833761417'
]);