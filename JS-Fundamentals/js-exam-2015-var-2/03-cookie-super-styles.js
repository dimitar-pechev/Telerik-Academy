'use strict';

function solve(params) {
    let lines = params.map(x => x.trim()),
        selectors = {},
        currentSelector;


    for (let i = 0; i < lines.length; i += 1) {
        let line = lines[i];

        if (line === '}') {
            // close selector
        } else if (line.indexOf('{') >= 0) {
            let elements = line.split(/[ {]/).filter(x => x !== '' && x !== ' ').map(x => x.trim());
            let els = [];
            let prev;
            for (let element of elements) {
                if (element[0] === '>' || element[0] === '+' || element[0] === '~') {
                    let symbol = element[0];
                    element = element.substring(1).trim();
                    element = symbol + element;
                    els.push(element);
                } else if (element[element.length - 1] === '>' || element[element.length - 1] === '+' || element[element.length - 1] === '~') {
                    let symbol = element[element.length - 1];
                    element = element.substring(0, element.length - 1).trim();
                    element = ' ' + element + symbol;
                    els.push(element);
                } else if (prev && prev[prev.length - 1] !== '>' && prev[prev.length - 1] !== '+' && prev[prev.length - 1] !== '~') {
                    element = ' ' + element;
                    els.push(element);
                } else {
                    els.push(element);
                }

                prev = element;
            }

            let selector = els.join('').trim();
            currentSelector = selector;
            if (!selectors[selector]) {
                selectors[selector] = [];
            }
        } else {
            let elements = line.split(/[:;]/).map(x => x.trim()),
                property = elements[0],
                value = elements[1];
            let index = -1;

            for (let i = 0; i < selectors[currentSelector].length; i += 1) {
                if (selectors[currentSelector][i]['property'] === property) {
                    index = i;
                }
            }

            if (index >= 0) {
                selectors[currentSelector].splice(index, 1);
            }

            selectors[currentSelector].push({ property, value });
        }
    }
    let result = '';

    for (let selector in selectors) {
        result += selector;
        result += '{';
        for (let prop of selectors[selector]) {
            result += prop['property'] + ':' + prop['value'] + ';';
        }
        result = result.substring(0, result.length - 1);
        result += '}';
    }

    console.log(result);
}

solve([
    '  #the-big-b{',
    '  color: yellow;',
    '  size: big;',
    '}',
    '.muppet{',
    '  powers: all;',
    '  skin: fluffy;',
    '}',
    '     .water-spirit         {',
    '  powers: water;',
    '        alignment    : not-good;',
    '				}',
    'all{',
    '  meant-for: nerdy-children;',
    '}',
    '.muppet      {',
    '	powers: everything;',
    '}',
    'all            .muppet {',
    '	alignment             :             good                             ;',
    '}',
    '   .muppet+             .water-spirit{',
    '   power: everything-a-muppet-can-do-and-water;',
    '}'
]);