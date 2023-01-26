import { useContext } from 'react';
import Button from './Button';
import ButtonHeader from './ButtonHeader';

import ThemeContext from './ThemeContext';

function ThemedButton() {
    const [theme, dispatch] = useContext(ThemeContext);

    function onChangeThemeClickHandler() {
        dispatch({ type: 'CHANGE_COLOR', payload: theme.color == 'dark' ? 'light' : 'dark' });
    }

    return (
        <>
            <ButtonHeader></ButtonHeader>
            <Button buttonClickHandler={onChangeThemeClickHandler} />
        </>
    );
}

export default ThemedButton;
