function solve() {
    const instance = {};

    instance.extend = function(template) {
        Object.entries(template).forEach(([key, value]) => {
            if(typeof value === 'function') {
                Object.getPrototypeOf(instance)[key] = value;
            } else {
                instance[key] = value;
            }
        })
    };

    return instance;
}

// function solve() {
//     const prototype = {};
//     const instance = Object.create(prototype);

//     instance.extend = function(template) {
//         Object.entries(template).forEach(([key, value]) => {
//             if(typeof value === 'function') {
//                 prototype[key] = value;
//             } else {
//                 instance[key] = value;
//             }
//         })
//     };

//     return instance;
// }