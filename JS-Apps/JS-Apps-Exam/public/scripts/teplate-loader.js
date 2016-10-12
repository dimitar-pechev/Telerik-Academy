var templateLoader = (function () {
    function compile(templateName, data) {
        return requester.get(`../templates/${templateName}.handlebars`)
            .then((template) => {
                let rawHtml = Handlebars.compile(template),
                    html = rawHtml(data);
                return html;
            });
    }

    return {
        compile
    };
})();