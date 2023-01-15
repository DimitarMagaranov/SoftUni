import './Header.css';
import NavigationItem from './NavigationItem/NavigationItem';
import {MENU_ITEMS} from '../Menu/MenuConstants';

function Header() {
    return (
        <nav className="navigation">
            <ul>
                <li className="list-item"><img id="logo" src="white-origami-bird.png" alt="white origami"/></li>
                {MENU_ITEMS.map(x => 
                    <NavigationItem key={x.id}>{x.text}</NavigationItem>
                )}
            </ul>
        </nav>
    );
}

export default Header;