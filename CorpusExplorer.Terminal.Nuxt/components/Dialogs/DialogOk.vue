<template>
    <v-dialog v-model="dialog" :max-width="width" style="z-index:100" @keydown.esc="ok">
      <v-card>
        <v-toolbar dark :color="color" dense flat>
          <v-toolbar-title class="white--text">{{ title }}</v-toolbar-title>
        </v-toolbar>
        <v-card-text v-show="!!message" class="pa-4">{{ message }}</v-card-text>
        <v-card-actions class="pt-0">
          <v-spacer></v-spacer>
          <v-btn color="primary" @click="ok">{{ yes }}</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </template>

  <!--
    Verwendung
    import DialogOk from "/components/Dialogs/DialogOk.vue";

    export default {
      components:{
        DialogOk
      },

    <DialogOk ref="mydiag" @result="diag_res" title="Überschrift" message="Meine Nachricht" color="#f00" width="600"></DialogOk>

    diag_res(){
      
    }

    this.$refs.mydiag.open();
  -->
  
  <script>
  export default {
    name: "DialogOk",
    data: () => ({      
      dialog: false,
    }),
    props:{
      width: {
        type: Number,
        default: 300
      },
      color: {
        type: String,
        default: "primary"
      },
      title: {
        type: String,
        default: "Title"
      },
      message: {
        type: String,
        default: "Message"
      },
      yes: {
        type: String,
        default: "Ok"
      },
    },
    methods: {
      open() {
        this.dialog = true;
      },
      ok() {
        this.dialog = false;
        this.$emit('result');
      }
    },
    emits:["result"]
  }
  </script>
  