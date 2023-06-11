<template>
    <section class="page-section" id="table">
        <div class="container">
            <div class="row">
                <div class="col-6">
                    <h5>Tables</h5>
                </div>
                <div class="col-6 text-end">
                    <router-link to="/table/create" class="btn btn-success px-lg-3 rounded text-end">Create</router-link>
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="col-lg-10 col-xl-10">
                    <table class="table table-striped table-borderless">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Name</th>
                                <th scope="col">Capacity</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="(table, index) in tables" v-key="table.id">
                                <th scope="row">{{ (index + 1) }}</th>
                                <td>{{ table.name }}</td>
                                <td>{{ table.capacity }}</td>
                                <td class="text-end">
                                    <router-link v-bind:to="'/table/' + table.id" class="btn btn-sm btn-secondary px-lg-3 rounded mx-1"><i class="fa fa-pencil"></i></router-link>
                                    <button class="btn btn-sm btn-danger px-lg-3 rounded mx-1" type="button" v-on:click="del(table)"><i class="fa fa-trash"></i></button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </section>
</template>

<script>
    import { mapActions } from "vuex"
    export default {
        name: 'Tables',
        data() {
            return {
                tables: [],
            }
        },
        mounted() {
            this.load();
        },
        methods: {
            ...mapActions(["TableList", "TableDelete"]),
            async load() {
                this.tables = await this.TableList();
            },
            async del(table) {
                if (confirm("Do you want delete " + table.name + "?") == true) {
                    await this.TableDelete(table);
                    this.load();
                }
            }
        },
    }
</script>

<style scoped>
</style>
