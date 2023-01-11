import logo from "./logo.svg";
import "./App.css";
import Header from "./components/Header";
import Footer from "./components/Footer";
import Lorem from "./components/Lorem";

function App() {
  return (
    <div className="site-wrapper">
      <Header>Hello from App Component</Header>

        <main>
            <Lorem />
            <Lorem />
            <Lorem />
        </main>

      <Footer></Footer>
    </div>
  );
}

export default App;
