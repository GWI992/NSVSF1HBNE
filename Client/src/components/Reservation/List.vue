<template>
    <section class="page-section" id="reservation">
        <div class="container">
            <div class="row">
                <div class="col-6">
                    <h5>Reservations</h5>
                </div>
                <div class="col-6 text-end">
                    <router-link to="/reservation/create" class="btn btn-success px-lg-3 rounded">Create</router-link>
                </div>
            </div>
            <div class="row justify-content-center mt-3">
                <div v-if="reservations.length > 0" class="col-12 col-md-6 col-xl-4 my-2" v-for="(reservation, index) in reservations" v-bind:key="reservation.id">
                    <div class="card">
                        <div class="card-header text-center">
                            <h5 class="card-title float-start mt-1 mb-0">{{ reservation.name }} </h5>

                            <button class="btn btn-sm btn-danger px-lg-3 rounded mx-1 float-end" type="button" v-on:click="del(reservation)"><i class="fa fa-trash"></i></button>
                            <router-link v-bind:to="'/reservation/' + reservation.id" class="btn btn-sm btn-secondary px-lg-3 rounded mx-1 float-end"><i class="fa fa-pencil"></i></router-link>
                        </div>
                        <div class="card-body">
                            <p class="card-text">Begin: {{ reservation.begin }}</p>
                            <p class="card-text">End: {{ reservation.end }}</p>
                            <p class="card-text">Person: {{ reservation.person }}</p>
                            <p class="card-text">Table: {{ reservation.table }}</p>
                        </div>
                        <div class="card-footer text-body-secondary text-center">
                            {{ reservation.contact }}
                        </div>
                    </div>
                </div>
                <div v-else class="alert alert-info">There is no reservation.</div>
            </div>
        </div>
    </section>
</template>

<script>
    import { mapActions } from "vuex"
    import { useToast } from "vue-toastification";
    export default {
        name: 'Reservations',
        setup() {
            const toast = useToast();
            return { toast }
        },
        data() {
            return {
                reservations: [],
            }
        },
        mounted() {
            this.load();
        },
        methods: {
            ...mapActions(["ReservationList", "ReservationDelete"]),
            async load() {
                this.reservations = await this.ReservationList();
            },
            async del(reservation) {
                if (confirm("Do you want delete " + reservation.name + "'s reservation?") == true) {
                    if (await this.ReservationDelete(reservation)) {
                        this.triggerToast('Reservation deleted.', "info");
                    }
                    this.load();
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
            },
        },
    }
</script>

<style scoped>
</style>
