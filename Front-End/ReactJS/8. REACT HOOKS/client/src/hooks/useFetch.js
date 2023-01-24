import { useState, useEffect } from "react";

function useFetch(url, initialValue) {

    const [state, setState] = useState(initialValue);
    const [isLoading, setIsLoading] = useState();
    
    useEffect(() => {
        setIsLoading(true);
        fetch(url)
            .then(res => res.json())
            .then(data => {
                setState(data);
                setIsLoading(false);
            })
            .catch(err => console.log(err))
    }, [url])

    return [
        state,
        isLoading
    ]
}

export default useFetch;