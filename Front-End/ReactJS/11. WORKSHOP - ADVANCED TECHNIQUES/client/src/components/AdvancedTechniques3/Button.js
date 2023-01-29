import ThemeContext from './ThemeContext';
import { useContext } from 'react';

function Button({ buttonClickHandler }) {
    const [theme] = useContext(ThemeContext);

    return (
        <button onClick={buttonClickHandler} style={{ backgroundColor: theme.color == 'dark' ? 'darkgray' : 'lightgreen' }}>
                {theme.color}
            </button>
    );
}

export default Button;
