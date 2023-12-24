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

router.beforeEach(async (para, de, proximo) => {
  const precisaAutenticacao = para.meta?.auth;
  const autenticacao = useAuth();

  const redirecionarParaLogin = () => proximo({ name: 'login' });
  const prosseguir = () => proximo();

  if (!precisaAutenticacao) return prosseguir();

  if (!autenticacao.token) return redirecionarParaLogin();

  const estaAutenticado = await autenticacao.verificarTokenValido();
  return estaAutenticado ? prosseguir() : redirecionarParaLogin();
});

export default router
