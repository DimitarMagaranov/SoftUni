import { useContext } from 'react';
import ThemeContext from './ThemeContext';

function ButtonHeader() {
    const [theme] = useContext(ThemeContext);

    return (
        <header style={{color: theme == 'dark' ? 'darkgray' : 'lightgreen'}}>
            <h1>Some title here</h1>
            <p>
                Lorem ipsum dolor sit, amet consectetur adipisicing elit. Ullam nulla officiis aliquid reprehenderit tenetur vel commodi at aliquam
                sequi asperiores.
            </p>
        </header>
    );
}

export default ButtonHeader;
