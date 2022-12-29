import { createApp } from 'vue'
import App from './App.vue'
import { createRouter, createWebHistory } from 'vue-router'
import UserRegistration from "./components/UserRegistration.vue"
import UserLogin from "./components/UserLogin.vue"

const routes = [
    { path: '/signup', component: UserRegistration },
    { path: '/login', component: UserLogin }
]

const router = createRouter({
    history: createWebHistory(),
    routes,
})

const app = createApp(App)
app.use(router)
app.mount('#app')
