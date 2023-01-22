import PetCard from "../PetCard/PetCard";

function PetList({pets}) {
    return (
        <ul className="other-pets-list">
            {pets?.map((x) => (
                <PetCard key={x.id} data={x} />
            ))}
        </ul>
    );
}

export default PetList;
