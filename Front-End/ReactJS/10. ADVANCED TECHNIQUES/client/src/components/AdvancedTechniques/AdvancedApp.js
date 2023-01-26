import { Component } from 'react';
import ThemeContext from './ThemeContext';
import Toolbar from './Toolbar';

class AdvancedApp extends Component {
    constructor(props) {
        super(props);
        this.state = {
            currentTheme: 'dark',
        };
    }

    onChangeThemeClickHandler() {
        this.setState((oldState) => ({ currentTheme: oldState.currentTheme == 'dark' ? 'light' : 'dark' }));
    }

    render() {
        return (
            <ThemeContext.Provider
                value={{
                    currentTheme: this.state.currentTheme,
                    onChangeThemeClickHandler: this.onChangeThemeClickHandler.bind(this),
                }}
            >
                <Toolbar />
            </ThemeContext.Provider>
        );
    }
}

export default AdvancedApp;
