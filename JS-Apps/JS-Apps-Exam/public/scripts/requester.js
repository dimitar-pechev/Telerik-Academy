var requester = (function () {
    function get(url) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: url,
                method: 'GET'
            })
                .done(resolve)
                .fail(reject);
        });
    }

    function getJSON(url, headers = {}) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: url,
                method: 'GET',
                contentType: 'application/json',
                headers: headers
            })
                .done(resolve)
                .fail(reject);
        });
    }

    function postJSON(url, body, headers = {}) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: url,
                method: 'POST',
                contentType: 'application/json',
                headers: headers,
                data: JSON.stringify(body)
            })
                .done(resolve)
                .fail(reject);
        });
    }

    function putJSON(url, body, headers = {}) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: url,
                method: 'PUT',
                contentType: 'application/json',
                headers: headers,
                data: JSON.stringify(body)
            })
                .done(resolve)
                .fail(reject);
        });
    }

    return {
        get,
        getJSON,
        postJSON,
        putJSON,
    };
})();