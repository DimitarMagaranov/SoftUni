import { html } from '../../node_modules/lit-html/lit-html.js';
import { getMemeById } from '../api/data.js';
import { editMemeById } from '../api/data.js';
import { notify } from '../notification.js';

const template = (data, onSubmit) => html`
<section id="edit-meme">
    <form @submit=${onSubmit} id="edit-form">
        <h1>Edit Meme</h1>
        <div class="container">
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title" .value=${data.title}>
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description">${data.description}</textarea>
            <label for="imageUrl">Image Url</label>
            <input id="imageUrl" type="text" placeholder="Enter Meme ImageUrl" name="imageUrl" .value=${data.imageUrl}>
            <input type="submit" class="registerbtn button" value="Edit Meme">
        </div>
    </form>
</section>`;

export async function editPage(context) {
    const data = await getMemeById(context.params.id);
    context.render(template(data, onSubmit));

    async function onSubmit(ev) {
        ev.preventDefault();

        const formData = new FormData(ev.target);
        const title = formData.get('title');
        const description = formData.get('description');
        const imageUrl = formData.get('imageUrl');

        try {
            if(title == '' || description == '' || imageUrl == '') {
                throw new Error('All fields are required!');
            }
        
            await editMemeById(data._id, {title, description, imageUrl});
    
            context.setUserNav();
            context.page.redirect(`/data/memes/${data._id}`);

        } catch (err) {
            notify(err.message);
            context.render(template({title, description, imageUrl}, onSubmit));
        }
    }
}