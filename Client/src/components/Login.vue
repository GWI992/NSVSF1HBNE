<template>
    <section class="page-section" id="login">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-8 col-xl-7">
                    <form id="contactForm">
                        <div class="form-floating mb-3">
                            <input class="form-control" id="username" type="text" placeholder="Enter your username..." v-model="user.email"/>
                            <label for="username">Username</label>
                        </div>

                        <div class="form-floating mb-3">
                            <input class="form-control" id="password" type="password" placeholder="ABCD123456" v-model="user.password" />
                            <label for="password">Password</label>
                        </div>

                        <button class="btn btn-primary btn-xl" id="submitButton" type="button" v-on:click="login">Login</button>
                    </form>
                </div>
            </div>
        </div>
    </section>
</template>

<script>
    import { mapActions } from "vuex"
    import { useToast } from "vue-toastification";

    export default {
        name: 'Login',
        setup() {
            const toast = useToast();
            return { toast }
        },
        data() {
            return {
                user: {
                    email: null,
                    password: null,
                },
            }
        },
        methods: {
            ...mapActions(["Login"]),
            async login() {
                if (!this.user.email) {
                    this.triggerToast("Username is required", "error");
                    return;
                }

                if (!this.user.password) {
                    this.triggerToast("Password is required");
                    return;
                }

                try {
                    let status = await this.Login(this.user);
                    if (status) {
                        this.triggerToast("Login successful", "success", "fas fa-check");
                        this.$router.push('/');
                    }
                }
                catch (ex) {
                    console.log(ex);
                }
            },
            triggerToast(message, type = "error", icon = "fas fa-times") {
                this.toast(message, {
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
                    icon: icon,
                    rtl: false,
                    type: type
                });
            }
        }
    };
</script>

<style scoped>
</style>
