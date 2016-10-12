function toggleButtonsIfLoggedIn() {
    if (!localStorage.getItem('current-user') ||
            localStorage.getItem('current-user') == 'undefined' ||
            localStorage.getItem('current-user') == 'null') {
        $(".logged-in").addClass('hidden');
        $(".logged-out").removeClass('hidden');
    }
    else {
        $(".logged-in").removeClass('hidden');
        $(".logged-out").addClass('hidden');
    }
}