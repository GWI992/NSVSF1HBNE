import { createApp } from 'vue';
import App from './App.vue';

import axios from 'axios';
axios.defaults.withCredentials = false;
axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
axios.defaults.baseURL = process.env.VUE_APP_API_HOST;

axios.interceptors.response.use(function (response) {
    if (response && 'status' in response && response.status == 200 && (typeof response.data) !== 'undefined') {
        if ((typeof response?.data.value) !== 'undefined' && (typeof response.data.value?.errors) !== 'undefined') {
            response.status = 400;
            const errors = Object.entries(response.data.value.errors).map(([name, obj]) => ({ name, ...obj }))
            errors.forEach((err) => {
                showToast(err[0]);
            });
            return response;
        }
    }

    return response;
});

axios.interceptors.response.use(undefined, function (error) {
    if (error) {
        const originalRequest = error.config;
        if (error.constructor.name == "AxiosError") {
            if (error.response.status == 400) {
                if (error.response.data.errors) {
                    const errors = Object.entries(error.response.data.errors).map(([name, obj]) => ({ name, ...obj }))
                    errors.forEach((err) => {
                        showToast(err[0]);
                    })
                }
            }
            if (error.response.status == 401) {
                showToast('401 - Unauthorized.');
            }
            if (error.response.status == 404) {
                showToast('404 - Not found.');
            }
            else if (error.response.status === 401 && !originalRequest._retry) {
                originalRequest._retry = true;
                store.dispatch('Logout')
            }
            else {
                showToast(error.code + ' - ' + error.message);
            }
        }
        else if (error?.response && error.response?.status === 500) {
            showToast('500 - Internal server error');
        }
    }

    return error.response;
});


import router from './router';
import store from './store';

import Toast from 'vue-toastification'
import { useToast } from "vue-toastification";
import 'vue-toastification/dist/index.css'

const app = createApp(App);
app.use(store);
app.use(router);
app.use(Toast);
app.mount('#app');


function showToast(message, status = "error") {
    const toast = useToast();
    toast(message, {
        position: "top-right",
        timeout: 5000,
        closeOnClick: true,
        pauseOnFocusLoss: true,
        pauseOnHover: true,
        draggable: true,
        draggablePercent: 0.6,
        showCloseButtonOnHover: false,
        hideProgressBar: true,
        closeButton: "button",
        icon: "fas fa-times",
        rtl: false,
        type: status
    });
}