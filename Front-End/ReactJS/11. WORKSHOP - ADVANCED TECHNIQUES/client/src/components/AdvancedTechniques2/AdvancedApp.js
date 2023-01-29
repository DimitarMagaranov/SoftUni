import { useState } from 'react';
import ThemeContext from './ThemeContext';
import Toolbar from './Toolbar';

function AdvancedApp() {
    const [theme, setTheme] = useState('dark');

    function onChangeThemeClickHandler() {
        setTheme((theme) => (theme == 'dark' ? 'light' : 'dark'));
    }

    return (
        <ThemeContext.Provider
            value={[theme, setTheme]}
        >
            <Toolbar />
        </ThemeContext.Provider>
    );
}

export default AdvancedApp;
