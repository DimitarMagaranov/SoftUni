function deepCopy(target) {
    if(Array.isArray(target)) {
        return target.map(deepCopy);
    } else if(typeof target == 'object') {
        return [...Object.entries(target)].reduce((a, [k, v]) => Object.assign(a, {[k]: deepCopy(v)}), {});
    } else {
        return target;
    }
}

let arr = [1, 2, 3, 4];

let newArr = deepCopy(arr);