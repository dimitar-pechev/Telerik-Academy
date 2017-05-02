import $ from 'jquery';
import 'bootstrap';
import Navigo from 'navigo';
import * as controllers from 'controllers';
import { toggleButtonsIfLoggedIn } from 'utils';

toggleButtonsIfLoggedIn();

const router = new Navigo(null, true, '#!');

router
    .on('/home', controllers.home.getHomePage)
    .on('/users', controllers.auth.getUsersList)
    .on('/register', controllers.auth.getRegisterPage)
    .on('/login', controllers.auth.getLoginPage)
    .on('/logout', controllers.auth.logout)    
    .on('/todos', controllers.todos.getTodosList)
    .on('/todos/create', controllers.todos.getCreatePage)
    .on('/events', controllers.events.getEventsList)
    .on('/events/create', controllers.events.getCreatePage)
    .on('*', controllers.home.getHomePage)
    .resolve();

$('#navbar-main').on('click', 'ul li a', () => {
    $('#navbar-main').collapse('hide');
});