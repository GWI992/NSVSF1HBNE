<template>
    <section class="page-section" id="table">
        <div class="container">
            <div class="text-end">
                <router-link to="/table/create" class="btn btn-success px-lg-3 rounded">Create</router-link>
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
                            <tr>
                                <th scope="row">1</th>
                                <td>#1 Table</td>
                                <td>1</td>
                                <td class="text-end">
                                    <router-link to="/table/1" class="btn btn-sm btn-secondary px-lg-3 rounded mx-1"><i class="fa fa-pencil"></i></router-link>
                                    <button class="btn btn-sm btn-danger px-lg-3 rounded mx-1" type="button"><i class="fa fa-trash"></i></button>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">2</th>
                                <td>#2 Table</td>
                                <td>2</td>
                                <td class="text-end">
                                    <router-link to="/table/2" class="btn btn-sm btn-secondary px-lg-3 rounded mx-1"><i class="fa fa-pencil"></i></router-link>
                                    <button class="btn btn-sm btn-danger px-lg-3 rounded mx-1" type="button"><i class="fa fa-trash"></i></button>
                                </td>
                            </tr>
                            <tr>
                                <th scope="row">3</th>
                                <td>#3 Table</td>
                                <td>4</td>
                                <td class="text-end">
                                    <router-link to="/table/3" class="btn btn-sm btn-secondary px-lg-3 rounded mx-1"><i class="fa fa-pencil"></i></router-link>
                                    <button class="btn btn-sm btn-danger px-lg-3 rounded mx-1" type="button"><i class="fa fa-trash"></i></button>
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
    export default {
        name: 'Tables',
    }
</script>

<style scoped>
</style>
