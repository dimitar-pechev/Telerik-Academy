import { compile } from 'templates-compiler';
import toastr from 'toastr';
import $ from 'jquery';
import { redirectIfNotLoggedIn } from 'utils';
import * as todoService from 'todos-service';

const $mainContainer = $('#main-container');

function getCreatePage() {
    if (redirectIfNotLoggedIn()) {
        return;
    }

    compile('todos/create')
        .then(html => $mainContainer.html(html))
        .then(() => {
            const $btnCreateTodo = $('#btn-create-todo');

            $btnCreateTodo.on('click', () => {
                const $category = $('#todo-category');
                const $text = $('#todo-text');
                const $state = $('#todo-state');

                if (!$category.val().trim() || $category.val().trim().length < 3 || $category.val().trim().length > 15) {
                    toastr.error('Category length should be between 3 and 15 symbols!');
                    $category.focus();
                    return;
                }

                if (!$text.val().trim() || $text.val().trim().length < 5 || $text.val().trim().length > 200) {
                    toastr.error('Text length should be between 5 and 200 symbols!');
                    $text.focus();
                    return;
                }

                let state = $state.val() == 'true' ? true : false;
                let category = $category.val();
                let text = $text.val();

                todoService.createTodo(text, state, category)
                    .then(() => {
                        toastr.success('TODO created!');
                        $(location).attr('href', '#!/todos');
                    })
                    .catch(error => {
                        console.log(error);
                        toastr.error(error.responseJSON);
                    });
            });
        });
}

function getTodosList() {
    if (redirectIfNotLoggedIn()) {
        return;
    }
    
    todoService.getTotos()
        .then(response => {
            let data = {
                username: localStorage.getItem('currentUser'),
                todos: response.result
            };

            console.log(data);

            return compile('todos/list', data);
        })
        .then(html => $mainContainer.html(html))
        .then(() => {
            $('.todo-change-status').on('click', (ev) => {
                let id = $(ev.target).parent().parent().attr('id');
                let $status = $(`#todo-status-${id}`);

                let status = $status.html().trim() == 'Done!' ? true : false;
                todoService.editTodo(id, !status)
                    .then(() => {
                        if (status) {
                            $status.html('To be done!');
                        } else {
                            $status.html('Done!');
                        }

                        toastr.success('Status successfully changed!');
                    })
                    .catch(error => {
                        console.log(error);
                        toastr.error(error.responseJSON);
                    });
            });
        })
        .catch(error => {
            console.log(error);
            toastr.error(error.responseJSON);
        });
}

export { getCreatePage, getTodosList };