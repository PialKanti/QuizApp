<template>
    <nav class="navbar navbar navbar-expand-lg navbar-dark bg-dark">
        <a class="navbar-brand" href="/">{{ Title }}</a>
        <div class="collapse navbar-collapse" id="navbarNav" v-if="this.$store.state.isAuthenticated">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="/quizs" id="navbarDropdown" role="button"
                        data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        Quiz
                    </a>
                    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                        <a class="dropdown-item" href="/quizs">All quizzes</a>
                        <a class="dropdown-item" href="/quiz-form">Create</a>
                    </div>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="/quizs" id="navbarDropdown" role="button"
                        data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        Questions
                    </a>
                    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                        <a class="dropdown-item" href="/question-form">Create</a>
                    </div>
                </li>
            </ul>
            <form class="form-inline my-2 my-lg-0" @submit.prevent="logout">
                <button class="btn btn-outline-danger my-2 my-sm-0" type="submit">Logout</button>
            </form>
        </div>
    </nav>
</template>

<script>
export default {
    name: 'AppHeader',
    props: {
        Title: String
    },
    methods: {
        async logout() {
            await fetch('api/Account/logout');
            this.$store.commit("setAuthentication", false);
            this.$store.commit("setLoggedUserEmail", '');
            localStorage.isAuthenticated = false;
            localStorage.loggedUserEmail = '';
            this.$router.push({ name: 'Login' });
        }
    }
}
</script>