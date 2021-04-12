import * as api from './api.js';

const host = 'http://localhost:3030';
api.settings.host = host;

export const login = api.login;
export const register = api.register;
export const logout = api.logout;


// Implement application-specific requests:
export async function getAllListings(page = 1) {
    return await api.get(`/data/cars?sortBy=_createdOn%20desc&offset=${(page - 1) * 3}&pageSize=3`);
}

export async function getListingsCount() {
    return await api.get('/data/cars?count');
}

export async function getListingById(id) {
    return await api.get('/data/cars/' + id);
}

export async function deleteListingById(id) {
    return await api.del('/data/cars/' + id);
}

export async function createListing(data) {
    return await api.post('/data/cars', data);
}

export async function editListingById(id, data) {
    return await api.put('/data/cars/' + id, data);
}

export async function getMyListings() {
    const userId = sessionStorage.getItem('userId');
    return await api.get(`/data/cars?where=_ownerId%3D"${userId}"&sortBy=_createdOn%20desc`);
}

export async function getListingsByYear(query) {
    return await api.get(`/data/cars?where=year%3D${query}`);
}