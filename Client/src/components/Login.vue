<template>
    <section class="page-section" id="login">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-8 col-xl-7">
                    <form id="contactForm">
                        <div id="submitErrorMessage"><div class="text-center text-danger mb-3">Error sending message!</div></div>

                        <div class="form-floating mb-3">
                            <input class="form-control" id="username" type="text" placeholder="Enter your username..." data-sb-validations="required" />
                            <label for="username">Username</label>
                        </div>

                        <div class="form-floating mb-3">
                            <input class="form-control" id="password" type="password" placeholder="ABCD123456" data-sb-validations="required,password" />
                            <label for="password">Password</label>
                        </div>

                        <button class="btn btn-primary btn-xl disabled" id="submitButton" type="button">Login</button>
                    </form>
                </div>
            </div>
        </div>
    </section>
</template>

<script>
export default {
  name: 'Login',
}
</script>

<style scoped>
</style>
