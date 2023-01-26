import { useParams, useNavigate } from 'react-router-dom';
import { useEffect, useState } from 'react';

import * as petService from '../../services/petService';

import PetFormView from '../PetFormView/PetFormView';

function EditPet() {
    let [pet, setPet] = useState({});
    let [errorMessages, setErrorMessage] = useState({});

    const id = useParams().id;

    const navigate = useNavigate();

    useEffect(() => {
        petService.getOne(id).then((res) => {
            setPet(res);
        });
    }, []);

    function onSaveNewDataSubmitHandler(e) {
        e.preventDefault();

        if (e.target.description.value.length > 10) {
            let updatedPet = {
                id: id,
                name: e.target.name.value,
                description: e.target.description.value,
                imageURL: e.target.imageURL.value,
                category: e.target.category.value,
            };

            petService.update(updatedPet.id, updatedPet).then(() => navigate(`/pets/details/${updatedPet.id}`));
        }
    }

    const onDescriptionChangeHandler = (e) => {
        e.target.value.length < 10
            ? setErrorMessage((oldState) => ({ ...oldState, description: 'Description too short!' }))
            : setErrorMessage((oldState) => ({ ...oldState, description: '' }));
    };

    return (
        <PetFormView
            onSubmitHandler={onSaveNewDataSubmitHandler}
            onDescriptionChangeHandler={onDescriptionChangeHandler}
            data={pet}
            errorMessages={errorMessages}
        />
    );
}

export default EditPet;
