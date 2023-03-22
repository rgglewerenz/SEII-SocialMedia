const baseUrl = "https://localhost:7122/api/";

async function getUsers() {
    const response = await fetch(baseUrl + "user/GetUsers");
    const data = await response.json();
    return data;
}

async function getUserByID(userID) {
    const response = await fetch(baseUrl + `user/GetUserByID?userID=${userID}`);
    const data = await response.json();
    return data;
}

async function createUser(email, password) {
    const response = await fetch(baseUrl + `user/CreateUser?email=${email}&password=${password}`, {
        method: "POST"
    });
    const data = await response.json();
    return data;
}

async function GetUsers() {
    const response = await getUsers();

    console.log(response);
}
