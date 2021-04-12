import { html } from '../../node_modules/lit-html/lit-html.js';
import { getArticleById } from '../api/data.js';
import { editArticleById } from '../api/data.js';

const template = (data, onSubmit) => html`
<section id="edit-page" class="content">
    <h1>Edit Article</h1>

    <form @submit=${onSubmit} id="edit" action="#" method="">
        <fieldset>
            <p class="field title">
                <label for="title">Title:</label>
                <input type="text" name="title" id="title" placeholder="Enter article title" .value=${data.title}>
            </p>

            <p class="field category">
                <label for="category">Category:</label>
                <input type="text" name="category" id="category" placeholder="Enter article category" .value=${data.category}>
            </p>
            <p class="field">
                <label for="content">Content:</label>
                <textarea name="content" id="content">${data.content}</textarea>
            </p>

            <p class="field submit">
                <input class="btn submit" type="submit" value="Save Changes">
            </p>

        </fieldset>
    </form>
</section>`;

export async function editPage(context) {
    const id = context.params.id;
    const article = await getArticleById(id);
    context.render(template(article, onSubmit));

    async function onSubmit(ev) {
        ev.preventDefault();

        const formData = new FormData(ev.target);
        const title = formData.get('title');
        const category = formData.get('category');
        const content = formData.get('content');

        try {
            if (title == '' || category == '' || content == '') {
                throw new Error('All fields are required!');
            }

            if (category == 'JavaScript' || category == 'C#' || category == 'Java' || category == 'Python') {
                await editArticleById(id, { title, category, content });

                context.setUserNav();
                context.page.redirect('/details/' + id);
            } else {
                throw new Error('The category must be one of JavaScript, C#, Java, or Python!');
            }
        } catch (err) {
            alert(err.message);
            context.render(template({title, category, content}, onSubmit));
        }
    }
}