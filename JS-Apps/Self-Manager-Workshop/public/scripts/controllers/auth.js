import { compile } from 'templates-compiler';
import toastr from 'toastr';
import $ from 'jquery';
import { toggleButtonsIfLoggedIn, redirectIfNotLoggedIn } from 'utils';
import * as authService from 'auth-service';

const $mainContainer = $('#main-container');

function getUsersList() {
    if (redirectIfNotLoggedIn()) {
        return;
    }

    authService.getUsers()
        .then(users => {
            return compile('auth/users', users);
        })
        .then(html => $mainContainer.html(html));
}

function getRegisterPage() {
    compile('auth/register')
        .then(html => $mainContainer.html(html))
        .then(() => {
            let $btnRegister = $('#btn-register');
            $btnRegister.on('click', () => {
                $btnRegister.addClass('disabled');
                $btnRegister.attr('disabled', true);

                let $registerUsername = $('#register-username');
                let $formRegisterUsername = $('#form-register-username');
                let username = $registerUsername.val();
                if (!username || username.trim().length < 6 || username.trim().length > 15) {
                    $formRegisterUsername.addClass('has-error');
                    $registerUsername.focus();
                    $btnRegister.removeClass('disabled');
                    $btnRegister.attr('disabled', false);
                    toastr.error('Username length should be between 6 and 15 symbols!');
                    return;
                } else {
                    $formRegisterUsername.removeClass('has-error').addClass('has-success');
                }

                let $registerPassword = $('#register-password');
                let $formRegisterPassword = $('#form-register-password');
                let password = $registerPassword.val();
                if (!password || password.trim().length < 6 || password.trim().length > 15) {
                    $formRegisterPassword.addClass('has-error');
                    $registerPassword.focus();
                    toastr.error('Pasword length should be between 6 and 15 symbols!');
                    $btnRegister.removeClass('disabled');
                    $btnRegister.attr('disabled', false);
                    return;
                } else {
                    $formRegisterPassword.removeClass('has-error').addClass('has-success');
                }

                let $registerConfirmPassword = $('#register-confirm-password');
                let $formRegisterConfirmPassword = $('#form-register-confirm-password');
                let confirmPassword = $registerConfirmPassword.val();
                if (password !== confirmPassword) {
                    $formRegisterPassword.addClass('has-error');
                    $formRegisterConfirmPassword.addClass('has-error');
                    $registerConfirmPassword.focus();
                    $btnRegister.removeClass('disabled');
                    $btnRegister.attr('disabled', false);
                    toastr.error('Paswords do not match!');
                    return;
                } else {
                    $formRegisterPassword.removeClass('has-error').addClass('has-success');
                    $formRegisterConfirmPassword.removeClass('has-error').addClass('has-success');
                }

                let user = {
                    username,
                    password
                };

                authService.register(user)
                    .then(response => {
                        $registerUsername.val('');
                        $registerPassword.val('');
                        $registerConfirmPassword.val('');

                        toastr.success(`User ${username} successfully registered!`);

                        localStorage.setItem('currentUser', response.result.username);
                        localStorage.setItem('token', response.result.authKey);

                        $(location).attr('href', '#!/home');
                        toggleButtonsIfLoggedIn();
                    })
                    .catch(error => {
                        if (error.status == 400) {
                            toastr.error('Username already taken!');
                            $formRegisterUsername.addClass('has-error');
                            $registerUsername.focus();
                        } else {
                            toastr.error('An error occured! Please try again later!');
                            $btnRegister.removeClass('disabled');
                            console.log(error);
                        }

                        $btnRegister.removeClass('disabled');
                        $btnRegister.attr('disabled', false);
                    });
            });
        });
}

function getLoginPage() {
    compile('auth/login')
        .then(html => $mainContainer.html(html))
        .then(() => {
            let $btnLogin = $('#btn-login');
            $btnLogin.on('click', () => {
                $btnLogin.addClass('disabled');
                $btnLogin.attr('disabled', true);

                let $loginUsername = $('#login-username');
                let $formLoginUsername = $('#form-login-username');
                let username = $loginUsername.val();
                if (!username) {
                    $formLoginUsername.addClass('has-error');
                    $loginUsername.focus();
                    toastr.error('Username required!');
                    $btnLogin.removeClass('disabled');
                    $btnLogin.attr('disabled', false);
                    return;
                } else {
                    $formLoginUsername.removeClass('has-error').addClass('has-success');
                }

                let $loginPassword = $('#login-password');
                let $formLoginPassword = $('#form-login-password');
                let password = $loginPassword.val();
                if (!password) {
                    $formLoginPassword.addClass('has-error');
                    $loginPassword.focus();
                    toastr.error('Provide your password!');
                    $btnLogin.removeClass('disabled');
                    $btnLogin.attr('disabled', false);
                    return;
                } else {
                    $formLoginPassword.removeClass('has-error').addClass('has-success');
                }

                let user = {
                    username,
                    password
                };

                authService.login(user)
                    .then(response => {
                        localStorage.setItem('currentUser', response.result.username);
                        localStorage.setItem('token', response.result.authKey);
                        toastr.success('Login successful!');

                        $(location).attr('href', '#!/home');
                        toggleButtonsIfLoggedIn();
                    })
                    .catch(error => {
                        if (error.status == 404) {
                            toastr.error('Invalid username or/and password!');
                            $formLoginUsername.addClass('has-error');
                            $formLoginPassword.addClass('has-error');
                        } else {
                            toastr.error('An error occured! Please try again later!');
                            console.log(error);
                        }

                        $btnLogin.removeClass('disabled');
                        $btnLogin.attr('disabled', false);
                    });
            });
        });

}

function logout() {
    localStorage.clear();
    toastr.success('User successfully logged out!');
    $(location).attr('href', '#!/home');
    toggleButtonsIfLoggedIn();
}

export { getRegisterPage, getLoginPage, logout, getUsersList };