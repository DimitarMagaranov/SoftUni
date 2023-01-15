import "./Post.css";

function Post({ content, author }) {
    return (
        <div className="post-ctr">
            <img src="/blue-origami-bird.png" alt="blue origami" />
            <p className="post-description">{content}</p>
            <div>
                <span>
                    <small>Author:</small> {author}
                </span>
            </div>
        </div>
    );
}

export default Post;
