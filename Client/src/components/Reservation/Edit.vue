<template>
    <section class="page-section" id="reservation-create">
        <div class="container">
            <div class="row">
                <div class="col-6">
                    <h5>Edit reservation: {{ reservation.name }}</h5>
                </div>
                <div class="col-6 text-end">
                    <router-link to="/reservation"><i class="my-0 fa fa-arrow-up"></i> Back</router-link>
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="col-lg-8 col-xl-7">
                    <form id="contactForm">
                        <div class="form-floating mb-3">
                            <input class="form-control" id="reservation-name" type="text" placeholder="Enter name..." v-model="reservation.name" />
                            <label for="reservation-name">Name</label>
                        </div>

                        <div class="form-floating mb-3">
                            <input class="form-control" id="reservation-begin" type="datetime-local" v-model="reservation.begin" />
                            <label for="reservation-begin">Begin</label>
                        </div>

                        <div class="form-floating mb-3">
                            <input class="form-control" id="reservation-end" type="datetime-local" v-model="reservation.end" />
                            <label for="reservation-end">End</label>
                        </div>

                        <div class="form-floating mb-3">
                            <input class="form-control" id="reservation-person" type="number" placeholder="4" min="1" max="4" v-model="reservation.person" />
                            <label for="reservation-person">Person</label>
                        </div>

                        <div class="form-floating mb-3">
                            <input class="form-control" list="tableList" id="reservation-person" placeholder="Type to search..." v-model="selectedTable" />
                            <datalist id="tableList">
                                <option v-for="table in tables" v-bind:value="table.name" />
                            </datalist>
                            <label for="reservation-person" class="form-label">Table</label>
                        </div>

                        <button class="btn btn-primary btn-xl float-end" id="submitButton" type="button" v-on:click="save">Save</button>
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
        name: 'Reservation edit',
        setup() {
            const toast = useToast();
            return { toast }
        },
        data() {
            return {
                tables: [],
                reservation: {
                    "name": null,
                    "contact": new Date().toISOString().slice(0, 19),
                    "begin": null,
                    "end": null,
                    "person": 1,
                    "tableId": null
                },
                selectedTable: null,
            }
        },
        created() {
            this.load(this.$route.params.id);
        },
        methods: {
            ...mapActions(["ReservationUpdate", "ReservationGet", "TableList"]),
            async load(reservationId) {
                this.reservation = await this.ReservationGet(reservationId);
                if (!this.reservation.id) {
                    this.triggerToast("Reservation not found", "error");
                    this.$router.push('/reservation');
                }
                this.tables = await this.TableList();
                this.selectedTable = this.tables.find(x => x.id == this.reservation.tableId)?.name;
            },
            async save() {

                if (!this.reservation.name) {
                    this.triggerToast("Name is required", "error");
                    return;
                }
                if (!this.reservation.contact) {
                    this.triggerToast("Contact is required", "error");
                    return;
                }
                if (!this.reservation.begin) {
                    this.triggerToast("Begin is required", "error");
                    return;
                }
                if (!this.reservation.end) {
                    this.triggerToast("End is required", "error");
                    return;
                }
                if (!this.reservation.person) {
                    this.triggerToast("Person is required", "error");
                    return;
                }
                if (!this.reservation.tableId) {
                    this.triggerToast("Table is required", "error");
                    return;
                }

                if (await this.ReservationUpdate(this.reservation)) {
                    this.triggerToast("Save successful", "success", "fas fa-check");
                    this.$router.push('/reservation');
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
            watch: {
                selectedTable: function (val) {
                    this.reservation.tableId = val ? this.tables.find(x => x.name == val)?.id : null;
                }
            }
        },
    }
</script>

<style scoped>
</style>
