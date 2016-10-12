var data = (function () {
    const USERNAME_STORAGE_KEY = 'username-key'

    // start users
    function userLogin(user) {
        localStorage.setItem(USERNAME_STORAGE_KEY, user)
        return Promise.resolve(user)
    }

    function userLogout() {
        localStorage.removeItem(USERNAME_STORAGE_KEY)
        return Promise.resolve()
    }

    function userGetCurrent() {
        return Promise.resolve(localStorage.getItem(USERNAME_STORAGE_KEY))
    }
    // end users

    // start threads
    function threadsGet() {
        return new Promise((resolve, reject) => {
            $.getJSON('api/threads')
                .done(resolve)
                .fail(reject)
        })
    }

    function threadsAdd(title) {
        let body = {
            username: localStorage.getItem(USERNAME_STORAGE_KEY),
            title: title
        }

        return new Promise((resolve, reject) => {
            $.ajax({
                url: 'api/threads',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(body)
            })
                .done(resolve)
                .fail(reject);
        })
    }

    function threadById(id) {
        return new Promise((resolve, reject) => {
            $.getJSON(`api/threads/${id}`)
                .done(resolve)
                .fail(reject)
        })
    }

    function threadsAddMessage(threadId, content) {
        var body = {
            username: localStorage.getItem(USERNAME_STORAGE_KEY),
            content: content
        }

        return new Promise((resolve, reject) => {
            $.ajax({
                url: `api/threads/${threadId}/messages`,
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(body)
            })
                .done((data) => {
                    $(`div[data-id ="${threadId}"] > div > h3 > a`).trigger('click');
                    resolve(data)
                })
                .fail((err) => {
                    console.log(err);
                    reject(err);
                })
        })
    }

    // end threads

    // start gallery
    function galleryGet() {
        const REDDIT_URL = `https://www.reddit.com/r/aww.json?jsonp=?`

        return new Promise((resolve, reject) => {
            $.ajax({
                url: REDDIT_URL,
                dataType: 'jsonp'
            })
                .done(resolve)
                .fail(reject)
        })
    }
    // end gallery

    return {
        users: {
            login: userLogin,
            logout: userLogout,
            current: userGetCurrent
        },
        threads: {
            get: threadsGet,
            add: threadsAdd,
            getById: threadById,
            addMessage: threadsAddMessage
        },
        gallery: {
            get: galleryGet
        }
    }
})()

export { data }