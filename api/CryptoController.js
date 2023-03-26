import axios from "axios";


export const cryptoTransferApi = (walletNumber, transferAmount) => {
    return axios.post({
        walletNumber: walletNumber,
        transferAmount: transferAmount,


        headers: {
            "Content-Type": "application/json",
            "Accept": "application/json"
        },
        withCredentials: true,

    });

}