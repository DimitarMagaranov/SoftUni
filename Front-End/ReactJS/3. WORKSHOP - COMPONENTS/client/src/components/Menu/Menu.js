import {useState} from 'react';

import MenuItem from './MenuItem/MenuItem';
import {MENU_ITEMS} from './MenuConstants';
import './Menu.css';

function Menu({onMenuItemClick}) {
    const [currItem, setCurrItem] = useState();

    function menuItemClickHandler(id) {
        setCurrItem(id);
        onMenuItemClick(id);
    }

    console.log(currItem);
    return (
        <aside className="menu">
            {MENU_ITEMS.map(x => 
                <MenuItem
                    key={x.id}
                    id={x.id}
                    isSelected={x.id == currItem}
                    onClick={menuItemClickHandler}
                >
                    {x.text}
                </MenuItem>)}
        </aside>
    );
}

export default Menu;