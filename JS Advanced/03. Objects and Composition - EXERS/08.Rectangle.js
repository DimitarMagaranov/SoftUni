function rectangle(width, height, color) {
    return {
        width,
        height,
        color: capitalize(color),
        calcArea: () => {
            return width * height;
        }
    }

    function capitalize (input) {
        return input[0].toUpperCase() + input.slice(1);
    }
}

let rect = rectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());
