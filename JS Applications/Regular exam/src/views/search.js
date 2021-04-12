import { html } from '../../node_modules/lit-html/lit-html.js';
import { getArticlesByTitle } from '../api/data.js';

const template = (articles, onSearch) => html`
<section id="search-page" class="content">
    <h1>Search</h1>
    <form @submit=${onSearch} id="search-form">
        <p class="field search">
            <input type="text" placeholder="Search by article title" name="search">
        </p>
        <p class="field submit">
            <input class="btn submit" type="submit" value="Search">
        </p>
    </form>
    <div class="search-container">
        ${articles.length > 0 ? articles.map(articleTemplate) : html`<h3 class="no-articles">No matching articles</h3>`}
    </div>
</section>`;

const articleTemplate = (data) => html`
<a class="article-preview" href=${`/details/${data._id}`}>
    <article>
        <h3>Topic: <span>${data.title}</span></h3>
        <p>Category: <span>${data.category}</span></p>
    </article>
</a>`;

export async function searchPage(context) {
    const title = context.querystring.split('=')[1];
    const articles = title ? await getArticlesByTitle(title) : [];
    context.render(template(articles, onSearch));

    async function onSearch(ev) {
        ev.preventDefault();
        const formData = new FormData(ev.target);
        const query = formData.get('search');
        if(query) {
            context.page.redirect('/search?query=' + query);
        } else {
            alert('There is something wrong!');
        }
    }
}