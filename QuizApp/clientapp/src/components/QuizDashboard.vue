<template>
    <div class="mt-5" v-if="quizzes.length">
        <div class="card mb-4" v-for="(quiz, index) in quizzes" :key="index">
            <h5 class="card-header">{{ quiz.name }}</h5>
            <div class="card-body">
                <h6 class="card-title">Total Questions: {{ quiz.questions.length }}</h6>
                <p class="card-text">Time limit: {{ getTotalTimeInMinutes(quiz) }} minutes</p>
                <div class="btn-group" role="group" aria-label="Basic example">
                    <button class="btn btn-primary" @click="startQuiz(quiz)">Start Quiz</button>
                    <button class="btn btn-success" @click="seeAnswers(quiz)">See answers</button>
                    <button class="btn btn-secondary" @click="seeScores(quiz)">Score list</button>
                </div>
            </div>
        </div>
    </div>
    <div v-else>
        <p class="text-muted no-items-text">No {{ Type }} quizzes.</p>
    </div>
</template>

<script>
export default {
    name: 'QuizDashboard',
    data() {
        return {
            quizzes: []
        };
    },
    async created() {
        this.$store.commit('setQuiz', {});
        this.$store.commit('setQuizId', '');
        this.fetchQuizzes();
    },
    methods: {
        async fetchQuizzes() {
            const response = await fetch('api/Quizs');
            const data = await response.json();
            this.quizzes = data;
        },
        getTotalTimeInMinutes(quiz) {
            var totalTime = 0;
            quiz.questions.forEach(function (question) {
                totalTime += question.timeLimitInSeconds;
            });

            return totalTime / 60;
        },
        startQuiz(quiz) {
            this.$store.commit('setQuiz', quiz);
            this.$router.push({ name: 'QuizExam' });
        },
        seeAnswers(quiz) {
            this.$store.commit('setQuiz', quiz);
            this.$router.push({ name: 'QuizAnswer' });
        },
        seeScores(quiz) {
            this.$store.commit('setQuizId', quiz.id);
            this.$router.push({ name: 'QuizScoreList' });
        }
    }
}
</script>

<style scoped>
.card-text {
    color: red;
}
</style>