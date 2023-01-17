import './NavigationItem.css';

import { Link, NavLink } from "react-router-dom";

function NavigationItem(props) {
    let activeStyle = {
        backgroundColor: "red",
      };
    return (
        <li className="list-item"><NavLink to={props.linkTo} style={({isActive}) => isActive ? activeStyle : undefined}>{props.children}</NavLink></li>
    );
}

export default NavigationItem;