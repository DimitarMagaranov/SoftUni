import { Link } from 'react-router-dom';
import { useState } from 'react';

import * as petService from '../../services/petService';

function PetCard({ data }) {
    const [likes, setLikes] = useState(data.likes);

    function onLikePetHandler(e) {
        petService.like(data.id, likes + 1).then((res) => setLikes(res.likes));
    }

    return (
        <li className="otherPet">
            <h3>Name: {data.name}</h3>
            <p>Category: {data.category}</p>
            <p className="img">
                <img src={data.imageURL} />
            </p>
            <p className="description">{data.description}</p>
            <div className="pet-info">
                <Link to="#">
                    <button id="asd" onClick={onLikePetHandler} className="button">
                        <i className="fas fa-heart"></i> Pet
                    </button>
                </Link>
                <Link to={`/pets/details/${data.id}`}>
                    <button className="button">Details</button>
                </Link>
                <i className="fas fa-heart"></i> <span>{likes}</span>
            </div>
        </li>
    );
}

export default PetCard;
