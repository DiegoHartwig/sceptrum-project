<template>
<ul>
  <li><router-link :to="{name:'home'}">Home</router-link></li>
  <li><router-link :to="{name:'login'}">Login</router-link></li>
  <li><router-link :to="{name:'produtos'}">Produtos</router-link></li>
</ul>

<router-view/>

</template>

<script setup>

</script>

<style lang="scss" scoped>

</style>