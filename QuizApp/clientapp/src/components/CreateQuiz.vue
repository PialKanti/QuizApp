<template>
    <h4 class="text-uppercase text-center mt-4 mb-5">Create Quiz</h4>
    <form ref="quizForm anyClass" @submit.prevent="submitForm">
        <div class="form-outline mb-4">
            <input type="text" id="name" class="form-control" v-model="name" placeholder="Quiz name" />
        </div>
        <p class="font-weight-bold">Select questions for this quiz</p>
        <div class="row" v-for="(item, index) in questions" :key="index">
            <div class="col-md-1">
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" :value="item.id" v-model="selectedQuestionIds">
                </div>
            </div>
            <div class="col-md-11">
                <div class="card mb-3">
                    <div class="card-body">
                        <h6 class="card-title">{{ item.title }}</h6>
                        <h6 class="card-subtitle mb-2 text-muted">Time limit: {{
        convertToMinutes(item.timeLimitInSeconds)
                            }}
                            minutes</h6>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <button type="submit" class="btn btn-primary">Create</button>
        </div>
    </form>
</template>

<script>
export default {
    name: "CreateQuiz",
    data() {
        return {
            name: '',
            questions: [],
            selectedQuestionIds: []
        };
    },
    async created() {
        this.fetchQuestions();
    },
    methods: {
        async fetchQuestions() {
            const response = await fetch('api/Questions');
            const data = await response.json();
            this.questions = data;
        },
        convertToMinutes(second) {
            return second / 60;
        },
        async submitForm() {
            const data = JSON.stringify({
                name: this.name,
                selectedQuestionIds: this.selectedQuestionIds
            });

            await fetch('api/Quizs', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: data
            });

            this.clearFormData();
            this.$router.push({ name: 'QuizDashboard' });
        },
        clearFormData() {
            this.name = '',
                this.selectedQuestionIds = []
        }
    }
}
</script>

<style scoped>
.form-check {
    margin-top: 30px;
    margin-left: 10px;
}

.anyClass {
    height: 150px;
    overflow-y: scroll;
}
</style>