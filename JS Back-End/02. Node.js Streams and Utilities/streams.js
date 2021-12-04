const fs = require('fs');

const zlib = require('zlib');
const readStream = fs.createReadStream('./views/cats.html', {encoding: 'utf8'});
const writeStream = fs.createWriteStream('./result.txt', {encoding: 'utf8'});
const gzip = zlib.createGzip();

// readStream.on('data', (data) => {
//     writeStream.write(data);
// });

// readStream.on('end', () => {
//     console.log('reading ended');
//     writeStream.end();
// })

readStream.pipe(gzip).pipe(writeStream);