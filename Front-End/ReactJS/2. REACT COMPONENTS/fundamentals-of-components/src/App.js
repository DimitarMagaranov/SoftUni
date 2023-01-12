import Heading from './components/Heading';
import "./App.css";
import BookList from './components/BookList';
import Counter from './components/Counter';

let books = [
    {title: 'Harry Potter'},
    {title: 'Star Trek'},
];

function App() {
  return (
    <div className="site-wrapper">
        <Heading><h1>Our custom library</h1></Heading>

        <Counter />

        <BookList books={books}/>
    </div>
  );
}

export default App;
