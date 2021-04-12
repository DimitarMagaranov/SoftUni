import { html } from '../../node_modules/lit-html/lit-html.js';
import { getAllMemesByUserId } from '../api/data.js';

const template = (memes, username, email, gender) => html`
<section id="user-profile-page" class="user-profile">
    <article class="user-info">
        <img id="user-avatar-url" alt="user-profile" src=${gender == 'female' ? "/images/female.png" : "/images/male.png"}>
        <div class="user-content">
            <p>Username: ${username}</p>
            <p>Email: ${email}</p>
            <p>My memes count: ${memes.length}</p>
        </div>
    </article>
    <h1 id="user-listings-title">User Memes</h1>
    <div class="user-meme-listings">
        <!-- Display : All created memes by this user (If any) -->
        ${memes.map(memeTemplate)}

        <!-- Display : If user doesn't have own memes  -->
        ${memes.length == 0 ? html`<p class="no-memes">No memes in database.</p>` : ''}
    </div>
</section>`;

const memeTemplate = (data) => html`
<div class="user-meme">
    <p class="user-meme-title">${data.title}</p>
    <img class="userProfileImage" alt="meme-img" src=${data.imageUrl}>
    <a class="button" href=${`/data/memes/${data._id}`}>Details</a>
</div>`;

export async function userPage(context) {
    const memes = await getAllMemesByUserId(sessionStorage.getItem('userId'));
    const gender = sessionStorage.getItem('userGender');
    const username = sessionStorage.getItem('username');
    const email = sessionStorage.getItem('email');

    context.render(template(memes, username, email, gender));
}