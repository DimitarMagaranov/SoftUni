class Hex {
    constructor (value) {
        this.value = value;
    }

    get value() {
        return this._value;
    }

    set value(value) {
        if(typeof value !== 'number') {
            throw new Error('Value must be a number');
        }

        this._value = value;
    }

    valueOf() {
        return this._value;
    }

    toString() {
        return `0x${this._value.toString(16).toUpperCase()}`;
    }

    plus(value) {
        return new Hex(this._value + value);
    }

    minus(value) {
        return new Hex(this._value - value);
    }

    parse(value) {
        return parseInt(Number(value), 10);
    }
}

let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString()==='0xF');


