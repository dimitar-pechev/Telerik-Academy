'use strict';

function solve(params) {
    let debris = params[1].split(';'),
        commands = params.slice(3),
        rows = params[0].split(' ')[0],
        cols = params[0].split(' ')[1];

    let board = [];
    for (let row = 0; row < rows; row += 1) {
        board.push([]);
        for (let col = 0; col < cols; col += 1) {
            board[row].push('-');
        }
    }

    for (let i = 0; i < debris.length; i += 1) {
        let debr = debris[i].split(' ');
        board[debr[0]][debr[1]] = 'x';
    }

    for (let i = 0; i < 4; i += 1) {
        board[0][i] = i;
        board[rows - 1][cols - 1 - i] = i + 4;
    }

    let cuki = 4,
        koceto = 4;
    for (let i = 0; i < commands.length; i += 1) {
        let currentCommand = commands[i].split(' ');
        if (currentCommand[0] === 'mv') {
            moveTank(currentCommand);
        } else {
            shoot(currentCommand);
        }
    }

    let loser = cuki > koceto ? 'Koceto' : 'Cuki';

    console.log(`${loser} is gg`);

    function moveTank(command) {
        let tankId = +command[1],
            tankCoords = {},
            moves = command[2],
            dir = command[3];

        for (let row = 0; row < rows; row += 1) {
            for (let col = 0; col < cols; col += 1) {
                if (board[row][col] === tankId) {
                    tankCoords = {
                        row,
                        col
                    };

                    break;
                }
            }
        }

        let deltaRow = dir === 'l' || dir === 'r' ? 0 : dir === 'u' ? -1 : 1,
            deltaCol = dir === 'u' || dir === 'd' ? 0 : dir === 'l' ? -1 : 1,
            row = tankCoords.row + deltaRow,
            col = tankCoords.col + deltaCol;

        for (let i = 0; i < moves; i += 1) {
            if (row < 0 || row >= rows || col < 0 || col >= cols) {
                break;
            }

            if (board[row][col] === '-') {
                board[row][col] = tankId;
                board[row - deltaRow][col - deltaCol] = '-';
            } else {
                break;
            }

            row = row + deltaRow;
            col = col + deltaCol;
        }
    }

    function shoot(command) {
        let tankId = +command[1],
            tankCoords = {},
            dir = command[2];

        for (let row = 0; row < rows; row += 1) {
            for (let col = 0; col < cols; col += 1) {
                if (board[row][col] === tankId) {
                    tankCoords = {
                        row,
                        col
                    };

                    break;
                }
            }
        }

        let deltaRow = dir === 'l' || dir === 'r' ? 0 : dir === 'u' ? -1 : 1,
            deltaCol = dir === 'u' || dir === 'd' ? 0 : dir === 'l' ? -1 : 1,
            row = tankCoords.row + deltaRow,
            col = tankCoords.col + deltaCol;

        while (true) {
            if (row < 0 || row >= rows || col < 0 || col >= cols) {
                break;
            } else if (board[row][col] === 'x') {
                board[row][col] = '-';
                break;
            } else if (board[row][col] !== 'x' && board[row][col] !== '-') {
                console.log(`Tank ${board[row][col]} is gg`);
                if (board[row][col] < 4) {
                    koceto -= 1;
                } else {
                    cuki -= 1;
                }

                board[row][col] = '-';
                break;
            }

            row = row + deltaRow;
            col = col + deltaCol;
        }
    }
}

solve([
    '5 5',
    '2 0;2 1;2 2;2 3;2 4',
    '13',
    'mv 7 2 l',
    'x 7 u',
    'x 0 d',
    'x 6 u',
    'x 5 u',
    'x 2 d',
    'x 3 d',
    'mv 4 1 u',
    'mv 4 4 l',
    'mv 1 1 l',
    'x 4 u',
    'mv 4 2 r',
    'x 2 d'
]);

solve([
    '10 10',
    '1 0;1 1;1 2;1 3;1 4;4 1;4 2;4 3;4 4',
    '8',
    'mv 4 9 u',
    'x 4 l',
    'x 4 l',
    'x 4 l',
    'x 0 r',
    'mv 0 9 r',
    'mv 5 1 r',
    'x 5 u'
]);