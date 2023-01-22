import { useParams } from "react-router-dom";
import {useEffect, useState} from 'react';

import * as petService from '../../services/petService';

function PetDetails() {
    let [pet, setPet] = useState({});
    const id = useParams().id;

    useEffect(() => {
        petService.getOne(id)
            .then(res => setPet(res));
    }, []);

    return (
        <section className="detailsOtherPet">
            <h3>{pet.name}</h3>
            <p>
                Pet counter: {pet.likes}
                <a href="#">
                    <button className="button">
                        <i className="fas fa-heart"></i> Pet
                    </button>
                </a>
            </p>
            <p className="img">
                <img src={pet.imageURL} />
            </p>
            <p className="description">{pet.description}</p>
        </section>
    );
}

export default PetDetails;
