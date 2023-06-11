<template>
    <Navigation />
    <router-view />
</template>

<script>
    import BaseTemplate from './components/BaseTemplate.vue'
    import Navigation from './components/Navigation.vue'

export default {
  name: 'App',
    components: {
      BaseTemplate,
      Navigation
  }
    }
</script>

<style>
    @import './assets/css/styles.css';
</style>
