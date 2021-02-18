const { expect } = require('chai');
const ChristmasMovies = require('./02. Christmas Movies_Resources');

describe("ChristmasMovies", function () {
    describe("buyMovie", function () {
        it("check if the movie is added successfull", function () {
            const instance = new ChristmasMovies();
            const movieName = 'Movie1';
            const actors = ['Pesho', 'Gosho', 'Maria', 'Gosho'];

            const message = `You just got Movie1 to your collection in which Pesho, Gosho, Maria are taking part!`
            expect(instance.buyMovie(movieName, actors)).to.equal(message);
        });

        it('check if buyMovie throws error', function () {
            const instance = new ChristmasMovies();
            const movieName = 'Movie1';
            const actors = ['Pesho', 'Gosho', 'Maria', 'Gosho'];
            instance.buyMovie(movieName, actors);

            expect(function () { instance.buyMovie(movieName, actors) }).to.throw(Error);
        });
    });

    describe('discardMovie', function () {
        it('check if movie not exist in the collection', function() {
            const instance = new ChristmasMovies();
            expect(function() {instance.discardMovie('Movie1')}).to.throw(Error);
        });

        it('check if the movie is not watched', function() {
            const instance = new ChristmasMovies();
            const movieName = 'Movie1';
            const actors = ['Pesho', 'Gosho', 'Gosho'];
            instance.buyMovie(movieName, actors);

            expect(function() {instance.discardMovie(movieName)}).to.throw(Error);
        });
        it('check if discardMovie discard the added and watched movie', function() {
            const instance = new ChristmasMovies();
            const movieName = 'Movie1';
            const actors = ['Pesho', 'Gosho', 'Gosho'];
            instance.buyMovie(movieName, actors);
            instance.watchMovie(movieName);

            expect(instance.discardMovie(movieName)).to.equal('You just threw away Movie1!');
        });
    });

    describe('watchMovie', function() {
        it('check if watchMovie throws Error', function() {
            const instance = new ChristmasMovies();
            expect(function() {instance.watchMovie('Movie')}).to.throw(Error);
        });

        it('check if watch movie working successfull first', function() {
            const instance = new ChristmasMovies();
            const movieName = 'Movie1';
            const actors = ['Pesho', 'Gosho', 'Gosho'];
            instance.buyMovie(movieName, actors);
            instance.watchMovie(movieName);

            const result1 = instance.watched[movieName];
            expect(result1).to.equal(1);
            
            instance.watchMovie(movieName);
            const result2 = instance.watched[movieName];
            expect(result2).to.equal(2);
        });

        it('check if watch movie working successfull second', function() {
            const instance = new ChristmasMovies();
            const movieName = 'Movie1';
            const actors = ['Pesho', 'Gosho', 'Gosho'];
            instance.buyMovie(movieName, actors);
            instance.watchMovie(movieName);
            instance.watchMovie(movieName);
            const result2 = instance.watched[movieName];
            expect(result2).to.equal(2);
        });
    });

    describe('favouriteMovie', function() {
        it('check if favouriteMovie throws Error', function() {
            const instance = new ChristmasMovies();
            expect(function() {instance.favouriteMovie()}).to.throw(Error);
        });

        it('check if favouriteMovie returns movie', function() {
            const instance = new ChristmasMovies();
            const movie1Name = 'Movie1';
            const actors1 = ['Pesho', 'Gosho', 'Gosho'];
            const movie2Name = 'Movie2';
            const actors2 = ['Pesho', 'Gosho', 'Misho'];
            instance.buyMovie(movie1Name, actors1);
            instance.buyMovie(movie2Name, actors2);
            instance.watchMovie(movie1Name);
            instance.watchMovie(movie2Name);
            instance.watchMovie(movie2Name);

            const result = 'Your favourite movie is Movie2 and you have watched it 2 times!';
            expect(instance.favouriteMovie()).to.equal(result);
        });
    });

    describe('mostStarredActor', function() {
        it('check if mostStarredActor throws Error', function() {
            const instance = new ChristmasMovies();
            expect(function() {instance.mostStarredActor()}).to.throw(Error);
        });

        it('check if mostStarredActor is working successfully', function() {
            const instance = new ChristmasMovies();
            const movie1Name = 'Movie1';
            const actors1 = ['Pesho', 'Gosho', 'Stefan'];
            const movie2Name = 'Movie2';
            const actors2 = ['Pesho', 'Stan'];
            instance.buyMovie(movie1Name, actors1);
            instance.buyMovie(movie2Name, actors2);

            const result = `The most starred actor is Pesho and starred in 2 movies!`;
            expect(instance.mostStarredActor()).to.equal(result);
        });
    })
});
