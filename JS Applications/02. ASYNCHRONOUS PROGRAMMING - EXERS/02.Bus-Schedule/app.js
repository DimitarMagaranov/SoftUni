function solve() {
    const infoDiv = document.getElementById('info');
    const departButton = document.getElementById('depart');
    const arriveButton = document.getElementById('arrive');

    let nextBusStop = {};
    const url = 'http://localhost:3030/jsonstore/bus/schedule/';

    async function depart() {
        const currUrl = Object.keys(nextBusStop).length === 0 ? url + 'depot' : url + nextBusStop.next;
        const response = await fetch(currUrl);
        try {
            nextBusStop = await response.json();
        } catch (error) {
            departButton.disabled = true;
            arriveButton.disabled = true;
            infoDiv.textContent = `Error`;
        }
        infoDiv.textContent = `Next stop ${nextBusStop.name}`;

        departButton.disabled = true;
        arriveButton.disabled = false;
    }

    function arrive() {
        infoDiv.textContent = `Arriving at ${nextBusStop.name}`;
        departButton.disabled = false;
        arriveButton.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();