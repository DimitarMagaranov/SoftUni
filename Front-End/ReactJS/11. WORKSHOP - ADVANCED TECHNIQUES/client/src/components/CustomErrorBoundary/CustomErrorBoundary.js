import { Component } from "react";

class CustomErrorBoundary extends Component {
    constructor(props) {
        super(props);

        this.state = {
            hasError: false
        }
    }

    static getDerivedStateFromError(error, errorInfo) {
        return {
            hasError: true
        }
    }

    componentDidCatch(error) {
        console.log('error from componentDIdCatch: ', error);
    }

    render() {
        if (this.state.hasError) {
            return <h1>I'm so sorry!</h1>
        }
        
        return this.props.children;
    }
}

export default CustomErrorBoundary;