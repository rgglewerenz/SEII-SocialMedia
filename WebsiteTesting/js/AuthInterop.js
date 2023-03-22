async function authenticateUser(email, password) {
    const response = await fetch(baseUrl + `auth/AuthenticateUser?email=${email}&password=${password}`);
    const data = await response.json();
    return data;
}