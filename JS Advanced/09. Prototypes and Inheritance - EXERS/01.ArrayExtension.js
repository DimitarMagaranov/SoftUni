(function solve() {
    Array.prototype.last = function () {
        return this[this.length - 1];
    };

    Array.prototype.skip = function (n) {
        let array = [];

        for (let i = n; i < this.length; i++) {
            array.push(this[i]);
        }

        return array;
    };

    Array.prototype.take = function (n) {
        let array = [];

        for (let i = 0; i < n; i++) {
            array.push(this[i]);
        }

        return array;
    };

    Array.prototype.sum = function () {
        return this.reduce((a, c) => a + c);
    };

    Array.prototype.average = function () {
        return this.sum() / this.length;
    };
})();