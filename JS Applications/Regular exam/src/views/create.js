import { html } from '../../node_modules/lit-html/lit-html.js';
import { createArticle } from '../api/data.js';

const template = (onSubmit) => html`
<section id="create-page" class="content">
    <h1>Create Article</h1>

    <form @submit=${onSubmit} id="create" action="#" method="">
        <fieldset>
            <p class="field title">
                <label for="create-title">Title:</label>
                <input type="text" id="create-title" name="title" placeholder="Enter article title">
            </p>

            <p class="field category">
                <label for="create-category">Category:</label>
                <input type="text" id="create-category" name="category" placeholder="Enter article category">
            </p>
            <p class="field">
                <label for="create-content">Content:</label>
                <textarea name="content" id="create-content"></textarea>
            </p>

            <p class="field submit">
                <input class="btn submit" type="submit" value="Create">
            </p>

        </fieldset>
    </form>
</section>`;

export async function createPage(context) {
    context.render(template(onSubmit));

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
                await createArticle({ title, category, content });

                context.setUserNav();
                context.page.redirect('/');
            } else {
                throw new Error('The category must be one of JavaScript, C#, Java, or Python!');
            }
        } catch (err) {
            alert(err.message);
            throw err;
        }
    }
}