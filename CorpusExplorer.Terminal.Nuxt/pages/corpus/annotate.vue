<template>
  <v-row>
    <v-col class="text-center">
      <v-stepper v-model="CurrentStep" vertical>
        <v-stepper-step :complete="CurrentStep > 1" step="1">
          Dateiformat auswählen...
          <small>
            Geben Sie an, aus welcher Quelle die Rohdaten für das Korpus stammen.
            Sie können nur Dateien in Schritt 2 auswählen, die diesem Format entsprechen.
          </small>
        </v-stepper-step>
        <v-stepper-content step="1">
          <v-combobox
            v-model="FormatSelected"
            :items="Formats"
            outlined
            label="Ausgewähltes Dateiformat für die Annotation:"
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
            @click="CurrentStep = 3"
            :disabled="FilesSelected.length === 0"
          >
            Weiter
          </v-btn>
          <v-btn text @click="diag_abort"> Abbrechen </v-btn>
        </v-stepper-content>

        <v-stepper-step
          :complete="CurrentStep > 3"
          :step="3"
        >
          Tagger konfigurieren
          <small
            >Wählen Sie einen Tagger und die gewünschten Einstellungen
            zur automatischen Annotation des Korpusmaterials.</small
          >
        </v-stepper-step>
        <v-stepper-content
          :step="3"
        >
          <v-combobox
            v-model="TaggerSelected"
            :items="Taggers"
            outlined
            label="Ausgewählter Tagger:"
            style="margin-top:10px"
          ></v-combobox>
          <v-combobox
            v-model="TaggerLanguage"
            :items="TaggerSelected.value.LanguagesAvailable"
            outlined
            label="Sprache (abhängig vom ausgewählten Tagger):"
            style="margin-top:5px"
          ></v-combobox>
          <v-btn text @click="CurrentStep = 2"> Zurück </v-btn>
          <v-btn
            color="primary"
            @click="CurrentStep = 4"
            :disabled="TaggerSelected === undefined || TaggerSelected.value.LanguagesAvailable === undefined"
          >
            Weiter
          </v-btn>
          <v-btn text @click="diag_abort"> Abbrechen </v-btn>
        </v-stepper-content>

        <v-stepper-step
          :complete="CurrentStep > 4"
          :step="4"
        >
          Korpusnamen festlegen
          <small
            >Vergeben Sie einen eindeutigen Korpusnamen. Ein zuvor erstelltes
            Korpus können Sie später direkt erneut laden.</small
          >
        </v-stepper-step>
        <v-stepper-content
          :step="4"
        >
          <v-text-field
            label="Bitte tragen Sie hier einen eindeutigen Korpusnamen ein..."
            v-model="CorpusName"
          />
          <v-btn text @click="CurrentStep = 3"> Zurück </v-btn>
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
  </v-row>
</template>

<script>
import DialogYesNo from "/components/Dialogs/DialogYesNo.vue";

export default {
  name: 'CorpusAnnotatePage',
  components:{
    DialogYesNo
  },
  data() {
    return {
      CurrentStep: 1,
      Formats: [],
      FormatSelected: {
        text: "Plain-TXT (*.txt)",
        value: {
			    "Id": "Txt",
			    "DisplayName": "Plain-TXT (*.txt)",
			    "Extensions": [
				    ".txt"
			    ]
		    },
      },
      Taggers: [],
      TaggerSelected: {
			  text: "TreeTagger (ohne Phrasen / höhere Performance)",
        value: {
          "Id": "SimpleTree",
			    "DisplayName": "TreeTagger (ohne Phrasen / höhere Performance)",
			    "LanguagesAvailable": [
			    	"Deutsch",
			    	"Englisch",
			    	"Französisch",
			    	"Italienisch",
			    	"Niederländisch",
			    	"Spanisch"
			    ]
        }
		  },
      TaggerLanguage: "Deutsch",
      FilesSelected: [],
      CorpusName: "",
      EnableOverlay: false,
    };
  },
  methods: {
    async updateFormatInfo() {
      var data = await this.$axios.$get("http://localhost:12712/corpus/annotate");
      this.Formats = data.Scraper.map((x) => ({ text: x.DisplayName, value: x }));
      this.Taggers = data.Tagger.map((x) => ({ text: x.DisplayName, value: x }));
    },
    ImportCorpus(isVisible, entry) {
    },
    LoadFiles(files) {
      this.FilesSelected = files;
    },
    diag_abort(){
      this.$refs.diag_abort.open();
    },
    diag_abort_yes(res){
      if(res)
        this.$router.push("/corpus/overview");
    }
  },
  mounted() {
    this.updateFormatInfo();
  },
}
</script>
