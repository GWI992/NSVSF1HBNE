import { createRouter, createWebHistory } from 'vue-router';

import Home from '@/components/BaseTemplate.vue'

import Login from '@/components/Login.vue';

const routes = [
    { path: '/', component: Home },
    { path: '/login', component: Login },
];

const router = createRouter({ history: createWebHistory(), routes });
export default router;