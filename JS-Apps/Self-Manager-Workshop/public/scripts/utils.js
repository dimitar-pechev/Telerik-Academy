import $ from 'jquery';
import toastr from 'toastr';

function toggleButtonsIfLoggedIn() {
    if (localStorage.getItem('currentUser') != undefined) {
        $('.logged-out').addClass('hidden');
        $('.logged-in').removeClass('hidden');
    } else {
        $('.logged-out').removeClass('hidden');
        $('.logged-in').addClass('hidden');
    }
}

function redirectIfNotLoggedIn() {
    if (!localStorage.getItem('currentUser')) {
        $(location).attr('href', '#!/login');
        toastr.error('You need to be signed in to view this page!');
        return true;
    }

    return false;
}

function formatDate(date) {
    let monthNames = [
        'January', 'February', 'March',
        'April', 'May', 'June', 'July',
        'August', 'September', 'October',
        'November', 'December'
    ];

    date = new Date(date);

    let day = _formatNumber(date.getDate());
    let monthIndex = date.getMonth();
    let year = date.getFullYear();
    let hours = _formatNumber(date.getHours());
    let minutes = _formatNumber(date.getMinutes());

    return `${hours}:${minutes}, ${day} ${monthNames[monthIndex]} ${year}`;
}

function _formatNumber(number) {
    return number.toString().length < 2 ? `0${number}` : number;
}

export { toggleButtonsIfLoggedIn, formatDate, redirectIfNotLoggedIn };