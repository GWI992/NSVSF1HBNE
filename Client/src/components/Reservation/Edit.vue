<template>
    <section class="page-section" id="reservation-create">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-8 col-xl-7">
                    <form id="contactForm">
                        <div id="submitErrorMessage"><div class="text-center text-danger mb-3">Error sending message!</div></div>

                        <div class="form-floating mb-3">
                            <input class="form-control" readonly v-bind:value="id" />
                        </div>

                        <div class="form-floating mb-3">
                            <input class="form-control" id="reservation-name" type="text" placeholder="Enter name..." />
                            <label for="reservation-name">Name</label>
                        </div>

                        <div class="form-floating mb-3">
                            <input class="form-control" id="reservation-begin" type="datetime-local" />
                            <label for="reservation-begin">Begin</label>
                        </div>

                        <div class="form-floating mb-3">
                            <input class="form-control" id="reservation-end" type="datetime-local" />
                            <label for="reservation-end">End</label>
                        </div>

                        <div class="form-floating mb-3">
                            <input class="form-control" id="reservation-person" type="number" placeholder="4" min="1" max="4" />
                            <label for="reservation-person">Person</label>
                        </div>

                        <div class="form-floating mb-3">
                            <input class="form-control" list="tableList" id="reservation-person" placeholder="Type to search..." />
                            <datalist id="tableList">
                                <option value="#1 Table" />
                                <option value="#2 Table" />
                                <option value="#3 Table" />
                                <option value="#4 Table" />
                            </datalist>
                            <label for="reservation-person" class="form-label">Table</label>
                        </div>

                        <button class="btn btn-primary btn-xl float-end" id="submitButton" type="button">Save</button>
                    </form>
                </div>
            </div>
        </div>
    </section>
</template>

<script>
export default {
        name: 'Reservation edit',
        data() {
            return {
                id: null,
            }
        },
        created() {
            this.id = this.$route.params.id;
        },
}
</script>

<style scoped>
</style>
