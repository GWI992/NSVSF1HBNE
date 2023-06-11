import { createRouter, createWebHistory } from 'vue-router';

import Home from '@/components/BaseTemplate.vue'

import Login from '@/components/Login.vue';
import TableList from '@/components/Table/List.vue';
import TableCreate from '@/components/Table/Create.vue';
import TableEdit from '@/components/Table/Edit.vue';

const routes = [
    { path: '/', component: Home },
    { path: '/login', component: Login },
    { path: '/table', component: TableList },
    { path: '/table/create', component: TableCreate },
    { path: '/table/:id', component: TableEdit },
];

const router = createRouter({ history: createWebHistory(), routes });
export default router;