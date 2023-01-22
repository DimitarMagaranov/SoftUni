import React, { Component } from "react";

import "./Test.css";

const options = [
    { label: "Frond-End", value: "Frond-End" },
    { label: "Back-End", value: "Back-End" },
    { label: "Full-Stack", value: "Full-Stack" },
];

class Test extends Component {
    constructor(props) {
        super(props);

        this.state = {
            username: "",
            age: 0,
            textField: "asd",
            dropdown: "Back-End",
            errors: {
                email: "",
            },
        };

        this.emailInput = React.createRef();

        this.onChangeHandler = this.onChangeHandler.bind(this);
    }

    onSubmitHandler(e) {
        e.preventDefault();

        if (!this.emailInput.current.value.includes("@")) {
            // this.setState(oldState => oldState.errors.email = 'Missing @ in the input')
            this.setState((oldState) => (oldState.errors.email = "Invalid email!"));
            this.emailInput.current.focus();
        } else {
            this.setState((oldState) => (oldState.errors.email = ""));
        }

        console.log(this.state);
    }

    onChangeHandler(e) {
        this.setState((oldState) => (oldState[e.target.name] = e.target.value));
    }

    blurHandler() {
        console.log("blur");
    }

    render() {
        return (
            <div>
                <h1>Test form</h1>
                <form onSubmit={this.onSubmitHandler.bind(this)}>
                    <label htmlFor="username">Username</label>
                    <input
                        type="text"
                        id="username"
                        name="username"
                        value={this.state.username}
                        onChange={this.onChangeHandler}
                        onBlur={this.blurHandler}
                    />

                    <label htmlFor="age">Age</label>
                    <input type="number" id="age" name="age" value={this.state.age} onChange={this.onChangeHandler} />

                    <label htmlFor="email">Email</label>
                    <input type="text" name="email" id="email" placeholder="email@email.com" ref={this.emailInput} />
                    {this.state.errors.email && <span className="input-validation">{this.state.errors.email}</span>}

                    <label htmlFor="textField"></label>
                    <textarea name="textField" id="textField" value={this.state.textField} onChange={this.onChangeHandler} />

                    <label htmlFor="dropdown">Dropdown menu</label>
                    <select name="dropdown" id="dropdown" onChange={this.onChangeHandler} value={this.state.dropdown}>
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
}

export default Test;
