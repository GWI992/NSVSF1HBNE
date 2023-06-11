import Vuex from "vuex";
import createPersistedState from "vuex-persistedstate";
import auth from "./modules/auth";
import reservation from "./modules/reservation";
import table from "./modules/table";

// Create store
export default new Vuex.Store({
    modules: {
        auth,
        reservation,
        table,
    },
    plugins: [createPersistedState()],
});