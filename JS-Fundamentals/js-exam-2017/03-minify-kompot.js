'use strict';

function solve(params) {
    let joined = params.map(x => x.trim()).join(''),
        identifiers = 0,
        neededChars = 0;

    joined = joined
        .replace(/\s/g, '')
        .replace(/\r?\n|\r/g, '');

    for (let i = 0; i < 500; i += 1) {
        joined = joined
            .replace(/{([^a-zA-Z0-9_{}]*)}/g, '');
    }

    joined = joined
        .replace(/;+/g, ';');

    for (let i = 0; i < 500; i += 1) {
        joined = joined
            .replace(/{({([a-zA-Z0-9_;]*)})}/g, '$1');
    }

    joined = joined
        .replace(/;}/g, '}')
        .replace(/};/g, '}')
        .replace(/;{/g, '{')
        .replace(/{;/g, '{');


    function isLetterOrDigit(char) {
        return char.length === 1 && char.match(/[a-zA-Z0-9_]/i);
    }

    if (joined[0] === ';') {
        joined = joined.substr(1);
    }

    console.log(joined);

    for (let i = 0, len = joined.length; i < len; i += 1) {
        if (isLetterOrDigit(joined[i]) && (joined[i + 1] === ';' || joined[i + 1] === '{' || joined[i + 1] === '}')) {
            identifiers += 1;
            if (identifiers > 64) {
                neededChars += 2;
            } else {
                neededChars += 1;
            }
        } else if (joined[i] === '{') {
            neededChars += 1;
        } else if (joined[i] === '}') {
            neededChars += 1;
        } else if (joined[i] === ';') {
            neededChars += 1;
        }
    }

    if (isLetterOrDigit(joined[joined.length - 1])) {
        if (identifiers > 64) {
            neededChars += 2;
        } else {
            neededChars += 1;
        }
    }

    console.log(neededChars);
}


// solve([
//     'hello;',
//     '{this; is',
//     ' ; an;;;example;',
//     '}{{}}',
//     'of;',
//     '{',
//     'KONPOT;',
//     '{',
//     'Some_numbers;',
//     '42;5;3}',
//     '_}'
// ]);

solve([
    '\t; ;;;jGefn4E5Pvq   {} ;;  ;  ; ;',
    'tQRZ5MMj26Ov { {    {;   ;;    5OVyKBFu7o1T2 ;szDVN2dWhex1V;1gDdNdANG2',
    ';    ;    ;  ;; jGefn4E5Pvq   ;;    ;p0OWoVFZ8c;;}  {{}}{{}}  ;  ; ;',
    '   5OVyKBFu7o1T2   ;  szDVN2dWhex1V ; ;tQRZ5MMj26Ov    ;  ;   };',
    '1gDdNdANG2    ;   p0OWoVFZ8c ;  jGefn4E5Pvq {{{}}};; {{{;Z9n;;}}}',
    ';1gDdNdANG2;   ;;    ;   ;jGefn4E5Pvq ;; ;;p0OWoVFZ8c;;    ;;',
    ';',
    'tQRZ5MMj26Ov  ;',
    '{    ;szDVN2dWhex1V;   ;',
    ';   jGefn4E5Pvq   ;  ;  } }}{{}}'
]);

// solve([
//     '1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12; 13; 14;',
//     '15; 16; 17; 18; 19; 20; 21; 22; 23; 24; 25; 26; 27; 28;',
//     '29; 30; 31; 32; 33; 34; 35; 36; 37; 38; 39; 40; 41; 42;',
//     '43; 44; 45; 46; 47; 48; 49; 50; 51; 52; 53; 54; 55; 56;',
//     '57; 58; 59; 60; 61; 62; 63; 64; 65; 66; 67; 68; 69; 70;'
// ]);

