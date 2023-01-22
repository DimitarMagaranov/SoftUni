import { useNavigate } from "react-router-dom";

import * as petService from "../../services/petService";
import { v4 as uniqueIdGenerator } from "uuid";
import PetFormView from "../PetFormView/PetFormView";

function CreatePet() {
    const navigate = useNavigate();

    function onCreatePetSubmitHandler(e) {
        e.preventDefault();

        const data = {
            id: uniqueIdGenerator(),
            name: e.target.name.value,
            description: e.target.description.value,
            imageURL: e.target.image.value,
            category: e.target.category.value,
            likes: 0
        };

        petService.create(data).then((res) => navigate(`/pets/details/${res.id}`));
    }

    return (
        <PetFormView
            onSubmitHandler={onCreatePetSubmitHandler}
        />
    );
}

export default CreatePet;
