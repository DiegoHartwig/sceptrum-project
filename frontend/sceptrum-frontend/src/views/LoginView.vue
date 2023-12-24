<template>
  <q-app>
    <q-layout>
      <q-page-container>
        <q-page class="row flex-center">
          <q-card class="q-pa-md" style="width: 350px">
            <q-card-section class="q-pb-none">
              <div class="text-h6">Login</div>
            </q-card-section>

            <q-card-section>
              <q-form @submit.prevent="login">
                <q-input
                  filled
                  type="email"
                  label="E-mail"
                  placeholder="Digite seu e-mail"
                  v-model="dadosUsuario.email"
                ></q-input>

                <q-input
                  filled
                  type="password"
                  label="Senha"
                  placeholder="Digite sua senha"
                  v-model="dadosUsuario.password"
                ></q-input>

                <div class="q-mt-md">
                  <q-btn color="primary" type="submit" label="Login" />
                </div>
              </q-form>
            </q-card-section>
          </q-card>
        </q-page>
      </q-page-container>
    </q-layout>
  </q-app>
</template>

<script setup>
import { reactive } from 'vue';
import { useAuth } from '@/stores/auth.js';
import http from '@/services/http.js';
import router from '@/router'

const auth = useAuth();

const dadosUsuario = reactive({
  email: '',
  password: ''
});

async function login() {
  try {
    const { data } = await http.post('/api/Token/Login', dadosUsuario);
    auth.setToken(data.token);

    router.push('/produtos');
    
  } catch (error) {
    console.error(error?.response?.data);    
  }
}
</script>

<style lang="scss" scoped>

</style>
