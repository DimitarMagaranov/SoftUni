import { Route, Routes } from "react-router-dom";

import Header from "./components/Header/Header";
import Footer from "./components/Footer/Footer";
import Categories from "./components/Categories/Categories";
import PetDetails from "./components/PetDetails/PetDetails";
import "./App.css";

function App() {
    return (
        <div id="container">
            <Header />
                <Routes>
                    <Route index element={<Categories />}></Route>
                    <Route path="/categories/:category" element={<Categories />}></Route>
                    <Route path="/pets/details/:id" element={<PetDetails />}></Route>
                </Routes>
            <Footer />
        </div>
    );
}

export default App;
