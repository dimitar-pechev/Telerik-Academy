'use strict';

function solve(params) {
    let scripts = params,
        enumName,
        results = [],
        sharedEnums = [],
        sharedPriorities = {},
        enums = [],
        priorities = {},
        isShared = false;

    function getResults(enums, priorities) {
        let index = 0;
        enums.forEach(x => {
            if (x.value < 0) {
                while (priorities[index]) {
                    index += 1;
                }

                x.value = index;
                index += 1;
            }

            results.push(`${x.name} = ${x.value} :: ${x.enumName};`);
        });
    }

    for (let i = 0, len = scripts.length; i < len; i += 1) {
        let line = scripts[i].trim();
        if (line === '</>') {
            if (!isShared) {
                getResults(enums, priorities);
            }
        } else if (line[0] === '<') {
            if (line[1] === '@') {
                enumName = line.substring(2, line.length - 1);
                isShared = true;
            } else {
                enumName = line.substring(1, line.length - 1);
                enums = [];
                priorities = {};
                isShared = false;
            }
        } else {
            let elements = line
                .split(/[=;]+/)
                .filter(x => x !== '')
                .map(x => x.trim());

            if (elements.length === 2 && !isShared) {
                priorities[elements[1]] = true;
            } else if (elements.length === 2 && isShared) {
                sharedPriorities[elements[1]] = true;
            }

            if (!isShared) {
                let value = elements.length === 2 ? elements[1] : -1;

                enums.push({
                    name: elements[0],
                    value,
                    enumName
                });
            } else {
                let value = elements.length === 2 ? elements[1] : -1;

                sharedEnums.push({
                    name: elements[0],
                    value,
                    enumName
                });
            }
        }
    }

    getResults(sharedEnums, sharedPriorities);

    console.log(results.sort().join('\n'));
}

solve([
    '<@Languages>',
    '   CSharp;',
    '   JavaScript;',
    '   Haskell = 42;',
    '   Rust = 4;',
    '   CPP;',
    '</>',
    '<Result>',
    '   Failed;',
    '   Passed;',
    '   Excellence;',
    '</>',
    '<@Insects>',
    '   Ant;',
    '   Mosquito = 2;',
    '</>'
]);

// solve([
//     '<Fruit>',
//     '  Apple;',
//     '  Banana;',
//     '  Pineapple;',
//     '</>',
//     '<Vegetable>',
//     '  Cucumber = 1;',
//     '  Cabage;',
//     '</>'
// ]);
