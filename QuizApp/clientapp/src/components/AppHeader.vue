<template>
    <nav class="navbar navbar-dark bg-dark">
        <a class="navbar-brand" href="#">{{ Title }}</a>
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