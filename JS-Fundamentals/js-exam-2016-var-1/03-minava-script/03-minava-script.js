'use strict';

function solve(params) {
    let lines = params,
        results = {},
        globalPriority = 0,
        isInSelectorScope = false,
        selector,
        priority,
        final = [];

    for (let i = 0, len = lines.length; i < len; i += 1) {
        let line = lines[i].trim();
        if (line === '}') {
            isInSelectorScope = false;
        } else if (line.indexOf('{') >= 0) {
            let elements = line.split(/[{]/).filter(x => x !== '' && x !== '{').map(x => x.trim());

            priority = null;
            if (elements.length === 2) {
                priority = +elements[1].substr(1);
            }
            isInSelectorScope = true;
            selector = elements[0];

            if (!results[selector]) {
                results[selector] = {};
            }
        } else if (line[0] === '@') {
            if (isInSelectorScope) {
                priority = +line.substr(1);
            } else {
                globalPriority = +line.substr(1);
            }
        } else {
            let elements = line.split(/[:;]/).filter(x => x !== '' && x !== ' ').map(x => x.trim());

            let important;
            let currentPriority;
            if (elements.length === 3) {
                important = +elements[2].substr(1);
            }

            if (important !== undefined && important !== null) {
                currentPriority = important;
            } else if (priority !== null) {
                currentPriority = priority;
            } else {
                currentPriority = globalPriority;
            }

            if (!results[selector][elements[0]]) {
                results[selector][elements[0]] = {
                    property: elements[1],
                    priority: currentPriority
                };
            } else {
                if (results[selector][elements[0]]['priority'] < currentPriority) {
                    results[selector][elements[0]] = {
                        property: elements[1],
                        priority: currentPriority
                    };
                }
            }
        }
    }

    Object.keys(results)
        .forEach(key => {
            for (let k in results[key]) {
                final.push(`${key} { ${k}: ${results[key][k].property}; }`);
            }
        });

    console.log(final.sort().join('\n'));
}

solve(['enthusiasm { @5',
    '  ap-percept-ion:buying;',
    '  @2',
    '  houston:pZ!X;',
    '  chute-s:accelerometers;',
    '}',
    '@9',
    'molar { @6',
    '  @15',
    '  houston:E!NVDt; @7',
    '  houston:u#It#;',
    '  ap-percept-ion:Dog; @15',
    '  chute-s:advises;',
    '}',
    'oodles {',
    '  @13',
    '  chute-s:perish;',
    '}',
    'molar {',
    '  r-ega-rding:4lXPE;',
    '  r-ega-rding:digesting;',
    '  houston:xZAEIh#S;',
    '  chute-s:benched;',
    '  @3',
    '  ap-percept-ion:gssO%FDd;',
    '}',
    'enthusiasm { @15',
    '  houston:NkR99XZ;',
    '  ap-percept-ion:aPQG;',
    '}']);