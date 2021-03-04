function attachEvents() {
    const forecastDiv = document.getElementById('forecast');
    const locationInput = document.getElementById('location');

    const conditionSymbols = {
        'Sunny': '☀',
        'Partly sunny': '⛅',
        'Overcast': '☁',
        'Rain': '☂',
        'Degrees': '°',
    }

    document.getElementById('submit').addEventListener('click', submit);

    async function submit() {
        const url = 'http://localhost:3030/jsonstore/forecaster/locations';
        const response = await fetch(url);
        const cities = await response.json();
        const city = cities.find(x => x.name === locationInput.value);

        try {
            const currentConditionObj = await getCurrentConditions(city.code);
            const threeDayForecastObj = await getThreeDayForecast(city.code);

            createCurrentConditions(currentConditionObj);
            createThreeDayForecast(threeDayForecastObj);

            forecastDiv.style.display = 'block';
            locationInput.value = '';
        } catch(error) {
            forecastDiv.textContent = 'Error';
        }
    }

    function createThreeDayForecast(threeDayForecastObj) {
        const upcomingDiv = forecastDiv.children[1];

        const div = createElement('div')
        div.classList.add('forecast-info');

        for(let dayForecast of threeDayForecastObj.forecast) {
            const symbolSpan = createElement('span', conditionSymbols[dayForecast.condition]);
            symbolSpan.classList.add('symbol');
            const tempString = `${dayForecast.low + conditionSymbols.Degrees}/${dayForecast.high + conditionSymbols.Degrees}`;
            const degreesSpan = createElement('span', tempString);
            degreesSpan.classList.add('forecast-data');
            const forecastNameSpan = createElement('span', dayForecast.condition);
            forecastNameSpan.classList.add('forecast-data');
            const parentSpan = createElement('span', symbolSpan, degreesSpan, forecastNameSpan);
            parentSpan.classList.add('upcoming');
            div.appendChild(parentSpan);
        }

        if (upcomingDiv.children[1]) {
            upcomingDiv.children[1].remove();
        }

        upcomingDiv.appendChild(div);
    }

    function createCurrentConditions(currentConditionObj) {
        const currentWhetherDiv = forecastDiv.children[0];

        const nameSpan = createElement('span', currentConditionObj.name);
        nameSpan.classList.add('forecast-data');
        const tempString = `${currentConditionObj.forecast.low + conditionSymbols.Degrees}/${currentConditionObj.forecast.high + conditionSymbols.Degrees}`;
        const tempSpan = createElement('span', tempString);
        tempSpan.classList.add('forecast-data');
        const whetherSpan = createElement('span', currentConditionObj.forecast.condition);
        whetherSpan.classList.add('forecast-data');
        const conditionSpan = createElement('span', nameSpan, tempSpan, whetherSpan);
        conditionSpan.classList.add('condition');
        const conditionSymbolSpan = createElement('span', conditionSymbols[currentConditionObj.forecast.condition]);
        conditionSymbolSpan.classList.add('condition');
        conditionSymbolSpan.classList.add('symbol');
        const currentConditionDiv = createElement('div', conditionSymbolSpan, conditionSpan);
        currentConditionDiv.classList.add('forecast');

        if (currentWhetherDiv.children[1]) {
            currentWhetherDiv.children[1].remove();
        }

        currentWhetherDiv.appendChild(currentConditionDiv);
    }

    async function getCurrentConditions(code) {
        const url = 'http://localhost:3030/jsonstore/forecaster/today/' + code;
        const response = await fetch(url);
        return await response.json();
    }

    async function getThreeDayForecast(code) {
        const url = 'http://localhost:3030/jsonstore/forecaster/upcoming/' + code;
        const response = await fetch(url);
        return await response.json();
    }

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

attachEvents();