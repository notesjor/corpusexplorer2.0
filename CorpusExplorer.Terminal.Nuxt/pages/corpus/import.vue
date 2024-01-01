<template>
  <div>
    <v-row>
      <v-col>
        <HeadNumbred number="1" :head="lbl_select_fileFormat" :description="lbl_corpus_import_fileFormat"></HeadNumbred>
        <v-combobox v-model="FormatSelected" :items="Formats" :label="lbl_select_FileFormat_Label"
          style="margin-top:10px">
        </v-combobox>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <HeadNumbred number="2" :head="lbl_select_files" :description="lbl_corpus_import_selectFiles" />
        <FileManagerLoadStandalone :Filter="FormatSelected.value.Extensions" @LoadFiles="LoadFiles" />
      </v-col>
    </v-row>
    <v-row v-show="showCorpusName">
      <v-col>
        <HeadNumbred number="3" :head="lbl_corpus_import_create_head" :description="lbl_corpus_import_create_Label" />
        <v-text-field v-model="CorpusName" :label="lbl_corpus_import_create_empty" outlined style=""></v-text-field>
      </v-col>
    </v-row>
    <v-row>
      <v-col>
        <div class="blackbox text-center">
          <div style="margin:5px 0px 10px 0px" class="font-light" v-show="!allowComplete">
            {{ lbl_corpus_import_hint }}
          </div>
          <v-btn color="primary" @click="ImportCorpus" :disabled="!allowComplete">
            {{ lbl_complete }}
          </v-btn>
        </div>
      </v-col>
    </v-row>

    <DialogWait ref="wait"></DialogWait>
  </div>
</template>

<script>
import DialogWait from "/components/Dialogs/DialogWait.vue";
import { useConnectionStore } from '/stores/connection'

export default {
  name: "CorpusImportPage",

  components: {
    DialogWait,
  },

  data() {
    return {
      api: null,

      Formats: [],
      FormatSelected: {
        title: "CorpusExplorer v6 (*.cec6, *.cec6.lz4, *.cec6.gz)",
        value: {
          Id: "Cec6",
          DisplayName: "CorpusExplorer v6 (*.cec6, *.cec6.lz4, *.cec6.gz)",
          Extensions: [".cec6", ".cec6.gz", ".cec6.lz4"],
        },
      },
      FilesSelected: [],
      CorpusName: "",

      lbl_select_fileFormat: this.$t('select_fileFormat'),
      lbl_select_FileFormat_Label: this.$t('select_FileFormat_Label'),
      lbl_select_files: this.$t('select_files'),
      lbl_corpus_import_fileFormat: this.$t('corpus_import_fileFormat'),
      lbl_corpus_import_selectFiles: this.$t('corpus_import_selectFiles'),
      lbl_corpus_import_create_head: this.$t('corpus_import_create_head'),
      lbl_corpus_import_create_Label: this.$t('corpus_import_create_Label'),
      lbl_corpus_import_create_empty: this.$t('corpus_import_create_empty'),
      lbl_corpus_import_create_empty: this.$t('corpus_import_create_empty'),
      lbl_corpus_import_hint: this.$t('corpus_import_hint'),
      lbl_complete: this.$t('complete'),
    }
  },

  mounted() {
    const store = useConnectionStore();
    this.api = store.connection.getCorpusApi();

    this.updateFormatInfo();
  },

  methods: {
    async updateFormatInfo() {
      var self = this;

      this.api.CorpusImportInfo(
        data => {
          self.Formats = data.map((x) => ({ title: x.DisplayName, value: x }))
          console.log(self.Formats);
        },
        error => console.log(error)
      );
    },
    LoadFiles(files) {
      this.FilesSelected = files;
    },
    ImportCorpus() {
      var wait = this.$refs.wait;
      wait.open();

      var data = {
        Format: this.FormatSelected.value.Id,
        Paths: [...this.FilesSelected],
      };

      if (
        this.CorpusName != undefined &&
        this.CorpusName != null &&
        this.CorpusName.length > 0
      )
        data["OutputPath"] = this.CorpusName + ".cec6";

      this.api.CorpusImport(data, (d) => {
        console.log(d);
        wait.close();
        this.$router.push('/corpus');
      }, (error) => {
        console.log(error);
        wait.close();
      });
    },
  },
  computed: {
    showCorpusName() {
      return this.FormatSelected.value.Id != "Cec6";
    },
    allowComplete() {
      return this.FilesSelected.length > 0;
    }
  },
};
</script>
