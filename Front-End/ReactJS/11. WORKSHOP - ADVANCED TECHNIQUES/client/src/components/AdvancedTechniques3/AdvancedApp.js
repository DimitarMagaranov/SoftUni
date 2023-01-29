import { useReducer, useState } from 'react';
import ThemeContext from './ThemeContext';
import Toolbar from './Toolbar';

function AdvancedApp() {
    // const [theme, setTheme] = useState({
    //     color: 'dark',
    //     size: 'normal',
    //     font: 'default'
    // });

    function themeReducer(state, action) {
        switch (action.type) {
            case 'CHANGE_COLOR':
                return {...state, color: action.payload}
            default:
                return state;
        }
    }

    const [theme, dispatch] = useReducer(themeReducer, {
        color: 'dark',
        size: 'normal',
        font: 'default'
    })

    return (
        <ThemeContext.Provider
            value={[theme, dispatch]}
        >
            <Toolbar />
        </ThemeContext.Provider>
    );
}

export default AdvancedApp;
