import { html, render } from '../node_modules/lit-html/lit-html.js';

const selectTemplate = (list) => html`
<select id="menu">
    ${list.map(x => html`<option value=${x._id}>${x.text}</option>`)}
</select>`;

const container = document.getElementById('container');

initialize();

function update(list) {
    const result = selectTemplate(list);
    render(result, container);
}

async function initialize() {
    document.querySelector('form').addEventListener('submit', (ev) => createTown(ev, list))

    const response = await fetch('http://localhost:3030/jsonstore/advanced/dropdown');
    const data = await response.json();
    const list = Object.values(data);

    update(list);
};

async function createTown(ev, list) {
    ev.preventDefault();

    const formData = new FormData(ev.target);
    const name = formData.get('text');

    const response = await fetch('http://localhost:3030/jsonstore/advanced/dropdown', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ text: name })
    });

    const data = await response.json();
    list.push(data);

    update(list);
    input.value = '';
};