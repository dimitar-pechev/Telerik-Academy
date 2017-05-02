/* globals require module __dirname */

const express = require('express'),
    path = require('path');

require('../polyfills/array');

module.exports = function () {
    var router = express.Router();

    router.get('*', function (req, res) {
        res.status(200).sendFile(path.join(__dirname, '../public/index.html'));
    });
    return router;
};
