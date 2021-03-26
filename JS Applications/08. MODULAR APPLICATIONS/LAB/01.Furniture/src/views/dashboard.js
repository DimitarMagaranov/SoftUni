import { html } from '../../node_modules/lit-html/lit-html.js';
import { until } from '../../node_modules/lit-html/directives/until.js';
import { getAllFurniture } from '../api/data.js';
import { furnitureTemplate } from './common/item.js';

const dashboardTemplate = (data, searchParam, onSearch) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Welcome to Furniture System</h1>
        <p>Select furniture from the catalog to view details.</p>
        <div style="float:right">
            <input id="searchInput" name="search" type="text" .value=${searchParam}>
            <button @click=${onSearch}>Search</button>
        </div>
    </div>
</div>
<div class="row space-top">
    ${data.map(furnitureTemplate)}
</div>`;

const loaderTemplate = html`<p>Loading&hellip;</p>`;

export async function dashboardPage(context) {
    let searchParam = context.querystring.split('=')[1] || '';
    
    context.render(until(populateTemplate(), loaderTemplate));

    function onSearch(ev) {
        const searchValue = encodeURIComponent(document.getElementById('searchInput').value);
        
        context.page.redirect(`/?search=${searchValue}`);
    }

    async function populateTemplate() {
        const data = await getAllFurniture(searchParam);
        return dashboardTemplate(data, searchParam, onSearch);
    }
}

