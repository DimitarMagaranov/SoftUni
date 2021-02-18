function solution() {
    const body = document.getElementsByTagName('body')[0];
    const container = document.getElementsByClassName('container')[0];
    const addGiftsSection = container.children[0];
    const listOfGiftsSection = container.children[1];
    const sendGiftsSection = container.children[2];
    const discardedGiftsSection = container.children[3];
    const addGiftsInputField = addGiftsSection.querySelector('input');
    const addGiftsButton = addGiftsSection.querySelector('button');
    const listOfGiftsUl = listOfGiftsSection.querySelector('ul');
    const sendGiftsUl = sendGiftsSection.querySelector('ul');
    const discardGiftsUl = discardedGiftsSection.querySelector('ul');

    body.addEventListener('click', onclick);

    function onclick(ev) {
        if (ev.target.tagName === 'BUTTON') {
            if (ev.target === addGiftsButton) {
                const input = addGiftsInputField.value;

                if (input === '') {
                    return;
                }

                addGiftToTheList(input);
            } else if (ev.target.textContent === 'Send') {
                const gift = ev.target.parentNode;
                sendGift(gift);
            } else if (ev.target.textContent === 'Discard') {
                const gift = ev.target.parentNode;
                discardGift(gift);
            }
        }
    }

    function addGiftToTheList(input) {
        const sendButton = createElement('button', 'Send');
        sendButton.setAttribute('id', 'sendButton');
        const discardButton = createElement('button', 'Discard');
        discardButton.setAttribute('id', 'discardButton');
        const li = createElement('li', input, sendButton, discardButton);
        li.classList.add('gift');
        listOfGiftsUl.appendChild(li);
        addGiftsInputField.value = '';

        let allLiElements = Array.from(listOfGiftsUl.querySelectorAll('li'));
        let sortedLiElements = allLiElements.sort((a, b) => a.innerText.localeCompare(b.innerText));
 
        while (listOfGiftsUl.firstChild) {
            listOfGiftsUl.firstChild.remove();
        }
 
        for (const element of sortedLiElements) {
            listOfGiftsUl.appendChild(element);
        }
    }

    function sendGift(gift) {
        const textContent = gift.textContent.slice(0, -11);
        const li = createElement('li', textContent);
        li.classList.add('gift');
        sendGiftsUl.appendChild(li);
        gift.remove();
    }

    function discardGift(gift) {
        const textContent = gift.textContent.slice(0, -11);
        const li = createElement('li', textContent);
        li.classList.add('gift');
        discardGiftsUl.appendChild(li);
        gift.remove();
    }

    function createElement(type, ...content) {
        const result = document.createElement(type);

        content.forEach(e => {
            if (typeof e == 'string') {
                const node = document.createTextNode(e);
                result.appendChild(node);
            } else {
                result.appendChild(e);
            }
        });

        return result;
    }
}