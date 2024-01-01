<template>
  <div class="text-lg"><v-icon style="margin-top:-3px">{{ getNumber() }}</v-icon>
    <div style="display:inline; margin-left:5px">{{ head }}...</div>
  </div>
  <div class="text-md font-light" style="margin-left: 33px">{{ description }}</div>
</template>

<script>
export default {
  name: "HeadNumbred",
  props: {
    number: {
      type: Number,
      required: true
    },
    head: {
      type: String,
      required: true
    },
    description: {
      type: String,
      required: true
    }
  },
  methods: {
    getNumber() {
      return `mdi-numeric-${this.number}-circle`;
    }
  }
}
</script>