<template>
  <div class="q-pa-md">
    <div class="q-gutter-md">

      <!-- Home -->
      <q-btn flat :to="{name:'home'}" color="secondary" label="Home"/>

      <!-- Produtos -->
      <q-btn flat :to="{name:'produtos'}" color="primary" label="Produtos"/> 
      
      <template v-if="!auth.estaAutenticado()">
        <!-- Login -->
        <q-btn flat :to="{name:'login'}" color="deep-orange" label="Login"/>
      </template>
      <template v-else>
        <!-- Logout -->
        <q-btn flat @click="logout" color="amber" label="Logout"/>  
      </template>        

    </div>
  </div>
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