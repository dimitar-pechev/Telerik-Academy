import $ from 'jquery';
import 'bootstrap';
import Navigo from 'navigo';
import * as controllers from 'controllers';
import { toggleButtonsIfLoggedIn } from 'utils';

toggleButtonsIfLoggedIn();

const router = new Navigo(null, true, '#!');

router
    .on('/home', controllers.home.getHomePage)
   // .on('*', controllers.home.get)
    .resolve();

$('#navbar-main').on('click', 'ul li a', () => {
    $('#navbar-main').collapse('hide');
});