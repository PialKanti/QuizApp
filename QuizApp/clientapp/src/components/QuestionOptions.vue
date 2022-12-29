<template>
    <div class="row mt-5">
        <div class="col-12">
            <a class="btn btn-success" href="/options-form" role="button">Create</a>
            <p v-if="isListEmpty" class="text-muted no-items-text mt-4">No options found</p>
            <table class="table table-bordered mt-3" v-else>
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Name</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    <OptionsRow v-for="(item, index) in options" :key="index" :option="item" :index="index">
                    </OptionsRow>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script>
import OptionsRow from "./OptionsRow.vue"

export default {
    name: "QuestionOptions",
    components: {
        OptionsRow
    },
    data() {
        return {
            options: [],
            isListEmpty: false
        }
    },
    async created() {
        this.refreshUI();
    },
    methods: {
        async fetchOptions() {
            const response = await fetch('api/Options');
            const data = await response.json();
            return data;
        },
        async refreshUI() {
            this.$store.commit('setOption', null);
            this.options = await this.fetchOptions();
            this.isListEmpty = this.options.length == 0;
        }
    }
}
</script>