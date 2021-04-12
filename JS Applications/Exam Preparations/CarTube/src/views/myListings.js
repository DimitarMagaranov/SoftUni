import { html } from '../../node_modules/lit-html/lit-html.js';
import { getMyListings } from '../api/data.js';
import { listingTemplate } from './common/listingTemplate.js';

const template = (data) => html`
<section id="my-listings">
    <h1>My car listings</h1>
    <div class="listings">
        <!-- Display all records -->
        ${data.length > 0 ? data.map(listingTemplate) : html`<p class="no-cars"> You haven't listed any cars yet.</p>`}
    </div>
</section>`;

export async function myListingsPage(context) {
    const data = await getMyListings();
    context.render(template(data));
}