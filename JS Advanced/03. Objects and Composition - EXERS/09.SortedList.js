function createSortedList() {
    return {
        list: [],
        size: 0,
        add(number) {
            this.list.push(number);
            this.list.sort((a, b) => a - b);
            this.size++;
        },
        remove(index) {
            if (this.list.length > 0 && index >= 0 && index < this.list.length) {
                this.list.splice(index, 1);
                this.size--;
            }
        },
        get(index) {
            if (this.list.length > 0 && index >= 0 && index < this.list.length) {
                return this.list[index];
            }
        },
    };
}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
console.log(list.size);
