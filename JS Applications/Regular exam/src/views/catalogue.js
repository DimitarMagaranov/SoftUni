import { html } from '../../node_modules/lit-html/lit-html.js';
import { getAllArticles } from '../api/data.js';

const template = (data) => html`
<section id="catalog-page" class="content catalogue">
    <h1>All Articles</h1>

    ${data.length > 0 ? data.map(articleTemplate) : html`<h3 class="no-articles">No articles yet</h3>`}
</section>`;

const articleTemplate = (data) => html`
<a class="article-preview" href=${`/details/${data._id}`}>
    <article>
        <h3>Topic: <span>${data.title}</span></h3>
        <p>Category: <span>${data.category}</span></p>
    </article>
</a>`;

export async function cataloguePage(context) {
    const articles = await getAllArticles();
    context.render(template(articles));
}