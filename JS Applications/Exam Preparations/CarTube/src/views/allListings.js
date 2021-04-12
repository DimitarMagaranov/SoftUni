import { html } from '../../node_modules/lit-html/lit-html.js';
import { getAllListings } from '../api/data.js';
import { getListingsCount } from '../api/data.js';
import { listingTemplate } from './common/listingTemplate.js';

const template = (data, page, pages) => html`
<section id="car-listings">
    <h1>Car Listings</h1>
    <div class="listings">
        <div>
            ${page == 1 ? '' : html`<a class="button-list" href="/allListings?page=${page - 1}">&lt; Prev</a>`}
            Page ${page} / ${pages}
            ${page == pages ? '' : html`<a class="button-list" href="/allListings?page=${page + 1}"}>&gt; Next</a>`}
        </div>
        <!-- Display all records -->
        ${data.length > 0 ? data.map(listingTemplate) : html`<p class="no-cars">No cars in database.</p>`}
    </div>
</section>`;

export async function allListingsPage(context) {
    const page = Number(context.querystring.split('=')[1]) || 1;

    const count = await getListingsCount();
    const pages = Math.ceil(count / 3);
    const listings = await getAllListings(page);
    context.render(template(listings, page, pages));
}