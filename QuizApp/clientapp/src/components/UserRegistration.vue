<template>
    <section class="vh-100 bg-image">
        <div class="mask d-flex align-items-center h-100 gradient-custom-3">
            <div class="container h-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-12 col-md-9 col-lg-7 col-xl-6">
                        <div class="card" style="border-radius: 15px;">
                            <div class="card-body p-5">
                                <h2 class="text-uppercase text-center mb-5">Create an account</h2>
                                <form ref="userRegistrationForm" @submit.prevent="submitForm">
                                    <div class="row">
                                        <div class="col-md-6 mb-4">
                                            <div class="form-outline">
                                                <input type="text" id="firstName" class="form-control form-control-lg"
                                                    v-model="firstName" />
                                                <label class="form-label" for="firstName">First Name</label>
                                            </div>
                                        </div>
                                        <div class="col-md-6 mb-4">
                                            <div class="form-outline">
                                                <input type="text" id="lastName" class="form-control form-control-lg"
                                                    v-model="lastName" />
                                                <label class="form-label" for="lastName">Last Name</label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-outline mb-4">
                                        <input type="email" id="email" class="form-control form-control-lg"
                                            v-model="email" />
                                        <label class="form-label" for="email">Email</label>
                                    </div>

                                    <div class="form-outline mb-4">
                                        <input type="text" id="username" class="form-control form-control-lg"
                                            v-model="username" />
                                        <label class="form-label" for="username">Username</label>
                                    </div>

                                    <div class="form-outline mb-4">
                                        <input type="password" id="password" class="form-control form-control-lg"
                                            v-model="password" />
                                        <label class="form-label" for="password">Password</label>
                                    </div>

                                    <div class="form-outline mb-4">
                                        <input type="password" id="confirm-password"
                                            class="form-control form-control-lg" v-model="confirmPassword" />
                                        <label class="form-label" for="confirm-password">Confirm password</label>
                                    </div>

                                    <div class="d-flex justify-content-center">
                                        <button type="submit" class="btn btn-primary btn-lg">Register</button>
                                    </div>

                                    <p class="text-center text-muted mt-5 mb-0">Have already an account? <a
                                            href="/login" class="fw-bold text-body"><u>Login here</u></a></p>

                                </form>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</template>

<script>
export default {
    name: "UserRegistration",
    data() {
        return {
            firstName: '',
            lastName: '',
            email: '',
            username: '',
            password: '',
            confirmPassword: ''
        }
    },
    methods: {
        async submitForm() {
            var data = JSON.stringify({
                firstName: this.firstName,
                lastName: this.lastName,
                userName: this.username,
                email: this.email,
                password: this.password
            });

            await fetch('api/Users', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: data
            });

            this.$refs.userRegistrationForm.reset();
        }
    }
}
</script>

<style scoped>

</style>
