export function createNavigation(main, nav) {
    const views = {};
    const links = {};

    setupNavigation();

    const navigation = {
        setupVisibleNavLinks,
        registerView,
        goTo
    }

    return navigation;

    async function goTo(name, ...params) {
        main.innerHTML = '';
        const section = await views[name](...params);
        main.appendChild(section);
    }

    function registerView(name, section, setup, navId) {
        const view = setup(section, navigation);
        views[name] = view;

        if(navId) {
            links[navId] = name;
        }
    }

    function setupNavigation() {
        setupVisibleNavLinks();

        nav.addEventListener('click', (ev) => {
            const handler = links[ev.target.id];
            if (typeof handler == 'function') {
                ev.preventDefault();
                handler();
            }
        });

        // document.getElementById('createLink').addEventListener('click', (ev) => {
        //     ev.preventDefault();
        //     showCreate();
        // });

        // document.getElementById('logoutBtn').addEventListener('click', logout);
    }

    function setupVisibleNavLinks() {
        const userEmail = sessionStorage.email;

        const userLinks = [...document.querySelectorAll('nav .user')];
        const guestLinks = [...document.querySelectorAll('nav .guest')];

        if (userEmail != null) {
            userLinks.forEach(x => x.style.display = 'block');
            guestLinks.forEach(x => x.style.display = 'none');
            document.getElementById('welcome-msg').textContent = `Welcome, ${userEmail}`;
        } else {
            userLinks.forEach(x => x.style.display = 'none');
            guestLinks.forEach(x => x.style.display = 'block');
        }
    }
}