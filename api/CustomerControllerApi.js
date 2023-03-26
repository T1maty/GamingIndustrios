import axios from "axios";


export const CustomerApi = (firstName, lastName, phoneNumber, separation, brunchNumber, createdDate) => {
    return axios.post({
        firstName: firstName,
        lastName: lastName,
        separation: separation,
        phoneNumber: phoneNumber,
        brunchNumber: brunchNumber,
        createdDate: createdDate,



        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json"
        },
        withCredentials: true,
    });
}