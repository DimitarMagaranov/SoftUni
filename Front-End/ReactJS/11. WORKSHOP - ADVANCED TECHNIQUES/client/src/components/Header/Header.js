import { NavLink } from 'react-router-dom';
import { useEffect, useContext } from 'react';

import AuthContext from '../../contexts/AuthContext';

function Header() {
    const {isAuthenticated, userEmail} = useContext(AuthContext);

    return (
        <header id="site-header">
            <nav className="navbar">
                {isAuthenticated ? (
                    <section className="navbar-dashboard">
                        <div className="first-bar">
                            <NavLink to="/">Dashboard</NavLink>
                            <NavLink className="button" to="/my-pets">
                                My Pets
                            </NavLink>
                            <NavLink to="/pets/create" className="button">
                                Add Pet
                            </NavLink>
                        </div>
                        <div className="second-bar">
                            <ul>
                                <li>Welcome, {userEmail}!</li>
                                <li>
                                    <NavLink to="/logout">
                                        <i className="fas fa-sign-out-alt"></i> Logout
                                    </NavLink>
                                </li>
                            </ul>
                        </div>
                    </section>
                ) : (
                    <section className="navbar-anonymous">
                        <ul>
                            <li>
                                <NavLink to="/register">
                                    <i className="fas fa-user-plus"></i> Register
                                </NavLink>
                            </li>
                            <li>
                                <NavLink to="/login">
                                    <i className="fas fa-sign-in-alt"></i> Login
                                </NavLink>
                            </li>
                        </ul>
                    </section>
                )}
            </nav>
        </header>
    );
}

export default Header;
