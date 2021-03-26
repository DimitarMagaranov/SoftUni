import {html, render} from '../node_modules/lit-html/lit-html.js';

const notifTemplate = (message) => html`
<section @click=${clearNotifications} id="notification">
    ${message}
    <span style="margin-left: 32px;">\u2716</span>
</section>`;

const container = document.createElement('div');
document.body.appendChild(container);

export function notify(message) {
    render(notifTemplate(message), container);
    setTimeout(clearNotifications, 3000);
}

export function clearNotifications() {
    render('', container);
}