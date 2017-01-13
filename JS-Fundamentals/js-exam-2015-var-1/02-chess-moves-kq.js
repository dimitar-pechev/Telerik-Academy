'use strict';

function solve(params) {
    let rows = +params[0],
        cols = +params[1],
        board = params.slice(2, rows + 2),
        moves = params.slice(rows + 3);
    let parsedMoves = [];
    for (let i = 0; i < moves.length; i += 1) {
        let parsed = parseMoves(moves[i]);

        parsedMoves.push(parsed);
    }

    function parseMoves(coords) {
        let from = [
            Math.abs(+coords[1] - rows),
            coords[0].charCodeAt(0) - 97
        ];

        let to = [
            Math.abs(+coords[4] - rows),
            coords[3].charCodeAt(0) - 97
        ];

        return {
            from,
            to
        };
    }

    for (let i = 0; i < parsedMoves.length; i += 1) {
        let piece = board[parsedMoves[i].from[0]][parsedMoves[i].from[1]];
        if (piece === 'K') {
            if (isValidKnightMove(parsedMoves[i])) {
                console.log('yes');
            } else {
                console.log('no');
            }
        }
        else if (piece === 'Q') {
            if (isValidQueenMove(parsedMoves[i])) {
                console.log('yes');
            } else {
                console.log('no');
            }
        }
        else {
            console.log('no');
        }
    }

    // check if proposed moves are inside the bounderies of the matrix?
    function isValidKnightMove(coords) {
        let possibleMoves = [
            [-2, 1], [-1, 2], [1, 2], [2, 1],
            [2, -1], [1, -2], [-1, -2], [-2, -1]
        ];

        let isMovePossible = false;
        for (let i = 0; i < possibleMoves.length; i += 1) {
            let contenderCoords = [
                possibleMoves[i][0] + coords.from[0],
                possibleMoves[i][1] + coords.from[1]
            ];

            if (coords.to[0] === contenderCoords[0] && coords.to[1] === contenderCoords[1]) {
                isMovePossible = true;
                break;
            }
        }

        if (board[coords.to[0]][coords.to[1]] === '-' && isMovePossible) {
            return true;
        }

        return false;
    }

    function isValidQueenMove(coords) {
        let deltaRow = coords.to[0] > coords.from[0] ? 1 : coords.to[0] === coords.from[0] ? 0 : -1,
            deltaCol = coords.to[1] > coords.from[1] ? 1 : coords.to[1] === coords.from[1] ? 0 : -1;

        let row = coords.from[0] + deltaRow,
            col = coords.from[1] + deltaCol;

        while (true) {
            if (row < 0 || row >= rows || col < 0 || col >= cols) {
                return false;
            }

            if (board[row][col] !== '-') {
                return false;
            }

            if (row === coords.to[0] && col === coords.to[1]) {
                return true;
            }

            row = row + deltaRow;
            col = col + deltaCol;
        }
    }
}

solve([4,
    5,
    '-----',
    '-Q---',
    '---Q-',
    'Q--Q-',
    5,
    'a4 c4',
    'b3 e3',
    'b3 c2',
    'd1 d2',
    'd4 d2']);