import { Component } from "react";
import Book from "./Book";

class BookList extends Component {
    constructor (props) {
        super(props);
    }

    bookClicked(title) {
        console.log(`The book ${title} has been added to basket!`);
    }

    render() {
        return (
            <div className="book-list-ctr">
                <h2>Our book colection:</h2>
                <ul>
                    {
                        this.props.books.map(x => {
                            return <Book title={x.title} clickHandler={this.bookClicked.bind(this, x.title)} />;
                        })
                    }
                </ul>
            </div>
        );
    }
}

export default BookList;
