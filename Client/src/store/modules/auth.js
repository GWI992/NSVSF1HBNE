import axios from "axios";
var promiseFinally = require('promise.prototype.finally');
promiseFinally.shim();

const getDefaultState = () => {
    return {
        user: null,
        role: null,
    };
}

const state = getDefaultState();

const getters = {
    isAuthenticated: (state) => !!state.user,
    userRole: (state) => state.role,
};

const actions = {
    ClearCache({ commit }) {
        commit("ClearCache");
    },
    Logout({ commit }) {
        commit("Logout");
    },
    async Login({ commit }, data) {
        return new Promise((resolve, reject) => {
            axios.post("/api/account/login", data)
                .then(response => {
                    commit("SetToken", response.data.token);
                    commit("SetUser", response.data.user);
                    let parsedToken = parseJwt(response.data.token);
                    commit("SetRole", parsedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]);
                    resolve(true);
                })
                .catch(err => {
                    console.warn(err);
                    reject(err);
                });
        });
    },
};

const mutations = {
    ClearCache(state) {
        let defaultState = getDefaultState();
        Object.entries(defaultState).forEach(([key, value]) => {
            if (key != 'user') {
                state[key] = value;
            }
        });
    },
    Logout(state) {
        state.user = null;
        axios.defaults.headers.common['Authorization'] = null;
    },
    SetUser(state, user) {
        state.user = user;
    },
    SetToken(state, token) {
        axios.defaults.headers.common['Authorization'] = 'Bearer ' + token;
    },
    SetRole(state, role) {
        state.role = role;
    },
};

export default {
    actions,
    getters,
    mutations,
    state,
};

function parseJwt(token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(window.atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
}