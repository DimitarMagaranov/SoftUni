export const settings = {
    host: ''
};

async function request(url, options) {
    try {
        const response = await fetch(url, options);

        if (response.ok == false) {
            const error = await response.json();
            throw new Error(error.message);
        }

        try {
            const data = await response.json();
            return data;
        } catch (error) {
            return response;
        }
    } catch (error) {
        alert(error.mesage);
        throw error;
    }
}

function getOptions(method = 'get', body) {
    const options = {
        method,
        headers: {}
    };

    const token = sessionStorage.getItem('authToken');
    if (token != null) {
        options.headers['X-Authorization'] = token;
    }

    if (body) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(body);
    }

    return options;
}

export async function get(url) {
    return await request(settings.host + url, getOptions());
}

export async function post(url, data) {
    return await request(settings.host + url, getOptions('post', data));
}

export async function put(url, data) {
    return await request(settings.host + url, getOptions('put', data));
}

export async function del(url) {
    return await request(settings.host + url, getOptions('delete'));
}

export async function login(username, password) {
    const result = await post('/users/login', {username, password});

    sessionStorage.setItem('authToken', result.accessToken);
    sessionStorage.setItem('userId', result._id);
    sessionStorage.setItem('username', result.username);

    return result;
}

export async function register(username, password) {
    const result = await post('/users/register', {username, password});

    sessionStorage.setItem('authToken', result.accessToken);
    sessionStorage.setItem('userId', result._id);
    sessionStorage.setItem('username', result.username);

    return result;
}

export async function logout() {
    const result = await get('/users/logout');

    sessionStorage.removeItem('authToken');
    sessionStorage.removeItem('email');
    sessionStorage.removeItem('userId');
    sessionStorage.removeItem('userGender');
    sessionStorage.removeItem('username');

    return result;
}