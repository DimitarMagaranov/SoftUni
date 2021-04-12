import * as api from './api.js';

const host = 'http://localhost:3030';
api.settings.host = host;

export const login = api.login;
export const register = api.register;
export const logout = api.logout;


// Implement application-specific requests:

export async function getAllMemes() {
    return await api.get('/data/memes?sortBy=_createdOn%20desc');
}

export async function create(data) {
    return await api.post('/data/memes', data);
}

export async function getMemeById(id) {
    return await api.get('/data/memes/' + id);
}

export async function deleteMemeById(id) {
    return await api.del('/data/memes/' + id);
}

export async function editMemeById(id, data) {
    return await api.put('/data/memes/' + id, data);
}

export async function getAllMemesByUserId(id) {
    return await api.get(`/data/memes?where=_ownerId%3D"${id}"&sortBy=_createdOn%20desc`);
}