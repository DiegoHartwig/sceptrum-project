import './assets/main.css'
import 'quasar/src/css/index.sass'

import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'

import { Quasar, Dialog, Notify } from 'quasar';
import quasarUserOptions from '@/quasar-user-options'

const app = createApp(App)

app.use(createPinia())
app.use(router)
app.use(Quasar, quasarUserOptions)

app.mount('#app')