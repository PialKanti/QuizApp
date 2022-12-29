import { createApp } from 'vue'
import { createStore } from 'vuex'
import App from './App.vue'
import { createRouter, createWebHistory } from 'vue-router'
import AppDashboard from "./components/AppDashboard.vue"
import UserRegistration from "./components/UserRegistration.vue"
import UserLogin from "./components/UserLogin.vue"
import QuestionOptions from "./components/QuestionOptions.vue"
import OptionsForm from "./components/OptionsForm.vue"

const store = createStore({
    state() {
        return {
            isAuthenticated: false,
            loggedUserEmail: '',
            option: {}
        }
    },
    mutations: {
        setAuthentication(state, status) {
            state.isAuthenticated = status;
        },
        setLoggedUserEmail(state, email) {
            state.loggedUserEmail = email;
        },
        setOption(state, option) {
            state.option = option;
        }
    }
})

const routes = [
    { path: '/', component: AppDashboard, name: 'Dashboard' },
    { path: '/signup', component: UserRegistration, name: 'SignUp' },
    { path: '/login', component: UserLogin, name: 'Login' },
    { path: '/options', component: QuestionOptions, name: 'Option' },
    { path: '/options-form', component: OptionsForm, name: 'OptionForm', props: true }
]

const router = createRouter({
    history: createWebHistory(),
    routes,
})

router.beforeEach(async (to) => {
    if (to.name !== 'Login' && to.name !== 'SignUp') {
        store.commit("setAuthentication", localStorage.isAuthenticated);
        store.commit("setLoggedUserEmail", localStorage.loggedUserEmail);
    }

    if (!store.state.isAuthenticated && to.name !== 'Login' && to.name !== 'SignUp') {
        return { name: 'Login' }
    }

    return true;
})

const app = createApp(App)
app.use(router)
app.use(store)
app.mount('#app')
