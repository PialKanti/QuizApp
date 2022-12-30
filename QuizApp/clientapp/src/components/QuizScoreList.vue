<template>
    <div class="row mt-5">
        <div class="col-12">
            <p v-if="isListEmpty" class="text-muted no-items-text mt-4">No participants took this quiz</p>
            <table class="table table-bordered mt-3" v-else>
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">User email</th>
                        <th scope="col">Total Score</th>
                        <th scope="col">Earned Score</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(item, index) in scores" :key="index">
                        <td>{{ index + 1 }}</td>
                        <td>{{ item.user.email }}</td>
                        <td>{{ item.totalScore }}</td>
                        <td>{{ item.earnedScore }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>
<script>
export default {
    name: 'QuizScoreList',
    data() {
        return {
            scores: [],
            quizId: '',
            isListEmpty: true
        }
    },
    async created() {
        this.quizId = this.$store.state.quizId;
        console.log(this.quizId);
        this.refreshUI();
    },
    methods: {
        async fetchScores() {
            const url = 'api/Scores?quizId=' + this.quizId;
            const response = await fetch(url);
            const data = await response.json();
            return data;
        },
        async refreshUI() {
            //this.$store.commit('setOption', null);
            this.scores = await this.fetchScores();
            console.log(this.scores);
            this.isListEmpty = this.scores.length == 0;
        }
    }
}
</script>
<style lang="">
    
</style>