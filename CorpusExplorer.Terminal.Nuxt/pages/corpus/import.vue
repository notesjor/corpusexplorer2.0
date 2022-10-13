<template>
  <v-row>
    <v-col class="text-center">
      <v-stepper v-model="CurrentStep" vertical>
        <v-stepper-step :complete="CurrentStep > 1" step="1">
          Dateiformat auswählen...
          <small
            >Abhängig von der Auswahl können Sie dann ein oder mehrere Dateien
            in Schritt 2 auswählen.</small
          >
        </v-stepper-step>
        <v-stepper-content step="1">
          <v-combobox
            v-model="FormatSelected"
            :items="Formats"
            outlined
            label="Ausgewähltes Dateiformat für Import:"
            style="margin-top:10px"
          ></v-combobox>
          <v-btn
            color="primary"
            @click="CurrentStep = 2"
            :disabled="this.FormatSelected === null"
          >
            Weiter
          </v-btn>
          <v-btn text @click="diag_abort"> Abbrechen </v-btn>
        </v-stepper-content>

        <v-stepper-step :complete="CurrentStep > 2" step="2">
          Dateien auswählen...
          <small
            >Wählen Sie eine oder mehrere Dateien für den Import aus.</small
          >
        </v-stepper-step>
        <v-stepper-content step="2">
          <FileManagerLoadStandalone
            :Filter="
              this.FormatSelected === null
                ? ''
                : this.FormatSelected.value.Extensions
            "
            @LoadFiles="LoadFiles"
          ></FileManagerLoadStandalone>
          <v-btn text @click="CurrentStep = 1"> Zurück </v-btn>
          <v-btn
            color="primary"
            @click="ImportCorpus"
            :disabled="FilesSelected.length === 0"
          >
            Fertig
          </v-btn>
          <v-btn text @click="diag_abort"> Abbrechen </v-btn>
        </v-stepper-content>

        <v-stepper-step
          :complete="CurrentStep > 3"
          :step="
            this.FormatSelected.text ==
            'CorpusExplorer v6 (*.cec6, *.cec6.lz4, *.cec6.gz)'
              ? 0
              : 3
          "
          v-if="
            this.FormatSelected.text !=
            'CorpusExplorer v6 (*.cec6, *.cec6.lz4, *.cec6.gz)'
          "
        >
          Korpusnamen festlegen
          <small
            >Vergeben Sie einen eindeutigen Korpusnamen. Ein zuvor erstelltes
            Korpus können Sie später direkt erneut laden.</small
          >
        </v-stepper-step>
        <v-stepper-content
          :step="
            this.FormatSelected.text ==
            'CorpusExplorer v6 (*.cec6, *.cec6.lz4, *.cec6.gz)'
              ? 0
              : 3
          "
          v-if="this.FormatSelected.text != 'CorpusExplorer v6 (*.cec6, *.cec6.lz4, *.cec6.gz)'"
        >
          <v-text-field
            label="Bitte tragen Sie hier einen eindeutigen Korpusnamen ein..."
            v-model="CorpusName"
          />
          <v-btn text @click="CurrentStep = 2"> Zurück </v-btn>
          <v-btn
            color="primary"
            @click="ImportCorpus"
            :disabled="CorpusName.length < 1"
          >
            Fertig
          </v-btn>
          <v-btn text @click="diag_abort"> Abbrechen </v-btn>
        </v-stepper-content>
      </v-stepper>
    </v-col>
    <DialogYesNo ref="diag_abort" yes="Ja" no="Nein" @result="diag_abort_yes" title="Abbrechen?" message="Möchten Sie diesen Vorgang wirklich abbrechen?" width="600"></DialogYesNo>
    <DialogWait res="diag_wait"></DialogWait>
  </v-row>
</template>

<script>
import DialogYesNo from "/components/Dialogs/DialogYesNo.vue";
import DialogWait from "/components/Dialogs/DialogWait.vue";

export default {
  name: "CorpusImportPage",
  components:{
    DialogYesNo,
    DialogWait
  },
  data() {
    return {
      CurrentStep: 1,
      Formats: [],
      FormatSelected: {
        text: "CorpusExplorer v6 (*.cec6, *.cec6.lz4, *.cec6.gz)",
        value: {
          Id: "Cec6",
          DisplayName: "CorpusExplorer v6 (*.cec6, *.cec6.lz4, *.cec6.gz)",
          Extensions: [".cec6", ".cec6.gz", ".cec6.lz4"],
        },
      },
      FilesSelected: [],
      CorpusName: "",
      EnableOverlay: false,
    };
  },
  methods: {
    async updateFormatInfo() {
      var data = await this.$axios.$get("http://localhost:12712/corpus/import");
      this.Formats = data.map((x) => ({ text: x.DisplayName, value: x }));
    },
    LoadFiles(files) {
      this.FilesSelected = files;
    },
    diag_abort2(){
      console.log(this.$refs.diag_abort);
    },
    diag_abort(){
      console.log(this.$refs.diag_abort);
      this.$refs.diag_abort.open();
    },
    diag_abort_yes(res){
      if(res)
        this.$router.push("/corpus/overview");
    },
    ImportCorpus(isVisible, entry) {
      if (this.CurrentStep == 2) {
        if (
          this.FormatSelected.text !=
          "CorpusExplorer v6 (*.cec6, *.cec6.lz4, *.cec6.gz)"
        ) {
          this.CurrentStep = 3;
          return;
        }
      }
      this.EnableOverlay = true;

      var data = {
        Format: this.FormatSelected.value.Id,
        Paths: this.FilesSelected.map(x=>x.Path),
      };

      if (
        this.CorpusName != undefined &&
        this.CorpusName != null &&
        this.CorpusName.length > 0
      )
        data["OutputPath"] = this.CorpusName + ".cec6.lz4";

      var router = this.$router; // wichtig
      this.$axios
        .post("http://localhost:12712/corpus/import", data)
        .then(function (response) {
          if(response.status === 200)
            router.push('/corpus/overview');
        })
        .catch((error) => {
          console.log(error)
        });
    },
  },
  mounted() {
    this.updateFormatInfo();
  },
};
</script>
