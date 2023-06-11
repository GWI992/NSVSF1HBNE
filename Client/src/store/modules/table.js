import axios from "axios";
var promiseFinally = require('promise.prototype.finally');
promiseFinally.shim();

const actions = {
    async TableList({ commit }) {
        return new Promise((resolve, reject) => {
            axios.get("/api/table")
                .then(response => {
                    console.log(response);
                    resolve(response.data);
                })
                .catch(err => {
                    console.warn(err);
                    reject(err);
                });
        });
    },
    async TableCreate({ commit }, table) {
        return new Promise((resolve, reject) => {
            axios.post("/api/table", table)
                .then(response => {
                    resolve(true);
                })
                .catch(err => {
                    console.warn(err);
                    reject(err);
                });
        });
    },
    async TableUpdate({ commit }, table) {
        return new Promise((resolve, reject) => {
            axios.put("/api/table/" + table.id, table)
                .then(response => {
                    resolve(true);
                })
                .catch(err => {
                    console.warn(err);
                    reject(err);
                });
        });
    },
    async TableDelete({ commit }, table) {
        console.log(table);
        return new Promise((resolve, reject) => {
            axios.delete("/api/table/" + table.id)
                .then(response => {
                    resolve(true);
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