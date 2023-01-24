import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

import useFetch from '../../hooks/useFetch';

function TestFunc2() {
    // const [state, setState] = useState({
    //     count: 10,
    //     step: 1,
    // });

    // function onCounterButtonClickHandler() {
    //     setState((oldState) => (
    //         {
    //             ...oldState,
    //             count: oldState.count + oldState.step,
    //         }
    //     ));
    // }

    // function onStepSelectChangeHandler(e) {
    //     const stepValue = Number(e.target.value);
    //     setState((oldState) => (
    //         {
    //             ...oldState,
    //             step: stepValue
    //         }
    //     ));
    // }

    const [count, setCount] = useState(0);
    const [step, setStep] = useState(1);
    // const [person, setPerson] = useState({ name: 'Nobody' });
    const [person, isPersonLoading] = useFetch(`https://swapi.dev/api/people/${step}`, {});

    // useEffect(() => {
    //     console.log('ComponentDidMount');
    //     loadPerson(1);
    // }, []);

    // useEffect(() => {
    //     console.log('ComponentDidUpdate');
    //     loadPerson(step);
    // }, [step]);

    // useEffect(() => {
    //     return () => {
    //         console.log('ComponentWillUnmount');
    //     };
    // }, []);

    // ALL in:
    // useEffect(() => {
    //     loadPerson(step);

    //     return () => {
    //         console.log('ComponentWillUnmount');
    //     };
    // }, [step]);

    // function loadPerson(id) {
    //     fetch(`https://swapi.dev/api/people/${id}`)
    //         .then((res) => res.json())
    //         .then((data) => setPerson(data))
    //         .catch((err) => console.log(err));
    // }

    function onCounterButtonClickHandler() {
        setCount((oldState) => oldState + step);
    }

    function onStepSelectChangeHandler(e) {
        const stepValue = Number(e.target.value);
        setStep(stepValue);
    }

    return (
        <div>
            <h1>{isPersonLoading ? 'Loading ...' : `${person.name}'s Counter`}</h1>
            <div>{count}</div>
            <button onClick={onCounterButtonClickHandler}>Increment</button>
            <div>
                <label htmlFor="step">Step</label>
                <select name="step" id="step" onChange={onStepSelectChangeHandler}>
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                </select>
            </div>
            <div>
                <Link to="/">Unmount</Link>
            </div>
        </div>
    );
}

export default TestFunc2;
