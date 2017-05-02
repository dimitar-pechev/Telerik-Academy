/* globals SystemJS */

SystemJS.config({
    transpiler: 'plugin-babel',
    map: {
        // plugins
        'plugin-babel': '/libs/systemjs-plugin-babel/plugin-babel.js',
        'systemjs-babel-build': '/libs/systemjs-plugin-babel/systemjs-babel-browser.js',

        // app
        'main': '/public/scripts/main.js',
        'requester': '/public/scripts/requester.js',
        'utils': '/public/scripts/utils.js',
        'templates-compiler': '/public/scripts/templates-compiler.js',

        // services
        'auth-service': '/public/scripts/services/auth.js',
        'todos-service': '/public/scripts/services/todos.js',

        // controllers
        'home-controller': '/public/scripts/controllers/home.js',
        'auth-controller': '/public/scripts/controllers/auth.js',
        'todos-controller': '/public/scripts/controllers/todos.js',
        'controllers': '/public/scripts/controllers/index.js',

        // libs
        'jquery': '/public/bower_components/jquery/dist/jquery.js',
        'bootstrap': '/public/bower_components/bootstrap/dist/js/bootstrap.js',
        'navigo': '/public/bower_components/navigo/lib/navigo.js',
        'handlebars': '/public/bower_components/handlebars/handlebars.js',
        'toastr': '/public/bower_components/toastr/toastr.js'
    }
});