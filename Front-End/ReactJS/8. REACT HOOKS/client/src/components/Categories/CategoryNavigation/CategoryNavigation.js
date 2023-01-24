import { NavLink } from "react-router-dom";
import { CATEGORIES_LINKS } from "./constants";

function CategoryNavigation() {
    let activeClassName = "active-link";

    return (
        <nav className="navbar">
            <ul>
                {CATEGORIES_LINKS.map((x) => {
                    return (
                        <li key={x.name}>
                            <NavLink to={x.path} className={({ isActive }) => (isActive ? activeClassName : undefined)}>
                                {x.name}
                            </NavLink>
                        </li>
                    );
                })}
            </ul>
            <style>{`
                .active-link {
                    background-color: #F8D76B !important;
                }
            `}</style>
        </nav>
    );
}

export default CategoryNavigation;
