<template>
    <div class="row d-flex justify-content-center align-items-center h-100 mt-5">
        <div class="col-12 col-md-9 col-lg-7 col-xl-6">
            <div class="card" style="border-radius: 15px;">
                <div class="card-body p-5">
                    <h4 class="text-uppercase text-center mb-5">Create option</h4>
                    <form ref="optionsForm" @submit.prevent="submitForm">
                        <div class="form-outline mb-4">
                            <input type="text" id="name" class="form-control form-control-lg" v-model="name" />
                            <label class="form-label" for="name">Name</label>
                        </div>

                        <div>
                            <button type="submit" class="btn btn-primary">Create</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</template>

<script>export default {
    name: "OptionsForm",
    data() {
        return {
            title: '',
            name: '',
            option: {}
        }
    },
    created() {
        this.option = this.$store.state.option;

    },
    methods: {
        async submitForm() {
            const data = JSON.stringify({
                name: this.name
            });

            await fetch('api/Options', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: data
            });

            this.$router.push({ name: 'Option' });
            this.$refs.optionsForm.reset();

        }
    }
}
</script>