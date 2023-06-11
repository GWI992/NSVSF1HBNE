import axios from "axios";
var promiseFinally = require('promise.prototype.finally');
promiseFinally.shim();

const actions = {
    async ReservationList({ commit }) {
        return new Promise((resolve, reject) => {
            axios.get("/api/reservation")
                .then(response => {
                    resolve(response.data);
                })
                .catch(err => {
                    console.warn(err);
                    reject(err);
                });
        });
    },
    async ReservationGet({ commit }, reservationId) {
        return new Promise((resolve, reject) => {
            axios.get("/api/reservation/" + reservationId)
                .then(response => {
                    resolve(response.data);
                })
                .catch(err => {
                    console.warn(err);
                    reject(err);
                });
        });
    },
    async ReservationCreate({ commit }, reservation) {
        return new Promise((resolve, reject) => {
            axios.post("/api/reservation", reservation)
                .then(response => {
                    resolve(response && response.status == 200);
                })
                .catch(err => {
                    console.warn(err);
                    reject(err);
                });
        });
    },
    async ReservationUpdate({ commit }, reservation) {
        return new Promise((resolve, reject) => {
            axios.put("/api/reservation/" + reservation.id, reservation)
                .then(response => {
                    resolve(response && response.status == 200);
                })
                .catch(err => {
                    console.warn(err);
                    reject(err);
                });
        });
    },
    async ReservationDelete({ commit }, reservation) {
        console.log(reservation);
        return new Promise((resolve, reject) => {
            axios.delete("/api/reservation/" + reservation.id)
                .then(response => {
                    resolve(response.status == 200);
                })
                .catch(err => {
                    console.warn(err);
                    reject(err);
                });
        });
    },
};


export default {
    actions,
};