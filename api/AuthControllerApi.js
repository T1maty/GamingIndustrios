import axios from "axios";

export const registerUserApi = (phoneNumber, password, username, gmail) => {
    return axios.post({ phoneNumber: phoneNumber, password: password, username: username, gmail: gmail })
}

export const loginUserApi = (phoneNumber, password, username, gmail) => {
    return axios.post(JSON.stringfy({ phoneNumber: phoneNumber, password: password, username: username, gmail: gmail }), {
        auth: {
            username: gmail,
            password: password
        },
        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json"
        },
        withCredentials: true,
    });
}