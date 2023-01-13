import style from './Book.module.css'

function Book (props) {
    return (
        <article className={style.article} onClick={props.clickHandler}>
            <h3>{props.title}</h3>
            <p className={style.description}>Lorem ipsum dolor sit amet.</p>
        </article>
    )
}

export default Book;