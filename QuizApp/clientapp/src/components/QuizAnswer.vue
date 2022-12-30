<template>
    <h2 class="mt-3 mb-4">{{ quiz.name }}</h2>
    <div class="card mt-3" v-for="(question, index) in quiz.questions" :key="index">
        <div class="card-body">
            <h5 class="card-title">{{ question.title }}</h5>
            <div class="form-check" v-for="(option, index) in question.options" :key="index">
                <input class="form-check-input" type="radio" name="exampleRadios" id="exampleRadios1" value="option.id"
                    :checked="option.id == question.answer.option.id" disabled>
                <label class="form-check-label" for="exampleRadios1"
                    :class="{ highlight: option.id == question.answer.option.id }">
                    {{ option.id }}
                </label>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'QuizAnswer',
    data() {
        return {
            quiz: {}
        }
    },
    async created() {
        this.quiz = this.$store.state.quiz;

        for (var i = 0; i < this.quiz.questions.length; i++) {
            this.quiz.questions[i].answer = await this.getAnswer(this.quiz.questions[i]);
        }
    },
    methods: {
        async getAnswer(question) {
            const url = 'api/Questions/' + question.id + '/answer';
            const response = await fetch(url);
            const answer = await response.json();
            return answer;
        }
    }
}
</script>

<style scoped>
.highlight {
    color: green !important;
    font-weight: bold;
}
</style>