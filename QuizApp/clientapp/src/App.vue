<template>
  <AppHome />
</template>

<script>
import AppHome from "./components/AppHome.vue"

export default {
  name: 'App',
  components: {
    AppHome
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

.container {
  background-color: #f8f8fa;
}
</style>
