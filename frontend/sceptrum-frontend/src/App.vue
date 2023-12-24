<template>
<ul>
  <li>
    <router-link :to="{name:'home'}">Home</router-link>
  </li>  
  <li>
    <router-link :to="{name:'produtos'}">Produtos</router-link>
  </li>  
  <li v-if="!auth.estaAutenticado()">
    <router-link :to="{name:'login'}">Login</router-link>
  </li>
  <li v-else>
      <button @click="logout">Logout</button>
  </li>
</ul>

<router-view/>

</template>

<script setup>

import {useAuth} from '@/stores/auth.js';
import {useRouter} from 'vue-router';

const auth = useAuth();
const router = useRouter();

function logout(){
  auth.clear();
  router.push({name:'login'})
}

</script>

<style lang="scss" scoped>

</style>