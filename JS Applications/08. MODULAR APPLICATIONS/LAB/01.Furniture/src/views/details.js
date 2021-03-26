import { html } from '../../node_modules/lit-html/lit-html.js';
import { deleteFurniture, getFurnitureById } from '../api/data.js';

import { createModal } from '../modal.js';


const detailsTemplate = (data, isOwner, onDelete) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Furniture Details</h1>
    </div>
</div>
<div class="row space-top">
    <div class="col-md-4">
        <div class="card text-white bg-primary">
            <div class="card-body">
                <img src=${data.img} />
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <p>Make: <span>${data.make}</span></p>
        <p>Model: <span>${data.model}</span></p>
        <p>Year: <span>${data.year}</span></p>
        <p>Description: <span>${data.description}</span></p>
        <p>Price: <span>${data.price}</span></p>
        ${data.material ? html`<p>Material: <span>${data.material}</span></p>` : ''}
        ${isOwner ? html`
        <div>
            <a href=${`/edit/${data._id}`} class="btn btn-info">Edit</a>
            <a @click=${onDelete} href="javascript:void(0)" class="btn btn-red">Delete</a>
        </div>` : ''}
    </div>
</div>
`;

export async function detailsPage(context) {
    const data = await getFurnitureById(context.params.id);
    const isOwner = sessionStorage.getItem('userId') == data._ownerId;
    context.render(detailsTemplate(data, isOwner, onDelete));

    async function onDelete() {
        createModal('Are you sure you want to delete this record?', onChoise);

        async function onChoise(choise) {
            if(choise == true) {
                await deleteFurniture(data._id);
                context.page.redirect('/');
            }
        }
    }
}