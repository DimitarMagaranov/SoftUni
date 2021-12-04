const http = require('http');
const url = require('url');
const fs = require('fs');
const querystring = require('querystring');

const port = 5000;

function requestHandler(req, res) {
    let parsedUrl = url.parse(req.url);
    let queryParams = querystring.parse(parsedUrl.query);

    switch (parsedUrl.pathname) {
        case '/cats':
            res.writeHead(200, {
                'Content-Type': 'text/html',
            });
            
            fs.readFile('./views/cats.html', function(err, data) {
                if (err) {
                    console.log('some error');
                    return;
                }
                res.write(data);
                res.end();
            });
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