function getArticleGenerator(articles) {
    const arrayOfArticles = [];
    const div = document.getElementById('content');

    for(let art of articles) {
        const article = document.createElement('article');
        article.textContent = art;
        arrayOfArticles.push(article);
    }

    return function show() {
        if(arrayOfArticles.length > 0) {
            div.appendChild(arrayOfArticles.shift());
        }
    }
}
