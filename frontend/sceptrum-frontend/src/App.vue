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

const auth = useAuth();

function logout(){
  auth.clear();
}

</script>

<style lang="scss" scoped>

</style>