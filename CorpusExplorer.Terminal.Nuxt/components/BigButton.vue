<template>
    <v-btn height="120" style="max-width: 145px; min-width:145px; padding: 10px;" :to="to">
      <!-- v-icon centered above text -->
      <v-icon size="16" style="position: absolute; right: 5px; top: 5px;"
        v-show="checked">mdi-check-circle-outline</v-icon>
      <v-icon size="16" style="position: absolute; left: 5px; top: 5px;">{{ leftIcon }}</v-icon>
      <v-icon size="64" style="position: absolute; left: 43px; top: 10px;">{{ icon }}</v-icon>
      <div
        style="position: absolute; left: 10px; top: 74px; text-transform: none; word-wrap: normal; font-weight: 400; width: 90%; text-align: center;"
        v-html="label"></div>
    </v-btn>
</template>

<script>
export default {
  name: 'BigButton',
  props: {
    icon: String,
    checked: {
      type: Boolean,
      default: false
    },
    leftIcon: String,
    label: String,
    to: String,
  },
}
</script>

<style scoped>
.v-btn__content {
  display: flex;
  flex-direction: column;
}</style>