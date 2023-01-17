import './Details.css';
import { useParams } from 'react-router-dom';

function Details() {
    const {name} = useParams();
    const {id} = useParams();

    return (
        <h1 className="details-msg">Details for {name} {id ? <span>with id: {id}</span> : ''}</h1>
    );
}

export default Details;