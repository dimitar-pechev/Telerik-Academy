'use strict';

function solve(params) {
    let lines = params.map(x => x.trim()),
        results = {},
        selectors = [],
        currentSelector,
        counter = 0;

    for (let i = 0; i < lines.length; i += 1) {
        let line = lines[i];
        if (line === '}') {
            selectors.pop();
            counter -= 1;
            if (selectors.length > 0) {
                currentSelector = selectors[selectors.length - 1];
            }
        } else if (line.indexOf('{') >= 0) {
            counter += 1;
            let selector = line.split('{')[0].trim();
            if (selector.indexOf('$') >= 0) {
                selector = selector
                    .replace('$', selectors[selectors.length - 1]);
            } else if (counter > 1) {
                selector = selectors[selectors.length - 1] + ' ' + selector;
            }

            currentSelector = selector;
            selectors.push(selector);
            if (!results[selector]) {
                results[selector] = [];
            }
        } else {
            let elements = line.split(/[:;]/).map(x => x.trim());
            results[currentSelector].push({ name: elements[0], value: elements[1] });
        }
    }

    let final = [];
    for (let selector in results) {
        final.push(`${selector} {`);
        for (let property of results[selector]) {
            final.push(`  ${property.name}: ${property.value};`);
        }
        final.push('}');
    }

    console.log(final.join('\n'));
}

solve([
    '    #the-big-b{',
    '  color: big-yellow;',
    '  .little-bs {',
    '           color: little-yellow;',
    '      $.male            {',
    '             color: middle-yellow;',
    '}',
    '}',
    '}',
    '           .muppet           {',
    '             skin        :        fluffy;',
    '  $.water-spirit    {',
    '    powers    :     water;',
    '                     }',
    '  $>thread{',
    '     color: depends;',
    '   }',
    '  powers    :      all-muppet-powers;',
    '}'
]);