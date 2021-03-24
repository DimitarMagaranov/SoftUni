import { html, render } from '../node_modules/lit-html/lit-html.js';
import { styleMap } from '../node_modules/lit-html/directives/style-map.js';
import { cats } from './catSeeder.js';

const catTemplate = (cat) => html`
<li>
    <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
    <div class="info">
        <button class="showBtn">${cat.info ? 'Hide' : 'Show'} status code</button>
        <div class="status" style=${styleMap(cat.info ? {} : {display: 'none'})} id=${cat.id}>
            <h4>Status Code: ${cat.statusCode}</h4>
            <p>${cat.statusMessage}</p>
        </div>
    </div>
</li>`;


const container = document.getElementById('allCats');
cats.forEach(c => c.info = false);

update();

function update() { 
    const ul = html`
    <ul @click=${onClick}>
        ${cats.map(catTemplate)}
    </ul>`;

    render(ul, container);
}

function onClick(ev) {
    if(ev.target.tagName == 'BUTTON') {
        const catId = ev.target.parentNode.querySelector('div').id;
        const cat = cats.find(c => c.id == catId);

        cat.info = !cat.info;
        update();
    }
}