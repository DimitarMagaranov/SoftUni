import { html } from '../../node_modules/lit-html/lit-html.js';
import { getListingById } from '../api/data.js';
import { deleteListingById } from '../api/data.js';

const template = (data, isOwner, onDelete) => html`
<section id="listing-details">
    <h1>Details</h1>
    <div class="details-info">
        <img src=${data.imageUrl}>
        <hr>
        <ul class="listing-props">
            <li><span>Brand:</span>${data.brand}</li>
            <li><span>Model:</span>${data.model}</li>
            <li><span>Year:</span>${data.year}</li>
            <li><span>Price:</span>${data.price}$</li>
        </ul>

        <p class="description-para">${data.description}</p>

        ${isOwner ? html`
        <div class="listings-buttons">
            <a href=${`/edit/${data._id}`} class="button-list">Edit</a>
            <a @click=${onDelete} href="javascript:void(0)" class="button-list">Delete</a>
        </div>` : ''}
    </div>
</section>`;

export async function detailsPage(context) {
    const listing = await getListingById(context.params.id);
    const isOwner = sessionStorage.getItem('userId') == listing._ownerId;
    context.render(template(listing, isOwner, onDelete));

    async function onDelete() {
        const confirmed = confirm('Are you sure you want to delete this listing?');
        if (confirmed) {
            await deleteListingById(listing._id);
            context.page.redirect('/allListings');
        }
    }
}