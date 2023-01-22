import { useState } from "react";

function TestFunc() {
    const [username, setUsername] = useState('Pesho');
    const [age, setAge] = useState(0);
    const [textField, setTextField] = useState('asd');
    const [dropdown, setDropdown] = useState('Back-End');

    const options = [
        { label: "Frond-End", value: "Frond-End" },
        { label: "Back-End", value: "Back-End" },
        { label: "Full-Stack", value: "Full-Stack" },
    ];

    function onSubmitHandler(e) {
        e.preventDefault();
        console.log(username);
        console.log(age);
        console.log(textField);
        console.log(dropdown);
    }

    function onUsernameChangeHandler(e) {
        setUsername(e.target.value);
    }
    function onAgeChangeHandler(e) {
        setAge(e.target.value);
    }
    function onTextFieldChangeHandler(e) {
        setTextField(e.target.value);
    }
    function onDropdownChangeHandler(e) {
        setDropdown(e.target.value);
    }

    function blurHandler() {
        console.log("blur");
    }

    return (
        <div>
            <h1>Test form</h1>
            <form onSubmit={onSubmitHandler}>
                <label htmlFor="username">Username</label>
                <input
                    type="text"
                    id="username"
                    name="username"
                    value={username}
                    onChange={onUsernameChangeHandler}
                    onBlur={blurHandler}
                />

                <label htmlFor="age">Age</label>
                <input type="number" id="age" name="age" value={age} onChange={onAgeChangeHandler} />

                <label htmlFor="textField"></label>
                <textarea name="textField" id="textField" value={textField} onChange={onTextFieldChangeHandler} />

                <label htmlFor="dropdown">Dropdown menu</label>
                <select name="dropdown" id="dropdown" onChange={onDropdownChangeHandler} value={dropdown}>
                    {options.map((x) => (
                        <option key={x.value} value={x.value}>
                            {x.label}
                        </option>
                    ))}
                </select>

                <input type="submit" value="send" />
            </form>
        </div>
    );
}

export default TestFunc;
