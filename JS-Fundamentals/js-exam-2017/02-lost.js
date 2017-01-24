'use strict';

function solve(params) {
    let dimensions = params.shift().split(' ').map(Number),
        rows = dimensions[0],
        cols = dimensions[1],
        currentCoords = {
            row: Math.floor(rows / 2),
            col: Math.floor(cols / 2)
        },
        binaryMap = ['helperElementAtIndex0', '0001', '0010', '0011', '0100', '0101', '0110', '0111', '1000', '1001', '1010', '1011', '1100', '1101', '1110', '1111'],
        boolArr = [],
        maze = [],
        isOut = false;

    for (let line of params) {
        maze.push(line.split(' ').map(Number));
    }

    for (let row = 0; row < rows; row += 1) {
        boolArr.push([]);
        for (let col = 0; col < cols; col += 1) {
            boolArr[row][col] = false;
        }
    }

    while (true) {
        if (binaryMap[maze[currentCoords.row][currentCoords.col]][3] === '1' && (currentCoords.row - 1 < 0 ||
            !boolArr[currentCoords.row - 1][currentCoords.col])) {
            if (currentCoords.row - 1 < 0) {
                isOut = true;
                break;
            }

            boolArr[currentCoords.row][currentCoords.col] = true;
            currentCoords.row -= 1;
        } else if (binaryMap[maze[currentCoords.row][currentCoords.col]][2] === '1' && (currentCoords.col + 1 < 0 ||
            !boolArr[currentCoords.row][currentCoords.col + 1])) {
            if (currentCoords.col + 1 === cols) {
                isOut = true;
                break;
            }

            boolArr[currentCoords.row][currentCoords.col] = true;
            currentCoords.col += 1;
        } else if (binaryMap[maze[currentCoords.row][currentCoords.col]][1] === '1' && (currentCoords.row + 1 < 0 ||
            !boolArr[currentCoords.row + 1][currentCoords.col])) {
            if (currentCoords.row + 1 === rows) {
                isOut = true;
                break;
            }

            boolArr[currentCoords.row][currentCoords.col] = true;
            currentCoords.row += 1;
        } else if (binaryMap[maze[currentCoords.row][currentCoords.col]][0] === '1' && (currentCoords.col - 1 < 0 ||
            !boolArr[currentCoords.row][currentCoords.col - 1])) {
            if (currentCoords.col - 1 < 0) {
                isOut = true;
                break;
            }

            boolArr[currentCoords.row][currentCoords.col] = true;
            currentCoords.col -= 1;
        } else {
            break;
        }
    }

    let message = isOut ? `No rakiya, only JavaScript ${currentCoords.row} ${currentCoords.col}`
        : `No JavaScript, only rakiya ${currentCoords.row} ${currentCoords.col}`;
    console.log(message);
}

solve([
    '5 7',
    '9 5 3 11 9 5 3',
    '10 11 10 12 4 3 10',
    '10 10 12 7 13 6 10',
    '12 4 3 9 5 5 2',
    '13 5 4 6 13 5 6'
]);

solve([
    '7 5',
    '9 3 11 9 3',
    '10 12 4 6 10',
    '12 3 13 1 6',
    '9 6 11 12 3',
    '10 9 6 13 6',
    '10 12 5 5 3',
    '12 5 5 5 6'
]);