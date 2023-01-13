import { Component } from "react";
import bookService from "../services/bookService";
import Book from "./Book";

class BookList extends Component {
    constructor(props) {
        super(props);

        this.state = {
            books: [],
        };
    }

    bookClicked(title) {
        console.log(`The book ${title} has been added to basket!`);
    }

    componentDidMount() {
        bookService.getBooks().then((books) => this.setState(() => ({ books })));
    }

    render() {
        if (this.state.books.length == 0) {
            return <span>Loading books...</span>;
        }
        return (
            <div className="book-list-ctr">
                <h2>Our book colection:</h2>
                <ul>
                    {this.state.books.map((x) => {
                        return <Book key={x.id} title={x.title} clickHandler={this.bookClicked.bind(this, x.title)} />;
                    })}
                </ul>
            </div>
        );
    }
}

export default BookList;
