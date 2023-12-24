<template>
<div>
  <h2>Login</h2>

  <form @submit.prevent="login">
    <input
      type="text"
      placeholder="Login"
      v-model="dadosUsuario.email">
  
    <input 
      type="password" 
      placeholder="Senha"
      v-model="dadosUsuario.password">
  
    <button type="submit">
      Login
    </button>
  </form>
</div>

</template>

<script setup>

import http from '@/services/http.js';
import {reactive} from 'vue';
import {useAuth} from '@/stores/auth.js';

const auth = useAuth();

const dadosUsuario = reactive({
  email:'',
  password:''
})

async function login(){
  try {
    const { data } = await http.post('/api/Token/Login', dadosUsuario);
    auth.setToken(data.token);
  } catch (error) {
    console.log(error?.response?.data);
  }
}

</script>

<style lang="scss" scoped>

</style>