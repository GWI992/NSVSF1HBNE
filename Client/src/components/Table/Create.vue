<template>
    <section class="page-section" id="table-create">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-8 col-xl-7">
                    <form id="contactForm">
                        <div class="form-floating mb-3">
                            <input class="form-control" id="table-name" type="text" placeholder="Enter name..." v-model="table.name"/>
                            <label for="table-name">Name</label>
                        </div>

                        <div class="form-floating mb-3">
                            <input class="form-control" id="table-capacity" type="number" placeholder="4" min="1" max="4" v-model="table.capacity"/>
                            <label for="table-capacity">Capacity</label>
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
        name: 'Table create',
        setup() {
            const toast = useToast();
            return { toast }
        },
        data() {
            return {
                table: {
                    name: null,
                    capacity: 1,
                },
            }
        },
        methods: {
            ...mapActions(["TableCreate"]),
            async save() {
                if (!this.table.name) {
                    this.triggerToast("Name is required", "error");
                    return;
                }

                if (!this.table.capacity) {
                    this.triggerToast("Capacity is required", "error");
                    return;
                }
                if (await this.TableCreate(this.table)) {
                    this.triggerToast("Save successful", "success", "fas fa-check");
                    this.$router.push('/table');
                }
                console.log(this.tables);
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
