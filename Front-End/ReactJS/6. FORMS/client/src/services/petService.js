const url = "http://localhost:5000/pets";

export function getAll(category = "") {
    const petsUrl = url + ((category && category != "All") ? `?category=${category}` : "");

    return fetch(petsUrl)
        .then((res) => res.json())
        .catch((err) => console.log(err));
}

export function getOne(id) {
    return fetch(`${url}/${id}`)
        .then((res) => res.json())
        .catch((err) => console.log(err));
}
