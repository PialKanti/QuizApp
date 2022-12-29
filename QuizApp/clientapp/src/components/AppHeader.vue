<template>
    <nav class="navbar navbar-dark bg-dark">
        <a class="navbar-brand" href="#">{{ Title }}</a>
        <form class="form-inline" @submit.prevent="search" v-show="this.$store.state.isAuthenticated">
            <button class="btn btn-outline-danger my-2 my-sm-0" type="submit">Logout</button>
        </form>
    </nav>
</template>

<script>
export default {
    name: 'AppHeader',
    props: {
        Title: String
    }
}
</script>