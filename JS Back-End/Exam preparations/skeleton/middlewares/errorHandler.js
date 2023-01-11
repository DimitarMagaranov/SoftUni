const errorHandler = (err, req, res, next) => {
    err.status = err.status || 500;
    err.message = err.message || 'Something went wrong';

    console.log(err);

    res.status(err.status).render('home', { error: err });
    // TODO add page to   render
};

module.exports = errorHandler; 