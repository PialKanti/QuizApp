import { createApp } from 'vue'
import { createStore } from 'vuex'
import App from './App.vue'
import { createRouter, createWebHistory } from 'vue-router'
import AppDashboard from "./components/AppDashboard.vue"
import UserRegistration from "./components/UserRegistration.vue"
import UserLogin from "./components/UserLogin.vue"

const store = createStore({
    state() {
        return {
            isAuthenticated: false
        }
    },
    mutations: {
        setAuthentication(state, status) {
            state.isAuthenticated = status;
        }
    }
})

const routes = [
    { path: '/', component: AppDashboard, name: 'Dashboard' },
    { path: '/signup', component: UserRegistration, name: 'SignUp' },
    { path: '/login', component: UserLogin, name: 'Login' }
]

const router = createRouter({
    history: createWebHistory(),
    routes,
})

router.beforeEach(async (to) => {
    console.log(store.state.isAuthenticated);
    if (!store.state.isAuthenticated && to.name !== 'Login' && to.name !== 'SignUp') {
        return { name: 'Login' }
    }

    return true;
})

const app = createApp(App)
app.use(router)
app.use(store)
app.mount('#app')
