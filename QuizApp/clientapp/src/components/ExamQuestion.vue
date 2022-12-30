<template>
    <div>
        <h6>{{ Question.title }}</h6>
        <form>
            <div class="form-check" v-for="(option, index) in Question.options" :key="index">
                <input class="form-check-input" type="radio" name="exampleRadios" :value="option.id"
                    v-on:change="onChecked(option.id)" :checked="Question.answer == option.id">
                <label class="form-check-label">
                    {{ option.name }}
                </label>
            </div>
        </form>
    </div>
</template>

<script>
export default {
    name: 'ExamQuestion',
    props: {
        Question: Object
    },
    emits: ['radio-checked'],
    data() {
        return {
            selectedId: ''
        }
    },
    methods: {
        onChecked(id) {
            console.log("checked " + id);
            this.$emit('radio-checked', id);
        }
    }
}
</script>
