function validate(str, min, max, disallowedSymbolsRegex, allowedSymbols) {
    if (typeof str !== 'string' || str.length < min || str.length > max) {
        toastr.error(`Input should be text with length between ${min} and ${max} symbols!`);
        throw new Error(`Input should be text with length between ${min} and ${max} symbols!`);
    }

    if (disallowedSymbolsRegex) {
        if (disallowedSymbolsRegex.test(str)) {
            toastr.error(`Only the following symbols [${allowedSymbols}] are allowed!`);
            throw new Error(`Only the following symbols [${allowedSymbols}] are allowed!`);
        }
    }
}