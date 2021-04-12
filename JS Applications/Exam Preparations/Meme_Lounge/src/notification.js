import { html, render } from '../node_modules/lit-html/lit-html.js';

const notifTemplate = (message) => html`
<div id="errorBox" class="notification">
    <span>${message}</span>
</div>`;

const container = document.getElementById('notifications');

export function notify(message) {
    render(notifTemplate(message), container);
    document.getElementById('errorBox').style.display = 'block';
    setTimeout(clearNotifications, 3000);
}

export function clearNotifications() {
    render('', container);
}