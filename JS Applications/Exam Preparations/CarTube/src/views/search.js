import { html } from '../../node_modules/lit-html/lit-html.js';
import { getListingsByYear } from '../api/data.js';
import { listingTemplate } from './common/listingTemplate.js';


const template = (cars, onSearch, year) => html`
<section id="search-cars">
    <h1>Filter by year</h1>

    <div class="container">
        <input id="search-input" type="text" name="search" placeholder="Enter desired production year" .value=${year || ''}>
        <button @click=${onSearch} class="button-list">Search</button>
    </div>

    <h2>Results:</h2>
    <div id="resultsContainer" class="listings">
        ${cars.length > 0 ? cars.map(listingTemplate) : html`<p class="no-cars"> No results.</p>`}
    </div>
</section>`;

export async function searchPage(context) {
    const year = Number(context.querystring.split('=')[1]);
    const cars = Number.isNaN(year) ? [] : await getListingsByYear(year);
    context.render(template(cars, onSearch, year));

    async function onSearch() {
        const query = Number(document.getElementById('search-input').value);
        if(Number.isNaN(query) == false) {
            context.page.redirect('/search?query=' + query);
        } else {
            alert('Year must be a positive number!');
        }
    }
}