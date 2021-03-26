import { html, render } from '../node_modules/lit-html/lit-html.js';

const modalTemplate = (message, onChoise) => html`
<div id="modal">
    <p>${message}</p>
    <button @click=${() => onChoise(true)}>OK</button>
    <button @click=${() => onChoise(false)}>Cancel</button>
</div>`;

const overlay = document.createElement('div');
overlay.id = 'overlay';

export function createModal(message, callBack) {
    render(modalTemplate(message, onChoise), overlay);
    document.body.appendChild(overlay);

    function onChoise(choise) {
        clearModal();
        callBack(choise);
    }
}

function clearModal() {
    overlay.remove();
}