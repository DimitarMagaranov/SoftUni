import { html } from '../../node_modules/lit-html/lit-html.js';
import { getRecentArticles } from '../api/data.js';

const template = (javaScriptArticles, pythonArticles, javaArticles, cSharpArticles) => html`
<section id="home-page" class="content">
    <h1>Recent Articles</h1>
    <section class="recent js">
        <h2>JavaScript</h2>
        ${javaScriptArticles.length > 0 ? javaScriptArticles.map(articleTemplate) : html`<h3 class="no-articles">No articles yet</h3>`}
    </section>
    <section class="recent csharp">
        <h2>C#</h2>
        ${cSharpArticles.length > 0 ? cSharpArticles.map(articleTemplate) : html`<h3 class="no-articles">No articles yet</h3>`}
    </section>
    <section class="recent java">
        <h2>Java</h2>
        ${javaArticles.length > 0 ? javaArticles.map(articleTemplate) : html`<h3 class="no-articles">No articles yet</h3>`}
    </section>
    <section class="recent python">
        <h2>Python</h2>
        ${pythonArticles.length > 0 ? pythonArticles.map(articleTemplate) : html`<h3 class="no-articles">No articles yet</h3>`}
    </section>
</section>`;

const articleTemplate = (data) => html`
<article>
    <h3>${data.title}</h3>
    <p>${data.content}</p>
    <a href=${`/details/${data._id}`} class="btn details-btn">Details</a>
</article>`;

export async function homePage(context) {
    const articles = await getRecentArticles();
    // const categories = {
    //     'JavaScript': [articles.filter(x => x.category == 'JavaScript')],
    //     'Python': [articles.filter(x => x.category == 'Python')],
    //     'Java': [articles.filter(x => x.category == 'Java')],
    //     'C#': [articles.filter(x => x.category == 'C#')]
    // };
    const javaScriptArticles = articles.filter(x => x.category == 'JavaScript');
    const pythonArticles = articles.filter(x => x.category == 'Python');
    const javaArticles = articles.filter(x => x.category == 'Java');
    const cSharpArticles = articles.filter(x => x.category == 'C#');

    console.log(pythonArticles)

    context.render(template(javaScriptArticles, pythonArticles, javaArticles, cSharpArticles));
}