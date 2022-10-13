<template>
<div>
  <div class="text-center">
    <v-progress-circular
      :size="50"
      color="primary"
      indeterminate
    ></v-progress-circular>

    <v-progress-circular
      :width="3"
      color="red"
      indeterminate
    ></v-progress-circular>

    <v-progress-circular
      :size="70"
      :width="7"
      color="purple"
      indeterminate
    ></v-progress-circular>

    <v-progress-circular
      :width="3"
      color="green"
      indeterminate
    ></v-progress-circular>

    <v-progress-circular
      :size="50"
      color="amber"
      indeterminate
    ></v-progress-circular>
  </div>
  <div>
    {{ this.Message }}
  </div>
  </div>
</template>

<script>
export default {
  name: "SpinnerComponent",
  props: ["Message"],
  data () {
      return {
      }
    }
};
</script>