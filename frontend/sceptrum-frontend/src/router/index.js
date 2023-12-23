import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import { useAuth } from '@/stores/auth.js'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/login',
      name: 'login',

      component: () => import('../views/LoginView.vue')
    },
    {
      path: '/produtos',
      name: 'produtos',

      component: () => import('../views/ProdutosView.vue'),
      meta: {
        auth:true
      }
    }
  ]
})

router.beforeEach(async (to, from, next) => {
  if(to.meta?.auth){
    const auth = useAuth();

    if(auth.token){
      const autenticado = await auth.verificarTokenValido();
      console.log("autenticado: " + autenticado);
      if(autenticado){
        next();
      } else {
        next({ name:'login' });
      }
    } else {
      next({ name:'login' });
    }
  } else {
    next();
  }
})

export default router
