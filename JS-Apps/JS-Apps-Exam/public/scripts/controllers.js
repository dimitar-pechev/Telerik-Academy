var controllers = (function () {
    let $container = $('#container');

    function home() {
        data.getMaterials()
            .then((books) => {
                return templateLoader.compile('home', books);
            })
            .then((html) => {
                $container.html(html);
            });
    }

    function search(params) {
        data.getMaterials(params.search)
            .then((books) => {
                return templateLoader.compile('home', books);
            })
            .then((html) => {
                $container.html(html);
            });
    }

    function resourceDetails(params) {
        let commonData;

        data.getMaterialByID(params.id)
            .then((book) => {
                commonData = {
                    user: book.result.user.username,
                    bookId: book.result.id
                }

                return templateLoader.compile('resource-details', book);
            })
            .then((html) => {
                $container.html(html);
                toggleButtonsIfLoggedIn();                
            })
            .then(() => {
                $('#watching').on('click', () => {
                    data.addToCategory(commonData.bookId, 'watching')
                        .then(() => {
                            toastr.success('Added to category "Watching"!');
                        })
                        .catch(() => {
                            data.changeCategory(commonData.bookId, 'watching');
                            toastr.success('Switched to category "Watching"!');
                        });
                });

                $('#watched').on('click', () => {
                    data.addToCategory(commonData.bookId, 'watched')
                        .then(() => {
                            toastr.success('Added to category "Watched"!');
                        })
                        .catch(() => {
                            data.changeCategory(commonData.bookId, 'watched');
                            toastr.success('Switched to category "Watched"!');
                        });
                });

                $('#want-to-watch').on('click', () => {
                    data.addToCategory(commonData.bookId, 'want-to-watch')
                        .then(() => {
                            toastr.success('Added to category "Want to Watch"!');
                        })
                        .catch(() => {
                            data.changeCategory(commonData.bookId, 'want-to-watch');
                            toastr.success('Switched to category "Want to Watch"!');
                        });
                });
            })
            .then(() => {
                $('#comment').on('keypress', (ev) => {
                    if (!$('#comment').val().trim()) {
                        return;
                    }

                    let $searchValue = $('#comment').val().trim();
                    if (ev.which == 13) {
                        let comment = $('#comment').val().trim(),
                            id = $('#comment')
                                .parents('.row')
                                .attr('id');
                        commonData.text = comment;

                        data.addComment(id, comment)
                            .then(() => {
                                templateLoader.compile('comment', commonData)
                                    .then((html) => {
                                        $('#comments-box').append(html);
                                    })
                            });
                        $('#comment').val('');
                        $('#comment').blur();
                        toastr.success('Successfully posted comment!');
                    }
                });
            });
    }

    function profile(params) {
        data.getProfile(params.username)
            .then(profile => {
                return templateLoader.compile('profile', profile);
            })
            .then((html) => {
                $container.html(html);
            });
    }

    function login() {
        requester.get(`../templates/login.handlebars`)
            .then((html) => {
                $container.html(html);
            })
            .then(() => {
                $('#btn-login').on('click', () => {
                    let username = $('#inputUsername').val().trim(),
                        password = $('#inputPassword').val().trim();

                    data.login(username, password)
                        .then(() => {
                            console.log(localStorage.getItem('current-user'));
                            if (localStorage.getItem('current-user') == username) {
                                router.navigate('/home');
                            }
                            else {
                                $('#inputUsername').val('');
                                $('#inputPassword').val('');
                            }

                            toggleButtonsIfLoggedIn();
                        });
                });
            });
    }
    function register() {
        requester.get(`../templates/register.handlebars`)
            .then((html) => {
                $container.html(html);
            })
            .then(() => {
                $('#btn-reg').on('click', () => {
                    let username = $('#regUsername').val().trim(),
                        password = $('#regPassword').val().trim();

                    data.register(username, password)
                        .then(() => {
                            toastr.success('Registration successful!');
                            router.navigate('/login');
                        })
                        .catch((err) => {
                            toastr.error('User with such username already exists!');
                            $('#regUsername').val('');
                            $('#regPassword').val('');
                        });

                    toggleButtonsIfLoggedIn();
                });
            });
    }

    function add() {
        requester.get(`../templates/add.handlebars`)
            .then((html) => {
                $container.html(html);
            })
            .then(() => {
                $('#btn-add-material').on('click', () => {
                    let title = $('#materialTitle').val().trim(),
                        description = $('#materialDesc').val().trim(),
                        img = $('#addMaterialImage').val().trim();

                    data.addNewMaterial(title, description, img)
                        .then(() => {
                            toastr.success('Material added successfully!');
                            router.navigate('/home')
                        })
                        .catch(() => {
                            toastr.error('Only registered users can add materials!');
                        });
                });
            });
    }

    return {
        home,
        search,
        resourceDetails,
        profile,
        login,
        register,
        add
    }
})();