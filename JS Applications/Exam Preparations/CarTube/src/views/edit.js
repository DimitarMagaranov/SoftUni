import {html} from '../../node_modules/lit-html/lit-html.js';
import { getListingById } from '../api/data.js';
import { editListingById } from '../api/data.js';

const template = (data, onSubmit) => html`
<section id="edit-listing">
    <div class="container">

        <form @submit=${onSubmit} id="edit-form">
            <h1>Edit Car Listing</h1>
            <p>Please fill in this form to edit an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand" value=${data.brand}>

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model" value=${data.model}>

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description" value=${data.description}>

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year" value=${data.year}>

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl" value=${data.imageUrl}>

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price" value=${data.price}>

            <hr>
            <input type="submit" class="registerbtn" value="Edit Listing">
        </form>
    </div>
</section>`;

export async function editListing(context) {
    const listing = await getListingById(context.params.id);
    context.render(template(listing, onSubmit));

    async function onSubmit(ev) {
        ev.preventDefault();

        const formData = new FormData(ev.target);
        const brand = formData.get('brand');
        const model = formData.get('model');
        const description = formData.get('description');
        const year = Number(formData.get('year'));
        const imageUrl = formData.get('imageUrl');
        const price = Number(formData.get('price'));

        try {
            if(brand == '' || model == '' || description == '' || year <= 0 || imageUrl == '' || price <= 0) {
                throw new Error('All fields are required!');
            }
        
            await editListingById(listing._id, {brand, model, description, year, imageUrl, price});
    
            context.setUserNav();
            context.page.redirect(`/details/${listing._id}`);

        } catch (err) {
            alert(err.message);
            context.render(template({brand, model, description, year, imageUrl, price}, onSubmit));
        }
    }
}