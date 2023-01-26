import { useContext } from 'react';
import ThemeContext from './ThemeContext';

function ButtonHeader() {
    const themeContext = useContext(ThemeContext);

    console.log(themeContext.currentTheme, 'In button header');

    return (
        <header style={{color: themeContext.currentTheme == 'dark' ? 'darkgray' : 'lightgreen'}}>
            <h1>Some title here</h1>
            <p>
                Lorem ipsum dolor sit, amet consectetur adipisicing elit. Ullam nulla officiis aliquid reprehenderit tenetur vel commodi at aliquam
                sequi asperiores.
            </p>
        </header>
    );
}

export default ButtonHeader;
