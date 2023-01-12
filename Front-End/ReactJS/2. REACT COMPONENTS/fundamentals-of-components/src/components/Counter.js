import { Component } from "react";

class Counter extends Component {
    constructor(props) {
        super(props);

        this.state = {
            count: 11,
            collectionName: 'My books'
        }
    }

    render() {
        return (
            <div className="counter">
                <h3>{this.state.collectionName} counter:</h3>
                <button onClick={(e) => this.decreaseCounter(e)}>-</button>
                <span>{this.state.count}</span>
                <button onClick={this.increaseCounter.bind(this)}>+</button>
            </div>
        )
    }

    increaseCounter(e) {
        this.setState(oldState => ({count: oldState.count + 1}));
    }

    decreaseCounter(e) {
        this.setState(oldState => ({count: oldState.count - 1}));
    }
}

export default Counter;