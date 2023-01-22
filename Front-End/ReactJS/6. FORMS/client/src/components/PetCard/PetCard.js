import {Link} from 'react-router-dom';

function PetCard({data}) {
    return (
        <li className="otherPet">
            <h3>Name: {data.name}</h3>
            <p>Category: {data.category}</p>
            <p className="img">
                <img src={data.imageURL} />
            </p>
            <p className="description">{data.description}</p>
            <div className="pet-info">
                <Link href="#">
                    <button className="button">
                        <i className="fas fa-heart"></i> Pet
                    </button>
                </Link>
                <Link to={`/pets/details/${data.id}`}>
                    <button className="button">Details</button>
                </Link>
                <i className="fas fa-heart"></i> <span> {data.likes}</span>
            </div>
        </li>
    );
}

export default PetCard;
