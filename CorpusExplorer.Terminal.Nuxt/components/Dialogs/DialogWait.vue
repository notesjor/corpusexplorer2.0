<template>
  <v-dialog v-model="dialog">
    <v-card style="margin: auto;" width="500">
      <div style="padding:20px">
        <div class="text-center">
          <v-progress-circular :size="50" color="primary" indeterminate></v-progress-circular>

          <v-progress-circular :width="3" color="red" indeterminate></v-progress-circular>

          <v-progress-circular :size="70" :width="7" color="purple" indeterminate></v-progress-circular>

          <v-progress-circular :width="3" color="green" indeterminate></v-progress-circular>

          <v-progress-circular :size="50" color="amber" indeterminate></v-progress-circular>
        </div>
        <div class="text-center" style="width:100%; margin-top:20px">
          {{ text }}
        </div>
      </div>
    </v-card>
  </v-dialog>
</template>

  <!--
    Verwendung
    import DialogWait from "/components/Dialogs/DialogWait.vue";

    export default {
      components:{
        DialogWait
      },

    <DialogWait ref="mydiag"></DialogWait>

    this.$refs.mydiag.open();
    ... do something ...
    this.$refs.mydiag.close();
  -->
  
<script>
export default {
  name: "DialogWait",
  data: () => ({
    dialog: false,
    text: null,
  }),
  props: {
    message: {
      type: String,
      default: null,
    },
  },
  methods: {
    open() {
      this.dialog = true;
    },
    close() {
      this.dialog = false;
    },
  },
  mounted() {
    this.text = (!this.message) ? this.$t('PleaseWait') : this.message;
    }
};
</script>
  