import { compile } from 'templates-compiler';
import $ from 'jquery';

const $mainContainer = $('#main-container');

function getHomePage() {
    compile('home')
        .then(html => $mainContainer.html(html));
}

export { getHomePage };