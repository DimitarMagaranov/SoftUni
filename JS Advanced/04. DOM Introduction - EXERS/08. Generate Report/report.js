function generateReport() {
    const headers = document.querySelector('thead tr').children;
    let headerNamesWithIndexes = {};

    const result = [];

    for (let i = 0; i < headers.length; i++) {
        if (headers[i].querySelector('input').checked) {
            headerNamesWithIndexes[headers[i].textContent.trim()] = i;
        }
    }

    const rows = Array.from(document.querySelector('tbody').children);

    console.log(rows[0].children);

    for (let row of rows) {
        let object = {};

        for (const [key, value] of Object.entries(headerNamesWithIndexes)) {
            object[key.toLowerCase()] = row.children[value].textContent;
        }

        result.push(object);
    }

    document.getElementById('output').value = JSON.stringify(result);
}