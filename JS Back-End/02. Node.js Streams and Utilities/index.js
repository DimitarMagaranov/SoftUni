const logger = require('./logger.js');
const _ = require('lodash');
const fs = require('fs');
const url = require('url');
const querystring = require('querystring');

_.each([1,2,3,4,5], (num) => {
    console.log(num);
});

logger('Pesho');

let parsedUrl = url.parse('https://www.google.com/?&bih=937&biw=1920&hl=bg');
let queryParams = querystring.parse(parsedUrl.query);

console.log(parsedUrl);
console.log(queryParams);