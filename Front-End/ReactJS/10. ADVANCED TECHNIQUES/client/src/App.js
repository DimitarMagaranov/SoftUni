import { Route, Routes } from 'react-router-dom';

import Header from './components/Header/Header';
import Footer from './components/Footer/Footer';
import Categories from './components/Categories/Categories';
import PetDetails from './components/PetDetails/PetDetails';
import EditPet from './components/EditPet/EditPet';
import CreatePet from './components/CreatePet/CreatePet';
import Login from './components/Login/Login';
import Register from './components/Register/Register';
import Logout from './components/Logout/Logout';
import TestFunc2 from './components/Test/TestFunc2';
import AdvancedTechniques from './components/AdvancedTechniques/AdvancedTechniques';
import AdvancedTechniques2 from './components/AdvancedTechniques2/AdvancedTechniques2';
import AdvancedTechniques3 from './components/AdvancedTechniques3/AdvancedTechniques3';
import { auth } from './utils/firebase';
import './App.css';
import { useEffect, useState } from 'react';

function App() {
    const [user, setUser] = useState(null);

    useEffect(() => {
        auth.onAuthStateChanged(setUser);
    }, []);

    return (
        <div id="container">
            <Header userEmail={user?._delegate.email} isAuthenticated={!!user} />
            <Routes>
                <Route index element={<Categories />}></Route>
                <Route path="/categories/:category" element={<Categories />}></Route>
                <Route path="/pets/details/:id" element={<PetDetails />}></Route>
                <Route path="/pets/details/:id/edit" element={<EditPet />}></Route>
                <Route path="/pets/create" element={<CreatePet />}></Route>
                <Route path="/login" element={<Login />}></Route>
                <Route path="/register" element={<Register />}></Route>
                <Route path="/logout" element={<Logout />}></Route>

                <Route path='/advancedTechniques' element={<AdvancedTechniques />}></Route>
                <Route path='/advancedTechniques2' element={<AdvancedTechniques2 />}></Route>
                <Route path='/advancedTechniques3' element={<AdvancedTechniques3 />}></Route>
                <Route path="/test" element={<TestFunc2 />}></Route>
            </Routes>
            <Footer />
        </div>
    );
}

export default App;
