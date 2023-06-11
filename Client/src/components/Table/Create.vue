<template>
    <section class="page-section" id="table-create">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-8 col-xl-7">
                    <form id="contactForm">
                        <div id="submitErrorMessage"><div class="text-center text-danger mb-3">Error sending message!</div></div>

                        <div class="form-floating mb-3">
                            <input class="form-control" id="table-name" type="text" placeholder="Enter name..."/>
                            <label for="table-name">Name</label>
                        </div>

                        <div class="form-floating mb-3">
                            <input class="form-control" id="table-capacity" type="number" placeholder="4" min="1" max="4" />
                            <label for="table-capacity">Capacity</label>
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
  name: 'Table create',
}
</script>

<style scoped>
</style>
