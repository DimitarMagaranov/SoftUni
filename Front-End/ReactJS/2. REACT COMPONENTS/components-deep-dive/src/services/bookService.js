function getBooks() {
    return fetch("http://localhost:3000/books")
        .then((res) => res.json())
        .catch((err) => console.log(err));
}

export default {
    getBooks,
};
