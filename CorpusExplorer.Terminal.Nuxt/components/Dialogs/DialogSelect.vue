<template>
    <v-dialog v-model="dialog" :max-width="width" style="z-index:100" @keydown.esc="ok">
      <v-card>
        <v-toolbar dark :color="color" dense flat>
          <v-toolbar-title class="white--text"><v-icon v-if="!icon">{{ icon }}</v-icon>{{ title }}</v-toolbar-title>
        </v-toolbar>
        <v-card-text v-show="!!message" class="pa-4">{{ message }}</v-card-text>
        <v-combobox style="margin:5px" variant="outlined" label="Auswahl:" :items="items" v-model="res" :item-title="key" :item-value="value"></v-combobox>
        <v-card-actions class="pt-0">
          <v-spacer></v-spacer>
          <v-btn color="primary" @click="ok">{{ yes }}</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </template>

  <!--
    Verwendung
    import DialogSelect from "/components/Dialogs/DialogSelect.vue";

    export default {
      components:{
        DialogSelect
      },

    <DialogOk ref="mydiag" :items="[1, 2, 3]" @result="diag_res" title="Überschrift" message="Meine Nachricht" color="#f00" width="600"></DialogYesNo>

    diag_res(){
      
    }

    this.$refs.mydiag.open();
  -->
  
  <script>
  export default {
    name: "DialogSelect",
    data: () => ({      
      dialog: false,
      res: null
    }),
    props:{
      width: {
        type: Number,
        default: 300
      },
      color: {
        type: String,
        default: null
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
      items: {
        type: Array,
        default: []
      },
      key: {
        type: String,
        default: "Name"
      },
      value: {
        type: String,
        default: "Guid"
      },
    },
    methods: {
      open() {
        this.dialog = true;
      },
      ok() {
        this.dialog = false;
        this.$emit('result', this.$data.res);
      }
    },
    emits:["result"]
  }
  </script>
  