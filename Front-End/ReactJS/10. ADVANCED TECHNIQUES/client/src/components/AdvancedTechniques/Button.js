import ThemeContext from './ThemeContext';

function Button({ buttonClickHandler }) {
    return (
        <ThemeContext.Consumer>
            {values => <button onClick={buttonClickHandler} style={{ backgroundColor: values.currentTheme == 'dark' ? 'darkgray' : 'lightgreen' }}>
                {values.currentTheme}
            </button>}
        </ThemeContext.Consumer>
    );
}

export default Button;
