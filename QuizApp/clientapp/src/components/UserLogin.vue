<template>
    <section class="vh-100 bg-image">
        <div class="mask d-flex align-items-center h-100 gradient-custom-3">
            <div class="container h-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-12 col-md-9 col-lg-7 col-xl-6">
                        <div class="card" style="border-radius: 15px;">
                            <div class="card-body p-5">
                                <h2 class="text-uppercase text-center mb-5">Log in</h2>
                                <form ref="userLoginForm" @submit.prevent="submitForm">
                                    <div class="form-outline mb-4">
                                        <input type="email" id="email" class="form-control form-control-lg"
                                            v-model="email" />
                                        <label class="form-label" for="email">Email</label>
                                    </div>

                                    <div class="form-outline mb-4">
                                        <input type="password" id="password" class="form-control form-control-lg"
                                            v-model="password" />
                                        <label class="form-label" for="password">Password</label>
                                    </div>

                                    <div class="d-flex justify-content-center">
                                        <button type="submit" class="btn btn-primary btn-lg">Log in</button>
                                    </div>

                                    <p class="text-center text-muted mt-5 mb-0">Need an account? <a href="/signup"
                                            class="fw-bold text-body"><u>Sign up here</u></a></p>
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
    name: "UserLogin",
    data() {
        return {
            email: '',
            password: ''
        }
    },
    methods: {
        async submitForm() {
            const data = JSON.stringify({
                email: this.email,
                password: this.password
            });

            const response = await fetch('api/Account/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: data
            });

            const responseResult = await response.json();

            this.$refs.userLoginForm.reset();

            if (responseResult.succeeded) {
                this.$store.commit("setAuthentication", true);
                console.log(this.$store.state.isAuthenticated);
                this.$router.push({ name: 'Dashboard' });
            }
        }
    }
}
</script>