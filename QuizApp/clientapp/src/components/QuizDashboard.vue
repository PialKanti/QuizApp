<template>
    <div class="card-deck mt-5" v-if="quizzes.length">
        <div class="card" v-for="(quiz, index) in quizzes" :key="index">
            <h5 class="card-header">{{ quiz.name }}</h5>
            <div class="card-body">
                <h6 class="card-title">Total Questions: {{ quiz.questions.length }}</h6>
                <p class="card-text">Time limit: {{ getTotalTimeInMinutes(quiz) }} minutes</p>
                <a href="#" class="btn btn-primary">Start Quiz</a>
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
        this.fetchQuizzes();
    },
    methods: {
        async fetchQuizzes() {
            const response = await fetch('api/Quizs');
            const data = await response.json();
            this.quizzes = data;
            console.log("fetching");
            console.log(data);
        },
        getTotalTimeInMinutes(quiz) {
            var totalTime = 0;
            quiz.questions.forEach(function (question) {
                totalTime += question.timeLimitInSeconds;
            });

            return totalTime / 60;
        }
    }
}
</script>

<style scoped>
.card-text {
    color: red;
}
</style>