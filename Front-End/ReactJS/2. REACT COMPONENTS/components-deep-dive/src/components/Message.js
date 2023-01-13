import { Component } from "react";
import './Message.css';

class Message extends Component {
    constructor(props) {
        super(props);

        console.log('Constructor');

        this.state = {
            company: 'Magaranov'
        }
    }

    render() {
        // let style = {
        //     backgroundColor: 'red',
        //     fontSize: 20
        // };

        // if (true) {
        //     style.textDecoration = 'underline';
        // }

        console.log('Render');
        return <span className="footer-message">{this.props.text} | {this.state.company}</span>
    }

    componentDidMount() {
        console.log('ComponentDidMount');

        setTimeout(() => {
            this.setState({company: 'Magaranov2'});
        }, 1000);
    }

    componentDidUpdate() {
        console.log('ComponentDidUpdate');
    }

    componentWillUnmount() {
        console.log('ComponentWillUnmount');
    }
}

export default Message;