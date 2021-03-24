import { render } from './node_modules/lit-html/lit-html.js';
import cardTemplate from './card.js';
import { contacts } from './contacts.js';


const container = document.getElementById('contacts');
container.addEventListener('click', onClick);

contacts.forEach(c => c.isVisible = false);

const cards = contacts.map(cardTemplate);

render(cards, container);

function onClick(ev) {
    if (ev.target.classList.contains('detailsBtn')) {
        const id = ev.target.parentNode.querySelector('.details').id;
        const contact = contacts.find(c => c.id == id);
        contact.isVisible = !contact.isVisible;
        const result = contacts.map(cardTemplate);
        render(result, container);
    }
}