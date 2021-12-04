function middleware(req, res, next) {
    console.log('hello from middleware');

    console.log(req.params);

    if (req.params.id) {
        return next();
    }

    res.status(403).send('You need to specify id!');
}


module.exports = middleware;