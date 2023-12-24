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
                 :error="!!errors.email"
                 :error-message="errors.email"
                 ></q-input>

                <q-input 
                 filled 
                 type="password" 
                 label="Senha" 
                 placeholder="Digite sua senha"
                 v-model="dadosUsuario.password"
                 :error="!!errors.password"
                 :error-message="errors.password"
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
import { reactive, ref, watch } from 'vue';
import { useAuth } from '@/stores/auth.js';
import http from '@/services/http.js';
import router from '@/router';
import { nextTick } from 'vue';

const auth = useAuth();

const dadosUsuario = reactive({
  email: '',
  password: ''
});

const errors = reactive({
  email: '',
  password: ''
});

watch(() => dadosUsuario.email, validarEmail);
watch(() => dadosUsuario.password, validarPassword);

async function login() {
  validarEmail();
  validarPassword();

  if(errors.email || errors.password){
    console.log('Atenção, corrija os campos incorretos.');
    return;
  }

  try {
    const { data } = await http.post('/api/Token/Login', dadosUsuario);
    auth.setToken(data.token);
    
    // Em caso de sucesso redireciona para a página de produtos
    router.push('/produtos');

  } catch (error) {
      errors.email = 'E-mail ou senha inválidos.';
      errors.password = 'E-mail ou senha inválidos.';    
  }
}

function validarEmail() {
  console.log("validando e-mail");
  if (!dadosUsuario.email) {
    nextTick(() => {
      errors.email = 'O e-mail é obrigatório.';
    });
    
  } else if (!/\S+@\S+\.\S+/.test(dadosUsuario.email)) {
    nextTick(() => {
      errors.email = 'Por favor, insira um e-mail válido.';
    });

  } else {
    errors.email = '';
  }
}

function validarPassword() {
  console.log("validando senha");
  if (!dadosUsuario.password) {
    errors.password = 'A senha é obrigatória.';
  } else if (dadosUsuario.password.length < 6) {
    errors.password = 'A senha deve ter pelo menos 6 caracteres.';
  } else {
    errors.password = '';
  }
}

</script>

<style scoped>
  .q-field__messages {
    color: red !important;
  }
</style>

