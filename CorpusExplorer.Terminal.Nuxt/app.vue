<template>
  <NuxtLayout>
    <NuxtPage />
  </NuxtLayout>
</template>

<script>
import { useConnectionStore } from '/stores/connection'

export default {
  mounted() {
    var route = useRoute();

    var host = (!route.query.host) ? "localhost" : route.query.host;
    var port = (!route.query.port) ? "12712" : route.query.port;
    var overrideBasePath = (!route.query.overrideBasePath) ? null : route.query.overrideBasePath;
    var force = (!route.query.force) ? false : (route.query.force == "true");

    const store = useConnectionStore();

    if (store.connection == undefined || store.connection == null)
      store.create(host, port, overrideBasePath);
    else if (force)
      store.create(host, port, overrideBasePath);      
  },

  watch: {
    $route() {
      this.$nuxt.$router.go(); // FIX
    }
  }
}
</script>

<style>
.blackbox{
  border: 1px solid #000000;
  border-radius: 5px;
  padding: 10px;
}
</style>