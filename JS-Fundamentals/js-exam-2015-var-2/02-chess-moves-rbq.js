'use strict';

function solve(params) {
    let rows = +params[0],
        cols = +params[1],
        board = params.slice(2, rows + 2),
        moves = params.slice(rows + 3),
        parsedMoves = [];

    for (let i = 0; i < moves.length; i += 1) {
        let parsed = parseMoves(moves[i]);

        parsedMoves.push(parsed);
    }

    function parseMoves(coords) {
        let from = [
            Math.abs(coords[1] - rows),
            coords[0].charCodeAt(0) - 97
        ];
        let to = [
            Math.abs(coords[4] - rows),
            coords[3].charCodeAt(0) - 97
        ];

        return {
            from,
            to
        };
    }

    for (let i = 0; i < parsedMoves.length; i += 1) {
        let piece = board[parsedMoves[i].from[0]][parsedMoves[i].from[1]];

        if (piece === 'Q') {
            if (isValidMoveQueen(parsedMoves[i])) {
                console.log('yes');
            } else {
                console.log('no');
            }
        } else if (piece === 'B') {
            if (isValidMoveBishop(parsedMoves[i])) {
                console.log('yes');
            } else {
                console.log('no');
            }
        } else if (piece === 'R') {
            if (isValidMoveRook(parsedMoves[i])) {
                console.log('yes');
            } else {
                console.log('no');
            }
        } else {
            console.log('no');
        }
    }

    function isValidMoveQueen(coords) {
        if (isValidMoveBishop(coords) || isValidMoveRook(coords)) {
            return true;
        }

        return false;
    }

    function isValidMoveRook(coords) {
        let deltaRow = coords.from[0] > coords.to[0] ? -1 : coords.from[0] === coords.to[0] ? 0 : 1,
            deltaCol = coords.from[1] > coords.to[1] ? -1 : coords.from[1] === coords.to[1] ? 0 : 1,
            row = coords.from[0] + deltaRow,
            col = coords.from[1] + deltaCol;

        if ((deltaRow === -1 && deltaCol === -1) ||
            (deltaRow === -1 && deltaCol === 1) ||
            (deltaRow === 1 && deltaCol === 1) ||
            (deltaRow === 1 && deltaCol === -1)) {
            return false;
        }

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

    function isValidMoveBishop(coords) {
        let deltaRow = coords.from[0] > coords.to[0] ? -1 : coords.from[0] === coords.to[0] ? 0 : 1,
            deltaCol = coords.from[1] > coords.to[1] ? -1 : coords.from[1] === coords.to[1] ? 0 : 1,
            row = coords.from[0] + deltaRow,
            col = coords.from[1] + deltaCol;

        if ((deltaRow === -1 && deltaCol === 0) ||
            (deltaRow === 0 && deltaCol === 1) ||
            (deltaRow === 0 && deltaCol === -1) ||
            (deltaRow === 1 && deltaCol === 0)) {
            return false;
        }

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

solve([5, 5, 'Q---Q', '-----', '-B---', '--R--', 'Q---Q', 10, 'a1 a1', 'a1 d4', 'e1 b4', 'a5 d2', 'e5 b2', 'b3 d5', 'b3 a2', 'b3 d1', 'b3 a4', 'c2 c5',]);