import { compile } from 'templates-compiler';
import toastr from 'toastr';
import $ from 'jquery';
import { redirectIfNotLoggedIn } from 'utils';
import * as eventsService from 'events-service';
import 'moment';
import 'datepicker';

console.log();
console.log();

const $mainContainer = $('#main-container');

function getEventsList() {
    if (redirectIfNotLoggedIn()) {
        return;
    }

    eventsService.getEvents()
        .then(response => {
            let data = {
                events: response.result,
                username: localStorage.getItem('currentUser')
            };
            console.log(data);
            return compile('events/list', data);
        })
        .then(html => $mainContainer.html(html));
}

function getCreatePage() {
    if (redirectIfNotLoggedIn()) {
        return;
    }

    compile('events/create')
        .then(html => $mainContainer.html(html))
        .then(() => {
            $('#btn-create-event').on('click', () => {
                const $title = $('#event-title');
                const $date = $('#event-date');
                const $description = $('#event-description');
                const $users = $('#event-users');
                const $category = $('#event-category');

                if (!$title.val().trim() || $title.val().trim().length < 3 || $title.val().trim().length > 15) {
                    $title.focus();
                    toastr.error('Title should be between 3 and 15 symbols!');
                    return;
                }

                if (!$category.val().trim() || $category.val().trim().length < 3 || $category.val().trim().length > 15) {
                    $category.focus();
                    toastr.error('Category should be between 3 and 15 symbols!');
                    return;
                }

                if (!$description.val().trim() || $description.val().trim().length < 5 || $description.val().trim().length > 500) {
                    $description.focus();
                    toastr.error('Description should be between 5 and 500 symbols!');
                    return;
                }

                let date = new Date($date.val().trim());
                if (date == 'Invalid Date') {
                    $date.focus();
                    toastr.error('Please enter a valid date!');
                    return;
                }

                let title = $title.val().trim();
                let category = $category.val().trim();
                let description = $description.val().trim();

                let users = $users.val().split(',').map(x => x.trim()).filter(x => x != '');

                eventsService.createEvent(title, description, date, category, users)
                    .then((res) => {
                        console.log(res);
                        toastr.success('Event successfully created!');
                        $(location).attr('href', '#!/events');
                    })
                    .catch(error => {
                        console.log(error);
                        toastr.error(error.responseJSON);
                    });
            });
        }).catch(error => {
            console.log(error);
            toastr.error(error.responseJSON);
        });
}

export { getEventsList, getCreatePage };