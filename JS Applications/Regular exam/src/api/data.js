import * as api from './api.js';

const host = 'http://localhost:3030';
api.settings.host = host;

export const login = api.login;
export const register = api.register;
export const logout = api.logout;


// Implement application-specific requests:
export async function getAllArticles() {
    return await api.get('/data/wiki?sortBy=_createdOn%20desc');
}

export async function getArticleById(id) {
    return await api.get('/data/wiki/' + id);
}

export async function deleteArticleById(id) {
    return await api.del('/data/wiki/' + id);
}

export async function createArticle(data) {
    return await api.post('/data/wiki', data);
}

export async function editArticleById(id, data) {
    return await api.put('/data/wiki/' + id, data);
}

export async function getRecentArticles() {
    return await api.get('/data/wiki?sortBy=_createdOn%20desc&distinct=category');
}

export async function getArticlesByTitle(query) {
    return await api.get(`/data/wiki?where=title%20LIKE%20%22${query}%22`);
}