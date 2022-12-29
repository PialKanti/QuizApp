<template>
    <AppHeader Title="Quiz App" />
    <div class="container">
        <router-view></router-view>
    </div>
</template>

<script>
import AppHeader from "./AppHeader.vue";

export default {
    name: "AppHome",
    components: {
        AppHeader
    }
}
</script>