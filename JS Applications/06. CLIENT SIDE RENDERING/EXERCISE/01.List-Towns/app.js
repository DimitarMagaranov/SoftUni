import { html, render } from '../node_modules/lit-html/lit-html.js';

const listTemplate = (data) => html`
<ul>
    ${data.map(t => html`<li>${t}</li>`)}
</ul>`; 

const form = document.querySelector('form');
form.addEventListener('submit', onSubmit);

function onSubmit(ev) {
    ev.preventDefault();
    
    const container = document.getElementById('root');

    const input = ev.target.querySelector('input').value;
    const towns = input.split(', ');

    const ul = listTemplate(towns);

    form.reset();

    render(ul, container);
}

