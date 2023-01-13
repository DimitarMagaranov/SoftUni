import { Component } from "react";
import Message from './Message';
import refreshComponent from "../hoc/refreshComponent";

class Footer extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        console.log(this.props.refreshCount);

        return this.props.refreshCount === 0 ? <Message text="All rights reserved &copy;" /> : null;
    }
}

export default refreshComponent(Footer);