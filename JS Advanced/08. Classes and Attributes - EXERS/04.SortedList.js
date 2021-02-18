class List {
    constructor() {
        this.list = [];
        this.size = 0;
    }

    add(value) {
        if (typeof value !== 'number') {
            return new Error('Value must be a number.');
        }

        this.list.push(value);
        this.list.sort((a, b) => a - b);
        this.size++;
    }

    remove(index) {
        if (index < 0 || index >= this.list.length) {
            throw new Error(`Index doesn't exist.`);
        }

        this.list.splice(index, 1);
        this.size--;
    }

    get(index) {
        if (index < 0 || index >= this.list.length) {
            throw new Error(`Index doesn't exist.`);
        }

        return this.list[index];
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));

