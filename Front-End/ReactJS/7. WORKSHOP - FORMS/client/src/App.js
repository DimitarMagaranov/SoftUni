import { Route, Routes } from "react-router-dom";

import Header from "./components/Header/Header";
import Footer from "./components/Footer/Footer";
import Categories from "./components/Categories/Categories";
import PetDetails from "./components/PetDetails/PetDetails";
import EditPet from "./components/EditPet/EditPet";
import CreatePet from "./components/CreatePet/CreatePet";
import Login from "./components/Login/Login";
import Register from "./components/Register/Register";
import "./App.css";

function App() {
    return (
        <div id="container">
            <Header />
                <Routes>
                    <Route index element={<Categories />}></Route>
                    <Route path="/categories/:category" element={<Categories />}></Route>
                    <Route path="/pets/details/:id" element={<PetDetails />}></Route>
                    <Route path="/pets/details/:id/edit" element={<EditPet />}></Route>
                    <Route path="/pets/create" element={<CreatePet />}></Route>
                    <Route path="/login" element={<Login />}></Route>
                    <Route path="/register" element={<Register />}></Route>
                </Routes>
            <Footer />
        </div>
    );
}

export default App;
