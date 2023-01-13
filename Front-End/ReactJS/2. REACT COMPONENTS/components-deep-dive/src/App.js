import Heading from './components/Heading';
import "./App.css";
import BookList from './components/BookList';
import Counter from './components/Counter';
import Footer from './components/Footer';

function App() {
  return (
    <div className="site-wrapper">
        <Heading><h1>Our custom library</h1></Heading>

        <Counter />

        <BookList/>

        <Footer />
    </div>
  );
}

export default App;
