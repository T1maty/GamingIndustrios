import axios from "axios";

export const AddXboxApi = (username, price, nameXbox) => {
    return axios.post({
        username: Username,
        price: price,
        nameXbox: nameXbox,

        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json"
        },
        withCredentials: true,
    })


}