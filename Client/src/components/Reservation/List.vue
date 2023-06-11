<template>
    <section class="page-section" id="table">
        <div class="container">
            <div class="text-end mb-2">
                <router-link to="/reservation/create" class="btn btn-success px-lg-3 rounded w-100">Create</router-link>
            </div>
            <div class="row justify-content-center">
                <div class="col-12 col-md-6 col-xl-4 my-2">
                    <div class="card">
                        <div class="card-header text-center">
                            #1 Reservation

                            <button class="btn btn-sm btn-danger px-lg-3 rounded mx-1 float-end" type="button"><i class="fa fa-trash"></i></button>
                            <router-link to="/reservation/1" class="btn btn-sm btn-secondary px-lg-3 rounded mx-1 float-end"><i class="fa fa-pencil"></i></router-link>
                        </div>
                        <div class="card-body">
                            <h5 class="card-title text-center">Name</h5>
                            <p class="card-text">Begin</p>
                            <p class="card-text">End</p>
                            <p class="card-text">Person</p>
                            <p class="card-text">Table</p>
                        </div>
                        <div class="card-footer text-body-secondary text-center">
                            Contact
                        </div>
                    </div>
                </div>
                <div class="col-12 col-md-6 col-xl-4 my-2">
                    <div class="card">
                        <div class="card-header text-center">
                            #1 Reservation

                            <button class="btn btn-sm btn-danger px-lg-3 rounded mx-1 float-end" type="button"><i class="fa fa-trash"></i></button>
                            <router-link to="/reservation/2" class="btn btn-sm btn-secondary px-lg-3 rounded mx-1 float-end"><i class="fa fa-pencil"></i></router-link>
                        </div>
                        <div class="card-body">
                            <h5 class="card-title text-center">Name</h5>
                            <p class="card-text">Begin</p>
                            <p class="card-text">End</p>
                            <p class="card-text">Person</p>
                            <p class="card-text">Table</p>
                        </div>
                        <div class="card-footer text-body-secondary text-center">
                            Contact
                        </div>
                    </div>
                </div>
                <div class="col-12 col-md-6 col-xl-4 my-2">
                    <div class="card">
                        <div class="card-header text-center">
                            #1 Reservation

                            <button class="btn btn-sm btn-danger px-lg-3 rounded mx-1 float-end" type="button"><i class="fa fa-trash"></i></button>
                            <router-link to="/reservation/3" class="btn btn-sm btn-secondary px-lg-3 rounded mx-1 float-end"><i class="fa fa-pencil"></i></router-link>
                        </div>
                        <div class="card-body">
                            <h5 class="card-title text-center">Name</h5>
                            <p class="card-text">Begin</p>
                            <p class="card-text">End</p>
                            <p class="card-text">Person</p>
                            <p class="card-text">Table</p>
                        </div>
                        <div class="card-footer text-body-secondary text-center">
                            Contact
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</template>

<script>
    export default {
        name: 'Reservations',
    }
</script>

<style scoped>
</style>
