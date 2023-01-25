import { useParams, Link } from 'react-router-dom';
import { useEffect, useState } from 'react';

import * as petService from '../../services/petService';

function PetDetails() {
    let [pet, setPet] = useState({});
    const id = useParams().id;

    useEffect(() => {
        petService.getOne(id).then((res) => setPet(res));
    }, []);

    function onLikePetHandler(e) {
        let updatedPet = { ...pet, likes: pet.likes + 1 };
        petService.update(id, updatedPet).then(() => setPet(updatedPet))
    }

    return (
        <section className="detailsOtherPet">
            <h3>{pet.name}</h3>
            <p>
                Pet counter: {pet.likes}
                <button onClick={onLikePetHandler} className="button"> 
                        <i className="fas fa-heart"></i> Pet
                    </button>
            </p>
            <p className="img">
                <img src={pet.imageURL} />
            </p>
            <p className="description">{pet.description}</p>
            <div className="pet-info">
                <Link to={`/pets/details/${pet.id}/edit`}>
                    <button className="button">Edit</button>
                </Link>
                <Link>
                    <button className="button">Delete</button>
                </Link>
            </div>
        </section>
    );
}

export default PetDetails;
