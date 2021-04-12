import { html } from '../../node_modules/lit-html/lit-html.js';
import { getArticleById } from '../api/data.js';
import { deleteArticleById } from '../api/data.js';

const template = (data, isOwner, onDelete) => html`
<section id="details-page" class="content details">
    <h1>${data.title}</h1>

    <div class="details-content">
        <strong>Published in category ${data.category}</strong>
        <p>${data.content}</p>

        <div class="buttons">
            ${isOwner ? html`
            <a @click=${onDelete} href="javascript:void(0)" class="btn delete">Delete</a>
            <a href=${`/edit/${data._id}`} class="btn edit">Edit</a>` : ''}
            <a href="/catalogue" class="btn edit">Back</a>
        </div>
    </div>
</section>`;

export async function detailsPage(context) {
    const id = context.params.id;
    const data = await getArticleById(id);
    const isOwner = sessionStorage.getItem('userId') == data._ownerId;
    context.render(template(data, isOwner, onDelete));

    async function onDelete() {
        const confirmed = confirm('Are you sure you want to delete this article?');
        if (confirmed) {
            await deleteArticleById(id);
            context.page.redirect('/');
        }
    }
}