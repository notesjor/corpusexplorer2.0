<template>
    <v-dialog v-model="dialog" :max-width="width" style="z-index:100" @keydown.esc="cancel">
      <v-card>
        <v-toolbar dark :color="color" dense flat>
          <v-toolbar-title class="white--text">{{ title }}</v-toolbar-title>
        </v-toolbar>
        <v-card-text v-show="!!message" class="pa-4">{{ message }}</v-card-text>
        <v-card-actions class="pt-0">
          <v-spacer></v-spacer>
          <v-btn color="primary" @click.="agree">{{ yes }}</v-btn>
          <v-btn text @click="cancel">{{ no }}</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </template>

  <!--
    Verwendung
    import DialogYesNo from "/components/Dialogs/DialogYesNo.vue";

    export default {
      components:{
        DialogYesNo
      },

    <DialogYesNo ref="mydiag" @result="diag_res" title="Überschrift" message="Meine Nachricht" color="#f00" width="600"></DialogYesNo>

    diag_res(res){
      console.log(res);
    }

    this.$refs.mydiag.open();
  -->
  
  <script>
  export default {
    name: "DialogYesNo",
    data: () => ({      
      dialog: false,
    }),
    props:{
      width: {
        type: String,
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
        default: null
      },
      no: {
        type: String,
        default: null
      },
    },
    methods: {
      open() {
        this.dialog = true;
      },
      agree() {
        this.dialog = false;
        this.$emit('result', true);
      },
      cancel() {
        this.dialog = false;
        this.$emit('result', false);
      }
    },
    emits:["result"],
    mounted() {
      if(!this.yes) this.yes = this.$t('Accept');
      if(!this.no) this.no = this.$t('Reject');
    }
  }
  </script>
  