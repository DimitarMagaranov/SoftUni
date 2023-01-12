function Book (props) {
    return (
        <article onClick={props.clickHandler}>
            <h3>{props.title}</h3>
            <p>Lorem ipsum dolor sit amet.</p>
        </article>
    )
}

export default Book;