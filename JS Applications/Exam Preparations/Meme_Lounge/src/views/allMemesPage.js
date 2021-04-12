import { html } from '../../node_modules/lit-html/lit-html.js';
import { getAllMemes } from '../api/data.js';

const template = (data) => html`
<section id="meme-feed">
    <h1>All Memes</h1>
    <div id="memes">
        <!-- Display : All memes in database ( If any ) -->
        ${data.map(memeTemplate)}
    </div>
</section>`;

const memeTemplate = (data) => html`
<div class="meme">
    <div class="card">
        <div class="info">
            <p class="meme-title">${data.title}</p>
            <img class="meme-image" alt="meme-img" src=${data.imageUrl}>
        </div>
        <div id="data-buttons">
            <a class="button" href=${`/data/memes/${data._id}`}>Details</a>
        </div>
    </div>
</div>`;

export async function allMemesPage(context) {
    const allMemes = await getAllMemes();

    if (allMemes.length == 0) {
        context.render(html`<p class="no-memes">No memes in database.</p>`);
    } else {
        context.render(template(allMemes));
    }
}