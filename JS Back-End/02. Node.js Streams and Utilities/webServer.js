const http = require('http');
const url = require('url');
const fs = require('fs');
const querystring = require('querystring');
const pubSub = require('./pubSub');
const events = require('events');
const utils = require('./utils');
const util = require('util');
require('./init');

const port = 5000;
const readFileAsync = util.promisify(fs.readFile);

let eventEmitter = new events.EventEmitter();

eventEmitter.on('cats', (name) => {
    console.log(`From event emitter: ${name}`);
})

function requestHandler(req, res) {
    let parsedUrl = url.parse(req.url);
    let queryParams = querystring.parse(parsedUrl.query);
    // const readStream = fs.createReadStream('./views/cats.html', {encoding: 'utf8'});

    switch (parsedUrl.pathname) {
        case '/cats':
            res.writeHead(200, {
                'Content-Type': 'text/html',
            });

            // readStream.on('data', (chunk) => res.write(chunk));
            // readStream.on('end', () => res.end());

            // readStream.pipe(res);
            
            // fs.readFile('./views/cats.html', function(err, data) {
            //     if (err) {
            //         console.log('some error');
            //         return;
            //     }
            //     res.write(data);
            //     res.end();
            // });

            // WITH CALLBACK:
            // fs.readFile('./views/cats.html', {encoding: 'utf8'}, (err, data) => {
            //     if (err) {
            //         return res.end();
            //     }

            //     res.write(data);
            //     res.end();
            // });

            // WITH PROMISE:
            readFileAsync('./views/cats.html')
                .then((data) => {
                    res.write(data);
                    res.end();
                })


            pubSub.publish('cats', queryParams.name);
            // eventEmitter.emit('cats', queryParams.name);
            break;
        case '/dogs':
            res.writeHead(200, {
                'Content-Type': 'text/plain',
            });
            res.write('Hello dogs!');
            res.end();
            break;
        default:
            res.writeHead(404, {
                'Content-Type': 'text/plain',
            });
            res.end();
            break;
    }
}

const server = http.createServer(requestHandler);

server.listen(port, () => console.log(`Server is listening on port ${port}...`));