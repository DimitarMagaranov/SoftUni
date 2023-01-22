import { useParams } from "react-router-dom";

const withRoouter = WrappedComponent => props => {
    const params = useParams();

    return (
        <WrappedComponent {...props} params={params}/>
    )
}

export default withRoouter;