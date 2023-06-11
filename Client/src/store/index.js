import Vuex from "vuex";
import createPersistedState from "vuex-persistedstate";
import auth from "./modules/auth";
import table from "./modules/table";

// Create store
export default new Vuex.Store({
    modules: {
        auth,
        table,
    },
    plugins: [createPersistedState()],
});