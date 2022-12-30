<template>
    <div class="card">
        <h2 class="card-header">{{ quiz.name }}</h2>
        <div class="card-body">
            <ExamQuestion :Question="currentQuestion" @radio-checked="onRadioChecked" class="mt-4"></ExamQuestion>
        </div>
        <div class="card-footer">
            <div class="row">
                <div class="col-md-5">
                    <button type="button" class="btn btn-outline-primary" @click="previousClicked"
                        :disabled="this.currentIndex <= 0">Previous</button>
                </div>
                <div class="col-md-2">
                    <p class="text-center">{{ currentIndex + 1 }} / {{ this.quiz.questions.length }}</p>
                </div>
                <div class="col-md-5">
                    <button type="button" class="btn btn-outline-primary next-button" @click="nextClicked"
                        :disabled="this.currentIndex >= (this.quiz.questions.length - 1)">Next</button>
                </div>
            </div>
        </div>
    </div>
    <button type="button" class="btn btn-danger btn-block mt-3" @click="onQuizFinished">End exam</button>
</template>

<script>
import ExamQuestion from "./ExamQuestion.vue"

export default {
    name: 'QuizExam',
    components: {
        ExamQuestion
    },
    data() {
        return {
            quiz: {},
            currentIndex: 0,
            currentQuestion: {}
        }
    },
    async created() {
        this.quiz = this.$store.state.quiz;
        for (let index = 0; index < this.quiz.questions.length; index++) {
            this.quiz.questions[index].answer = '';
        }
        this.updateCurrentQuestion(this.currentIndex);
    },
    methods: {
        previousClicked() {
            if (this.currentIndex > 0) {
                this.currentIndex--;
                this.updateCurrentQuestion(this.currentIndex);
            }
        },
        nextClicked() {
            if (this.currentIndex < this.quiz.questions.length) {
                this.currentIndex++;
                this.updateCurrentQuestion(this.currentIndex);
            }
        },
        updateCurrentQuestion(index) {
            this.currentQuestion = this.quiz.questions[index];
        },
        onRadioChecked(id) {
            this.quiz.questions[this.currentIndex].answer = id;
        },
        async onQuizFinished() {
            var data = [];
            for (let index = 0; index < this.quiz.questions.length; index++) {
                data.push({
                    'questionId': this.quiz.questions[index].id,
                    'answerId': this.quiz.questions[index].answer
                });
            }

            const jsonData = JSON.stringify({
                'answeredQuestions': data,
                'userEmail': this.$store.state.loggedUserEmail,
                'quizId': this.quiz.id
            });

            await fetch('api/Scores', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: jsonData
            });

            this.$router.push({ name: 'QuizDashboard' });
        }
    }
}
</script>

<style scoped>
.card {
    margin-top: 50px;
    height: 35rem;
}

.next-button {
    float: right;
}
</style>