import { Component } from 'react';
import Button from './Button';
import ButtonHeader from './ButtonHeader';

import ThemeContext from './ThemeContext';

class ThemedButton extends Component {
    componentDidMount() {
        console.log(this.context.currentTheme);
    }
    render() {
        //1st way to consume the context
        return (
            <>
                <ButtonHeader></ButtonHeader>
                <Button buttonClickHandler={this.context.onChangeThemeClickHandler} />
            </>
        );

        //2nd way
        // return (
        //     <ThemeContext.Consumer>
        //         {(values) => <Button theme={values.currentTheme} buttonClickHandler={values.onChangeThemeClickHandler} />}
        //     </ThemeContext.Consumer>
        // );
    }
}

//1st way to consume the context
ThemedButton.contextType = ThemeContext;

export default ThemedButton;
