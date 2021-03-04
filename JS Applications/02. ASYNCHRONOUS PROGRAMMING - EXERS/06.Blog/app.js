function attachEvents() {
    const loadPostsButton = document.getElementById('btnLoadPosts');
    const postsSelector = document.getElementById('posts');
    const postViewButton = document.getElementById('btnViewPost');

    loadPostsButton.addEventListener('click', loadPosts);
    postViewButton.addEventListener('click', loadView);

    async function loadPosts() {
        const postsUrl = 'http://localhost:3030/jsonstore/blog/posts';
        const postsResponse = await fetch(postsUrl);
        const postsJson = await postsResponse.json();

        for(let key in postsJson) {
            const id = key;
            const postObj = postsJson[id];
            const postOption = createElement('option', postObj.title.toUpperCase());
            postOption.value = postObj.id;
            postsSelector.add(postOption);
        }
    }

    async function loadView() {
        const postId = postsSelector.value;
        
        const postUrl = 'http://localhost:3030/jsonstore/blog/posts/' + postId;
        const postResponse = await fetch(postUrl);
        const postObj = await postResponse.json();

        const allCommentsUrl = 'http://localhost:3030/jsonstore/blog/comments';
        const allCommentsResponse = await fetch(allCommentsUrl);
        const allCommentsObj = await allCommentsResponse.json();
        
        const postComments = [];

        for(let key in allCommentsObj) {
            const commentId = key;
            const currPostId = allCommentsObj[commentId].postId;
            const text = allCommentsObj[commentId].text;

            if(postId === currPostId) {
                postComments.push({commentId, text});
            }
        }

        document.getElementById('post-title').textContent = postObj.title.toUpperCase();
        document.getElementById('post-body').textContent = postObj.body;

        const commentsUl = document.getElementById('post-comments');
        commentsUl.innerHTML = '';
        
        postComments.map(x => {
            const li = createElement('li', x.text);
            li.id = x.commentId;
            commentsUl.appendChild(li);
        });
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

attachEvents();