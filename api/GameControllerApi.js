import axios from "axios";

export const GameApi = (nameGame, price, genre) => {
    return axios.post({
        nameGame: nameGame,
        price: price,
        genre: genre,



        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json"
        },
        withCredentials: true,
    });
}