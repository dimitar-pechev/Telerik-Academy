var data = (function () {
    let LOGIN_MAX_LENGTH = 30,
        LOGIN_MIN_LENGTH = 6,
        TITLE_MAX_LENGTH = 100,
        TITLE_MIN_LENGTH = 6;

    function getAllUsers() {
        return requester.getJSON('api/user');
    }

    function register(username, password) {
        let allowedSymbolsUsername = 'latin letters, digits, "_", "."',
            regexUsername = /[^a-zA-Z0-9_.]/g;
        validate(username, LOGIN_MIN_LENGTH, LOGIN_MAX_LENGTH, regexUsername, allowedSymbolsUsername);

        let allowedSymbolsPassword = 'latin letters, digits',
            regexPassword = /[^a-zA-Z0-9]/g;
        validate(password, LOGIN_MIN_LENGTH, LOGIN_MAX_LENGTH, regexPassword, allowedSymbolsPassword);

        let body = {
            username: username,
            password: password
        }

        return requester.postJSON('api/users', body);
    }

    function login(username, password) {
        let body = {
            username: username,
            password: password
        };

        return requester.putJSON('api/users/auth/', body)
            .then((response) => {
                if (response.result.username) {
                    localStorage.setItem('current-user', response.result.username);
                    localStorage.setItem('auth-key', response.result.authKey);
                }

                if (localStorage.getItem('current-user') === body.username) {
                    toastr.success('Successfully logged in!');
                }
                else {
                    toastr.error(response.result.err);
                }
            });
    }

    function logout() {
        localStorage.setItem('current-user', undefined);
        localStorage.setItem('auth-key', undefined);
        toastr.success('Successfully logged out!');
    }

    function getProfile(user) {
        return requester.getJSON(`api/profiles/${user}`);
    }

    function getMaterials(filter) {
        let url = 'api/materials';
        if (filter && filter.length !== 0) {
            url += `?filter=${filter}`;
        }

        return requester.getJSON(url);
    }

    function addNewMaterial(title, description, img) {
        validate(title, TITLE_MIN_LENGTH, TITLE_MAX_LENGTH);
        if (typeof description !== 'string') {
            toastr.error('Description should be text!');
            throw new Error('Description should be text!');
        }

        let body = {
            title: title,
            description: description
        },
            headers = {
                'x-auth-key': localStorage.getItem('auth-key')
            }

        if (img) {
            body.img = img;
        }

        return requester.postJSON('api/materials', body, headers);
    }

    function getMaterialByID(id) {
        return requester.getJSON(`api/materials/${id}`);
    }

    function addComment(id, comment) {
        let body = {
            commentText: comment
        },
            headers = {
                'x-auth-key': localStorage.getItem('auth-key')
            };

        return requester.putJSON(`api/materials/${id}/comments`, body, headers);
    }

    function getUserMaterials() {
        let headers = {
            'x-auth-key': localStorage.getItem('auth-key')
        };

        return requester.getJSON('api/user-materials', headers);
    }

    function getWatched() {
        let headers = {
            'x-auth-key': localStorage.getItem('auth-key')
        };

        return requester.getJSON('api/user-materials/watched', headers);
    }

    function getWatching() {
        let headers = {
            'x-auth-key': localStorage.getItem('auth-key')
        };

        return requester.getJSON('api/user-materials/watching', headers);
    }

    function getWantToWatch() {
        let headers = {
            'x-auth-key': localStorage.getItem('auth-key')
        };

        return requester.getJSON('api/user-materials/want-to-watch', headers);
    }

    function addToCategory(id, category) {
        let body = {
            id: id,
            category: category
        },
            headers = {
                'x-auth-key': localStorage.getItem('auth-key')
            };

        return requester.postJSON('api/user-materials', body, headers);
    }

    function changeCategory(id, category) {
        let body = {
            id: id,
            category: category
        },
            headers = {
                'x-auth-key': localStorage.getItem('auth-key')
            };

        return requester.putJSON('api/user-materials', body, headers);
    }

    return {
        getAllUsers,
        register,
        login,
        logout,
        getProfile,
        getMaterials,
        addNewMaterial,
        getMaterialByID,
        addComment,
        getUserMaterials,
        getWatched,
        getWatching,
        getWantToWatch,
        addToCategory,
        changeCategory
    };
})();