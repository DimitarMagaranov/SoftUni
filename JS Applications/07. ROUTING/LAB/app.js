import page from '//unpkg.com/page/page.mjs';

const pages = {
    '/home': '<h2>Home Page</h2><p>Home page content</p>',
    '/catalog': '<h2>Catalog</h2><p>List of recent articles <a href="/catalog/action/123"> Item 123</p>',
    '/about': '<h2>About Us</h2><p>Contact information</p>',
    '/buy': '<h2>Thank you for your purchase!</h2>'
};

const defaultPage = '<h2>404</h2><p>Page not found</p>';

const main = document.querySelector('main');

page('/home', updateContent);
page('/catalog', updateContent);
page('/catalog/:category/:id', itemDetails);
page('/about', updateContent);
page('/buy', updateContent);

page.redirect('/', '/home');

page.start();

function updateContent(context) {
    main.innerHTML = pages[context.pathname] || defaultPage;
}

function itemDetails(context) {
    const category = context.params.category;
    const id = context.params.id;
    const html = `<h2>Category ${category}</h2>
    <h3>Item ${id}</h3>
    <p>Details for item ${id}</p>`;
    main.innerHTML = html;

    const btn = document.createElement('button');
    btn.textContent = 'Buy';
    btn.addEventListener('click', () => {
        context.page.redirect('/buy');
    });
    main.appendChild(btn);
}