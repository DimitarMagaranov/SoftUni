function solve() {
    const inputDiv = document.getElementById('container');
    const nameInputField = inputDiv.children[0];
    const hallInputField = inputDiv.children[1];
    const ticketPriceInputField = inputDiv.children[2];
    const moviesUl = document.getElementById('movies').children[1];
    const archiveSection = document.getElementById('archive');
    const archiveUl = archiveSection.querySelector('ul');

    document.getElementsByTagName('body')[0].addEventListener('click', onclick);

    function onclick(ev) {
        ev.preventDefault();

        if (ev.target.tagName === 'BUTTON') {
            if (ev.target.textContent === 'On Screen') {
                if (!nameInputField.value || !hallInputField.value || !Number(ticketPriceInputField.value)) {
                    return;
                }
                createMovie(nameInputField.value, hallInputField.value, Number(ticketPriceInputField.value));
                clearInputs();
            } else if (ev.target.textContent === 'Archive') {
                const li = ev.target.parentNode.parentNode;
                archivingMovie(li);
            } else if (ev.target.textContent === 'Delete') {
                ev.target.parentNode.remove();
            } else if (ev.target.textContent === 'Clear') {
                const lis = Array.from(ev.target.parentNode.querySelectorAll('li'));
                lis.forEach(x => x.remove());
            }
        }
    }

    function archivingMovie(li) {
        const input = li.querySelector('div input');

        const countOfTickets = Number(input.value);

        if (!input.value || !countOfTickets) {
            return;
        }

        const span = createElement('span', li.getElementsByTagName('span')[0].textContent);
        const price = Number(li.querySelector('div strong').textContent);
        const strong = createElement('strong', `Total amount: ${(price * Number(input.value)).toFixed(2)}`);
        const button = createElement('button', 'Delete');
        const liArchive = createElement('li', span, strong, button);

        archiveUl.appendChild(liArchive);

        li.remove();
    }

    function createMovie(name, hall, price) {
        const span = createElement('span', name);
        const strong = createElement('strong', `Hall: ${hall}`);
        const divStrong = createElement('strong', `${price}`);
        const input = createElement('input');
        input.setAttribute('placeholder', 'Tickets Sold');
        const button = createElement('button', 'Archive');
        const div = createElement('div', divStrong, input, button);
        const li = createElement('li', span, strong, div);

        moviesUl.appendChild(li);
    }

    function clearInputs() {
        nameInputField.value = '';
        hallInputField.value = '';
        ticketPriceInputField.value = '';
    }

    function createElement(type, ...content) {
        const result = document.createElement(type);
    
        content.forEach(e => {
            if (typeof e == 'string') {
                const node = document.createTextNode(e);
                result.appendChild(node);
            } else {
                result.appendChild(e);
            }
        });
    
        return result;
    }
}