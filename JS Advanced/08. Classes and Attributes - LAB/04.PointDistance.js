class Point {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }

    get x() {
        return this._x;
    }

    set x(value) {
        this._x = value;
    }

    get y() {
        return this._y;
    }

    set y(value) {
        this._y = value;
    }

    distance(p1, p2) {
        var a = p1.x - p2.x;
        var b = p1.y - p2.y;

        return Math.sqrt(a * a + b * b);
    }
}

let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
// console.log(Point.distance(p1, p2));
console.log(p1.distance(p1, p2));
