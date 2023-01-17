import "./Header.css";
import NavigationItem from "./NavigationItem/NavigationItem";
import { Link } from "react-router-dom";

function Header() {
    return (
        <nav className="navigation">
            <ul>
                <li className="list-item">
                    <Link to="/"><img id="logo" src="white-origami-bird.png" alt="white origami" /></Link>
                </li>
                <NavigationItem key={1} linkTo="/">Home</NavigationItem>
                <NavigationItem key={2} linkTo="/about">About Us</NavigationItem>
                <NavigationItem key={3} linkTo="/contact-us">Contact Us</NavigationItem>
                <NavigationItem key={4} linkTo="/details/pesho">Pesho</NavigationItem>
                <NavigationItem key={5} linkTo="/details/gosho">Gosho</NavigationItem>
            </ul>
        </nav>
    );
}

export default Header;
