import { createRouter, createWebHistory } from 'vue-router';

import Home from '@/components/BaseTemplate.vue'
import Login from '@/components/Login.vue';

import TableList from '@/components/Table/List.vue';
import TableCreate from '@/components/Table/Create.vue';
import TableEdit from '@/components/Table/Edit.vue';

import ReservationList from '@/components/Reservation/List.vue';
import ReservationCreate from '@/components/Reservation/Create.vue';
import ReservationEdit from '@/components/Reservation/Edit.vue';

const routes = [
    { path: '/', component: Home },
    { path: '/login', component: Login },

    { path: '/table', component: TableList },
    { path: '/table/create', component: TableCreate },
    { path: '/table/:id', component: TableEdit },

    { path: '/reservation', component: ReservationList },
    { path: '/reservation/create', component: ReservationCreate },
    { path: '/reservation/:id', component: ReservationEdit },
];

const router = createRouter({ history: createWebHistory(), routes });
export default router;