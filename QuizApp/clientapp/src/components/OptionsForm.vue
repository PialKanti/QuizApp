<template>
    <div class="modal fade" Id="OptionsModalForm" data-backdrop="static" data-keyboard="false" tabindex="-1"
        aria-labelledby="OptionFormLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="OptionFormLabel">Create Options</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="closeButton">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <form ref="optionsForm" @submit.prevent="submitForm">
                        <div class="form-outline mb-4">
                            <label class="form-label" for="name">Name</label>
                            <input type="text" id="name" class="form-control form-control-lg" v-model="name" />
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
            name: ''
        }
    },
    emits: ['option-added'],
    methods: {
        async submitForm() {
            this.$refs.optionsForm.reset();
            this.closeModal();
            this.$emit('option-added', this.name)

        },
        closeModal() {
            document.getElementById('closeButton').click();
        },
    }
}
</script>