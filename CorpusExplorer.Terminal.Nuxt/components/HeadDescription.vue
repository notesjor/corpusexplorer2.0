<template>
  <h2 class="text-2xl">{{ head }}</h2>
  <p>{{ description }}</p>
</template>

<script>
export default {
    name: 'HeadDescription',
    props: {
        head: String,
        description: String,
    },
}
</script>

<style>

</style>