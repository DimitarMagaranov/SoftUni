function addDestination() {
    const cityInputField = document.getElementsByTagName('input')[0];
    const countryInputField = document.getElementsByTagName('input')[1];
    const season = document.getElementById('seasons').value;
    const tbody = document.getElementById('destinations').children[1];
    const city = cityInputField.value;
    const country = countryInputField.value;

    if (city === '' || country === '') {
        return;
    }

    const cityText = `${city[0].toUpperCase()}` + `${city.slice(1, city.length)}`;
    const countryText = `${country[0].toUpperCase()}` + `${country.slice(1, country.length)}`;
    const td1 = createElement('td', `${cityText}, ${countryText}`);
    const td2 = createElement('td', `${season[0].toUpperCase()}` + `${season.slice(1, season.length)}`);
    const tr = createElement('tr', td1, td2);
    tbody.appendChild(tr);

    cityInputField.value = '';
    countryInputField.value = '';

    document.getElementById(season.toLowerCase()).value++;

    function createElement(type, ...content) {
        const result = document.createElement(type);

        content.forEach(e => {
            if (typeof e == 'string' || typeof e == 'number') {
                const node = document.createTextNode(e.toString());
                result.appendChild(node);
            } else {
                result.appendChild(e);
            }
        });

        return result;
    }
}