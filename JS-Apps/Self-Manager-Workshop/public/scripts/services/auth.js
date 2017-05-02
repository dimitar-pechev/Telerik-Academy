import * as requester from 'requester';

function register(user) {
    return requester.postJSON('/api/users', user);
}

function login(user) {
    return requester.putJSON('/api/users/auth', user);
}

function getUsers() {
    return requester.getJSON('/api/users');
}

export { register, login, getUsers };