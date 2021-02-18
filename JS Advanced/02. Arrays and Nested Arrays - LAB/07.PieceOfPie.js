function solve(array, startItem, finishItem) {
    const startIndex = array.indexOf(startItem);
    const endIndex = array.indexOf(finishItem);

    const newArray = array.splice(startIndex, endIndex - startIndex + 1);

    return newArray;
}

console.log(solve(['Apple Crisp',
    'Mississippi Mud Pie',
    'Pot Pie',
    'Steak and Cheese Pie',
    'Butter Chicken Pie',
    'Smoked Fish Pie'],
    'Pot Pie',
    'Smoked Fish Pie'
));