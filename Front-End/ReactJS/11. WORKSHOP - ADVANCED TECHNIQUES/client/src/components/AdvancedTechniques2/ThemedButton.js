import { useContext } from 'react';
import Button from './Button';
import ButtonHeader from './ButtonHeader';

import ThemeContext from './ThemeContext';

function ThemedButton() {

    const [theme, setTheme] = useContext(ThemeContext);

    function onChangeThemeClickHandler() {
        setTheme((theme) => (theme == 'dark' ? 'light' : 'dark'));
    }


        return (
            <>
                <ButtonHeader></ButtonHeader>
                <Button buttonClickHandler={onChangeThemeClickHandler} />
            </>
        );
}

export default ThemedButton;
