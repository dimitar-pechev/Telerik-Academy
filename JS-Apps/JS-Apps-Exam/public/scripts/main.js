var router = new Navigo(null, true);

router
    .on('/home/:search', controllers.search)
    .on('/home', controllers.home)
    .on('/materials/:id', controllers.resourceDetails)
    .on('/profiles/:username', controllers.profile)
    .on('/login', controllers.login)
    .on('/register', controllers.register)
    .on('/add', controllers.add)
    .on(() => {
        router.navigate('/home');
    })
    .resolve();

toggleButtonsIfLoggedIn();

$('#search-bar').on('keypress', (ev) => {
    if (!$('#search-bar').val().trim()) {
        return;
    }

    let $searchValue = $('#search-bar').val().trim();
    if (ev.which == 13) {
        router.navigate(`/home/${$searchValue}`);

        $('#search-bar').val('');
        $('#search-bar').blur();
    }
});

$('#btn-logout').on('click', () => {
    data.logout();
    toggleButtonsIfLoggedIn();
    router.navigate('/home');
});

$('#myProfile').on('click', () => {
    router.navigate('/profiles/' + localStorage.getItem('current-user'));
});