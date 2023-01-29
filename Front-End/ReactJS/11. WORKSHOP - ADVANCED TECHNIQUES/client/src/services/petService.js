const url = 'http://localhost:5000/pets';

export function getAll(category = '') {
    const petsUrl = url + (category && category != 'All' ? `?category=${category}` : '');

    return fetch(petsUrl)
        .then((res) => res.json())
        .catch((err) => console.log(err));
}

export function getOne(id) {
    return fetch(`${url}/${id}`)
        .then((res) => res.json())
        .catch((err) => console.log(err));
}

export function create(data) {
    return fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    })
        .then((res) => res.json())
        .catch((err) => console.log(err));
}

export const update = (petId, pet) => {
    return fetch(`${url}/${petId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(pet),
    })
        .then((res) => res.json())
        .catch((err) => console.log(err));
};

export const like = (petId, likes) => {
    return fetch(`${url}/${petId}`, {
        method: 'PATCH',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({likes})
    })
        .then(res => res.json());
}
