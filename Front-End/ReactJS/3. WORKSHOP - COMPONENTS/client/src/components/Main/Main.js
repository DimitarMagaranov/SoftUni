import Post from "../Post/Post";
import "./Main.css";

function Main({ posts }) {
    return (
        <main className="main-ctr">
            <h1>Soooooome Heading</h1>

            <div className="posts">
                {posts.map((x) => (
                    <Post
                        key={x.id}
                        content={x.content}
                        author={x.author}
                    />
                ))}
            </div>
        </main>
    );
}

export default Main;
