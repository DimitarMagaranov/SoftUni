function lockedProfile() {
    const main = document.getElementById('main');
    main.addEventListener('click', onclick);

    function onclick(ev) {
        if (ev.target.tagName === 'BUTTON') {
            const profile = ev.target.parentNode;
            const isLocked = profile.querySelector('input[type=radio]:checked').value === 'lock';

            if (isLocked === false) {
                let div = profile.querySelector('div');
                let isVisible = div.style.display === 'block';

                div.style.display = isVisible ? 'none' : 'block';

                ev.target.textContent = isVisible ? 'Show more' : 'Hide it';
            }
        }
    }
}