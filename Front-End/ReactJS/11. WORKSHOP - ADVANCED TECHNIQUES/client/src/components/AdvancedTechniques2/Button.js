import ThemeContext from './ThemeContext';
import { useContext } from 'react';

function Button({ buttonClickHandler }) {
    const [theme] = useContext(ThemeContext);

    return (
        <button onClick={buttonClickHandler} style={{ backgroundColor: theme == 'dark' ? 'darkgray' : 'lightgreen' }}>
                {theme}
            </button>
    );
}

export default Button;
