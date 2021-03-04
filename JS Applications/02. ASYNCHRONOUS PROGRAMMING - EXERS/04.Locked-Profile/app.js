async function lockedProfile() {
    const main = document.getElementById('main');

    const usersUrl = 'http://localhost:3030/jsonstore/advanced/profiles';
    const response = await fetch(usersUrl);
    const usersDb = await response.json();

    main.innerHTML = '';

    for (let key in usersDb) {
        const id = key;
        const userInfo = usersDb[id];

        const userDiv = getUserDiv(userInfo);
        main.appendChild(userDiv);
    }

    function getUserDiv(userInfo) {
        const profileImg = createElement('img');
        profileImg.src = "./iconProfile2.png";
        profileImg.classList.add('userIcon');
        const lockLabel = createElement('label', 'Lock');
        const lockCheckbox = createElement('input');
        lockCheckbox.type = 'radio';
        lockCheckbox.name = 'user1Locked';
        lockCheckbox.value = 'lock';
        const unlockLabel = createElement('label', 'Unlock');
        const unlockCheckbox = createElement('input');
        unlockCheckbox.type = 'radio';
        unlockCheckbox.name = 'user1Locked';
        unlockCheckbox.value = 'unlock';
        const br = createElement('br');
        const hr1 = createElement('hr');
        const userNameLabel = createElement('label', 'Username');
        const userNameInput = createElement('input');
        userNameInput.type = 'text';
        userNameInput.name = 'user1Username';
        userNameInput.value = userInfo.username;
        userNameInput.disabled = true;
        userNameInput.readOnly = true;
        const hr2 = createElement('hr');
        const emailLabel = createElement('label', 'Email:');
        const emailInput = createElement('input');
        emailInput.type = 'email';
        emailInput.name = 'user1Email';
        emailInput.value = userInfo.email;
        emailInput.disabled = true;
        emailInput.readOnly = true;
        const ageLabel = createElement('label', 'Age:');
        const ageInput = createElement('input');
        ageInput.type = 'email';
        ageInput.name = 'user1Age';
        ageInput.value = userInfo.age;
        ageInput.disabled = true;
        ageInput.readOnly = true;
        const div = createElement('div', hr2, emailLabel, emailInput, ageLabel, ageInput);
        div.id = 'user1HiddenFields';
        const button = createElement('button', 'Show more');
        button.addEventListener('click', onclick);
        const userDiv = createElement('div', profileImg, lockLabel, lockCheckbox, unlockLabel, unlockCheckbox, br, hr1, userNameLabel, userNameInput, div, button);
        userDiv.classList.add('profile');

        return userDiv;
    }

    function onclick(ev) {
        const userDiv = ev.target.parentNode;
        const hiddenDiv = userDiv.querySelector('div');

        if(userDiv.getElementsByTagName('input')[1].checked === true) {
            if(ev.target.textContent === 'Show more') {
                hiddenDiv.style.display = 'block';
                ev.target.textContent = 'Hide it';
            } else {
                hiddenDiv.style.display = 'none';
                ev.target.textContent = 'Show more';
            }
        }
    }

    function createElement(type, ...content) {
        const result = document.createElement(type);

        content.forEach(e => {
            if (typeof e == 'string' || typeof e == 'number') {
                const node = document.createTextNode(e.toString());
                result.appendChild(node);
            } else {
                result.appendChild(e);
            }
        });

        return result;
    }
}