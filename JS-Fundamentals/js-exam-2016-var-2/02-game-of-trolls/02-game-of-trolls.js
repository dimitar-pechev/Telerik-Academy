'use strict';

function solve(params) {
    let rows = params[0].split(' ')[0],
        cols = params[0].split(' ')[1],
        wboupCoords = params[1].split(';')[0].split(' ').map(Number),
        nbslbubCoords = params[1].split(';')[1].split(' ').map(Number),
        lsjtujzbCoords = params[1].split(';')[2].split(' ').map(Number),
        commands = params.slice(2),
        board = [],
        isNTrapped = false,
        isWTrapped = false;

    for (let row = 0; row < rows; row += 1) {
        board.push([]);
        for (let col = 0; col < cols; col += 1) {
            board[row][col] = '-';
        }
    }

    board[wboupCoords[0]][wboupCoords[1]] = 'W';
    board[nbslbubCoords[0]][nbslbubCoords[1]] = 'N';
    board[lsjtujzbCoords[0]][lsjtujzbCoords[1]] = 'L';

    for (let i = 0; i < commands.length; i += 1) {
        let currentCommand = commands[i].split(' ');

        if (currentCommand[0] === 'mv') {
            let piece = currentCommand[1][0],
                dir = currentCommand[2],
                pieceCoords = piece === 'W' ? wboupCoords : piece === 'N' ? nbslbubCoords : lsjtujzbCoords;

            let deltaRow = dir === 'u' ? -1 : dir === 'd' ? 1 : 0,
                deltaCol = dir === 'l' ? -1 : dir === 'r' ? 1 : 0,
                row = pieceCoords[0] + deltaRow,
                col = pieceCoords[1] + deltaCol;

            if (row < 0 || row >= rows || col < 0 || col >= cols) {
                continue;
            }

            if ((piece === 'N' && isNTrapped) || (piece === 'W' && isWTrapped)) {
                continue;
            }

            if (piece !== 'L') {
                if (board[row][col] === '-' && board[row - deltaRow][col - deltaCol] === piece) {
                    board[row][col] = piece;
                    board[row - deltaRow][col - deltaCol] = '-';
                } else if (board[row][col] !== '-' && board[row][col] !== 'x') {
                    board[row][col] += piece;
                    board[row - deltaRow][col - deltaCol] = '-';

                    if (piece === 'N' && isWTrapped) {
                        isWTrapped = false;
                    } else if (piece === 'W' && isNTrapped) {
                        isNTrapped = false;
                    }
                } else if (board[row][col] === '-' && board[row - deltaRow][col - deltaCol] !== piece) {
                    board[row][col] = piece;
                    board[row - deltaRow][col - deltaCol] = piece === 'N' ? 'W' : 'N';
                } else if (board[row][col] === 'x' && board[row - deltaRow][col - deltaCol] !== piece) {
                    if (piece === 'N') {
                        isNTrapped = true;
                    } else {
                        isWTrapped = true;
                    }

                    board[row][col] = piece;
                    board[row - deltaRow][col - deltaCol] = piece === 'N' ? 'W' : 'N';
                } else if (board[row][col] === 'x' && board[row - deltaRow][col - deltaCol] === piece) {
                    if (piece === 'N') {
                        isNTrapped = true;
                    } else {
                        isWTrapped = true;
                    }

                    board[row][col] = piece;
                    board[row - deltaRow][col - deltaCol] = '-';
                }

                if (piece === 'N') {
                    nbslbubCoords[0] = row;
                    nbslbubCoords[1] = col;
                } else {
                    wboupCoords[0] = row;
                    wboupCoords[1] = col;
                }

                if (isNTrapped && isWTrapped && !isPrincessCaught()) {
                    console.log(`Lsjtujzbo is saved! ${wboupCoords[0]} ${wboupCoords[1]} ${nbslbubCoords[0]} ${nbslbubCoords[1]}`);
                }

                if (isPrincessCaught()) {
                    console.log(`The trolls caught Lsjtujzbo at ${lsjtujzbCoords[0]} ${lsjtujzbCoords[1]}`);
                }
            } else {
                if (board[row - deltaRow][col - deltaCol] === piece && board[row][col] === '-') {
                    board[row][col] = piece;
                    board[row - deltaRow][col - deltaCol] = '-';
                } else if (board[row - deltaRow][col - deltaCol].indexOf('x') >= 0 && board[row][col] === '-') {
                    board[row][col] = piece;
                    board[row - deltaRow][col - deltaCol] = 'x';
                } else if (board[row - deltaRow][col - deltaCol].indexOf('x') >= 0 && board[row][col] === 'x') {
                    board[row][col] += piece;
                    board[row - deltaRow][col - deltaCol] = 'x';
                } else if (board[row - deltaRow][col - deltaCol] === piece && board[row][col] === 'x') {
                    board[row][col] += piece;
                    board[row - deltaRow][col - deltaCol] = '-';
                }

                lsjtujzbCoords[0] = row;
                lsjtujzbCoords[1] = col;
                
                if (isPrincessCaught()) {
                    console.log(`The trolls caught Lsjtujzbo at ${lsjtujzbCoords[0]} ${lsjtujzbCoords[1]}`);
                }

                if (lsjtujzbCoords[0] === rows - 1 && lsjtujzbCoords[1] === cols - 1) {
                    console.log(`Lsjtujzbo is saved! ${wboupCoords[0]} ${wboupCoords[1]} ${nbslbubCoords[0]} ${nbslbubCoords[1]}`);
                }
            }
        } else {
            if (board[lsjtujzbCoords[0]][lsjtujzbCoords[1]].indexOf('x') < 0) {
                board[lsjtujzbCoords[0]][lsjtujzbCoords[1]] += 'x';
            }
        }
    }

    function isPrincessCaught() {
        let neighbouringCells = [
            [lsjtujzbCoords[0] - 1, lsjtujzbCoords[1] - 1],
            [lsjtujzbCoords[0] - 1, lsjtujzbCoords[1]],
            [lsjtujzbCoords[0] - 1, lsjtujzbCoords[1] + 1],
            [lsjtujzbCoords[0], lsjtujzbCoords[1] + 1],
            [lsjtujzbCoords[0] + 1, lsjtujzbCoords[1] + 1],
            [lsjtujzbCoords[0] + 1, lsjtujzbCoords[1]],
            [lsjtujzbCoords[0] + 1, lsjtujzbCoords[1] - 1],
            [lsjtujzbCoords[0], lsjtujzbCoords[1] - 1],
        ];

        for (let i = 0; i < 8; i += 1) {
            if ((nbslbubCoords[0] === neighbouringCells[i][0] && nbslbubCoords[1] === neighbouringCells[i][1]) || 
            (wboupCoords[0] === neighbouringCells[i][0] && wboupCoords[1] === neighbouringCells[i][1])) {
                return true;
            }
        }

        return false;
    }
}

solve([
    '7 7',
    '0 0;0 1;3 0',
    'lay trap',
    'mv Lsjtujzbo r',
    'lay trap',
    'mv Lsjtujzbo r',
    'lay trap',
    'mv Lsjtujzbo d',
    'mv Lsjtujzbo d',
    'mv Wboup d',
    'mv Wboup d',
    'mv Wboup l',
    'mv Wboup l',
    'mv Wboup d',
    'mv Nbslbub d',
    'mv Nbslbub d',
    'mv Nbslbub d'
]);

solve([
    '11 12',
    '4 5;5 4;3 3',
    'mv Lsjtujzbo d'
]);