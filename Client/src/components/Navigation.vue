<template>
    <nav class="navbar navbar-expand-lg bg-secondary text-uppercase fixed-top p-1" id="mainNav">
        <div class="container">
            <router-link to="/" class="navbar-brand">Table Reservation</router-link>
            <button class="navbar-toggler text-uppercase font-weight-bold bg-primary text-white rounded" type="button" data-bs-toggle="collapse" data-bs-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                Menu
                <i class="fas fa-bars"></i>
            </button>
            <div class="collapse navbar-collapse" id="navbarResponsive">
                <ul class="navbar-nav ms-auto">
                    <li class="nav-item mx-0 mx-lg-1"><router-link to="/" class="nav-link py-3 px-0 px-lg-3 rounded">Home</router-link></li>
                    <li v-if="!isAuthenticated" class="nav-item mx-0 mx-lg-1"><router-link to="/login" class="nav-link py-3 px-0 px-lg-3 rounded">Login</router-link></li>
                    <li v-if="isAuthenticated && isAdmin" class="nav-item mx-0 mx-lg-1"><router-link to="/table" class="nav-link py-3 px-0 px-lg-3 rounded">Tables</router-link></li>
                    <li v-if="isAuthenticated" class="nav-item mx-0 mx-lg-1"><router-link to="/reservation" class="nav-link py-3 px-0 px-lg-3 rounded">Reservations</router-link></li>
                    <li v-if="isAuthenticated" class="nav-item mx-0 mt-2 mx-lg-1"><button class="btn btn-sm btn-danger float-end rounded" type="button" v-on:click="LogoutTrigger">Logout</button></li>
                </ul>
            </div>
        </div>
    </nav>
</template>

<script>
    import { mapGetters, mapActions } from "vuex"
    import { useToast } from "vue-toastification";
    export default {
        name: 'HelloWorld',
        setup() {
            const toast = useToast();
            return { toast }
        },
        computed: {
            ...mapGetters({
                isAuthenticated: "isAuthenticated",
                Role: "userRole",
            }),
            isAdmin() {
                return this.Role == "Administrator";
            }
        },
        methods: {
            ...mapActions(["Logout"]),
            LogoutTrigger() {
                this.toast("Logout successful");
                this.Logout();
                this.$router.push('/');
            }
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
