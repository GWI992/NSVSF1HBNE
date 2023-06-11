import { createRouter, createWebHistory } from 'vue-router';
import store from "./store";

import Home from '@/components/BaseTemplate.vue'
import Login from '@/components/Login.vue';

import TableList from '@/components/Table/List.vue';
import TableCreate from '@/components/Table/Create.vue';
import TableEdit from '@/components/Table/Edit.vue';

import ReservationList from '@/components/Reservation/List.vue';
import ReservationCreate from '@/components/Reservation/Create.vue';
import ReservationEdit from '@/components/Reservation/Edit.vue';

const routes = [
    {
        path: '/',
        component: Home,
        meta: { requiresAuth: false },
    },
    {
        path: '/login',
        component: Login,
        meta: { requiresAuth: false }
    },

    {
        path: '/table',
        component: TableList,
        meta: {
            requiresAuth: true,
            authorize: ["Administrator"]
        }
    },
    {
        path: '/table/create',
        component: TableCreate,
        meta: {
            requiresAuth: true,
            authorize: ["Administrator"]
        }
    },
    {
        path: '/table/:id',
        component: TableEdit,
        meta: {
            requiresAuth: true,
            authorize: ["Administrator"]
        }
    },

    {
        path: '/reservation',
        component: ReservationList,
        meta: {
            requiresAuth: true,
            authorize: ["Administrator", "Manager"]
        }
    },
    {
        path: '/reservation/create',
        component: ReservationCreate,
        meta: {
            requiresAuth: true,
            authorize: ["Administrator", "Manager"]
        }
    },
    {
        path: '/reservation/:id',
        component: ReservationEdit,
        meta: {
            requiresAuth: true,
            authorize: ["Administrator", "Manager"]
        }
    },
];

const router = createRouter({ history: createWebHistory(), routes });

router.beforeEach(async (to, from, next) => {
    const { authorize } = to.meta;
    if (to.matched.some((record) => record.meta.requiresAuth)) {
        if (!store.getters.isAuthenticated) {
            window.location = process.env.BASE_URL;
            return;
        }

        if (typeof authorize === 'undefined' || authorize.length == 0) {
            next();
            return;
        }

        if (typeof authorize === 'object' && authorize.some(role => store.getters.userRole == role)) {
            next();
            return;
        }

        window.location = process.env.BASE_URL;
        return;
    }
    else if (to.name == 'not-found') {
        window.location = process.env.BASE_URL;
    }
    else {
        next();
    }
});

export default router;