import * as requester from 'requester';

function createTodo(text, state, category) {
    let body = {
        text,
        state,
        category
    };
    console.log(state);
    return requester.postJSON('/api/todos', body);
}

function editTodo(id, state) {
    let body = {
        state
    };
    
    return requester.putJSON(`/api/todos/${id}`, body);
}

function getTotos() {
    return requester.getJSON('/api/todos');
}

export { createTodo, editTodo, getTotos };