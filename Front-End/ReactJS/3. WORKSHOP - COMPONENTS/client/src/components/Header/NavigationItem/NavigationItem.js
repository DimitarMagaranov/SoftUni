import './NavigationItem.css';

function NavigationItem(props) {
    return (
        <li className="list-item"><a href="#">{props.children}</a></li>
    );
}

export default NavigationItem;