<template>
  <head-description :head="lbl_snapshot_Welcome" :description="lbl_snapshot_Welcome_Text"></head-description>

  <br />

  <p class="text-lg font-light">Basis-Funktionen</p>
  <div>
    <v-btn style="margin:5px 10px 20px 0px" prepend-icon="mdi-plus-circle-outline">
      Neu
      <v-menu location="bottom" activator="parent">
        <v-list>
          <v-list-item to="/snapshot/new/custom">
            <v-icon>mdi-plus-circle-outline</v-icon>
            Individuell
          </v-list-item>
          <v-divider></v-divider>
          <v-list-item to="/snapshot/new/autosplit">
            <v-icon>mdi-plus-circle-outline</v-icon>
            Autosplit
          </v-list-item>
          <v-list-item to="/snapshot/new/random">
            <v-icon>mdi-plus-circle-outline</v-icon>
            Zufällig
          </v-list-item>
        </v-list>
      </v-menu>
    </v-btn>
    <v-btn style="margin:5px 10px 20px 0px" prepend-icon="mdi-plus-circle-multiple-outline">
      Eingrenzen
      <v-menu location="bottom" activator="parent">
        <v-list>
          <v-list-item to="/snapshot/reduce/custom">
            <v-icon>mdi-plus-circle-multiple-outline</v-icon>
            Individuell
          </v-list-item>
          <v-divider></v-divider>
          <v-list-item to="/snapshot/reduce/autosplit">
            <v-icon>mdi-plus-circle-multiple-outline</v-icon>
            Autosplit
          </v-list-item>
          <v-list-item to="/snapshot/reduce/random">
            <v-icon>mdi-plus-circle-multiple-outline</v-icon>
            Zufällig
          </v-list-item>
        </v-list>
      </v-menu>
    </v-btn>
    <v-btn style="margin:5px 10px 20px 0px" prepend-icon="mdi-pencil">
      Bearbeiten
    </v-btn>
    <v-btn style="margin:5px 10px 20px 0px" prepend-icon="mdi-delete">
      Löschen
    </v-btn>
  </div>

  <p class="text-lg font-light">Mengenoperatoren</p>
  <div>
    <v-btn style="margin:5px 10px 20px 0px" prepend-icon="mdi-set-left-right" @click="snapshot_compare_diff">
      {{ lbl_snapshot_compare_diff }}
    </v-btn>
    <v-btn style="margin:5px 10px 20px 0px" prepend-icon="mdi-set-center" @click="snapshot_compare_overlap">
      {{ lbl_snapshot_compare_overlap }}
    </v-btn>
    <v-btn style="margin:5px 10px 20px 0px" prepend-icon="mdi-set-all" @click="snapshot_compare_join">
      {{ lbl_snapshot_compare_join }}
    </v-btn>
    <v-btn style="margin:5px 10px 20px 0px" prepend-icon="mdi-set-left" @click="snapshot_compare_joinLeft">
      {{ lbl_snapshot_compare_joinLeft }}
    </v-btn>
    <v-btn style="margin:5px 10px 20px 0px" prepend-icon="mdi-circle-box" @click="snapshot_compare_invert">
      {{ lbl_snapshot_compare_invert }}
    </v-btn>
  </div>

  <p class="text-lg font-light">Erweiterte Funktionen</p>
  <div>
    <v-btn style="margin:5px 10px 20px 0px" prepend-icon="mdi-toy-brick-search-outline"
      @click="snapshot_function_anticlone">
      AntiClone
    </v-btn>
    <v-btn style="margin:5px 10px 20px 0px" prepend-icon="mdi-import" @click="snapshot_function_import">
      Importieren
    </v-btn>
    <v-btn style="margin:5px 10px 20px 0px" prepend-icon="mdi-export" @click="snapshot_function_export">
      Exportieren
    </v-btn>
    <v-btn style="margin:5px 10px 20px 0px" prepend-icon="mdi-application-export" @click="snapshot_function_publish">
      Veröffentlichen
    </v-btn>
  </div>

  <br />

  <p class="text-lg font-light">Verfügbare Schnappschüsse im Projekt:</p>
  <v-list>
    <snapshot-item v-for="(child, i) in layerInfo" :key="i" :item="child"></snapshot-item>
  </v-list>

  <head-description :head="lbl_snapshot_info" :description="lbl_snapshot_info_Text"></head-description>
  <big-4-numbers :count_corpora="count_corpora" :count_documents="count_documents" :count_layers="count_layers"
    :count_tokens="count_tokens"></big-4-numbers>

  <head-description-info :head="lbl_snapshot_help" :description="lbl_snapshot_help_Text" />

  <DialogSelect ref="diag_select" :title="diag_select_titel" :message="diag_select_message" :icon="diag_select_icon"
    :items="diag_select_items" @result="diag_select_result"></DialogSelect>
</template>

<script>
import { useConnectionStore } from '/stores/connection'

import DialogSelect from "/components/Dialogs/DialogSelect.vue";

export default {
  name: 'SnapshotOverview',
  components: {
    DialogSelect,
  },

  data() {
    return {
      diag_select_titel: '',
      diag_select_message: '',
      diag_select_icon: null,
      diag_select_items: [],
      diag_select_result: null,

      lbl_snapshot_Welcome: this.$t('snapshot_Welcome'),
      lbl_snapshot_Welcome_Text: this.$t('snapshot_Welcome_Text'),
      lbl_snapshot_info: this.$t('snapshot_info'),
      lbl_snapshot_info_Text: this.$t('snapshot_info_Text'),
      lbl_snapshot_help: this.$t('snapshot_help'),
      lbl_snapshot_help_Text: this.$t('snapshot_help_Text'),

      lbl_snapshot_compare_diff: this.$t("snapshot_compare_diff"),
      lbl_snapshot_compare_diff_msg: this.$t("snapshot_compare_diff_msg"),
      lbl_snapshot_compare_overlap: this.$t("snapshot_compare_overlap"),
      lbl_snapshot_compare_overlap_msg: this.$t("snapshot_compare_overlap_msg"),
      lbl_snapshot_compare_join: this.$t("snapshot_compare_join"),
      lbl_snapshot_compare_join_msg: this.$t("snapshot_compare_join_msg"),
      lbl_snapshot_compare_joinLeft: this.$t("snapshot_compare_joinLeft"),
      lbl_snapshot_compare_joinLeft_msg: this.$t("snapshot_compare_joinLeft_msg"),
      lbl_snapshot_compare_invert: this.$t("snapshot_compare_invert"),
      lbl_snapshot_compare_invert_msg: this.$t("snapshot_compare_invert_msg"),

      lbl_commingsoon_btn: this.$t('commingson_btn'),

      count_corpora: 0,
      count_documents: 0,
      count_layers: 0,
      count_tokens: 0,

      layerInfo: [],
    };
  },

  mounted() {
    this.refreshData();
  },

  methods: {
    refreshData() {
      const store = useConnectionStore();
      var api = store.connection.getSelectionApi();

      var self = this;

      api.SnapshotInfo(
        (data) => {
          var active = data.find(x => x.IsActive);

          self.count_corpora = active.Size.Corpora;
          self.count_documents = active.Size.Documents;
          self.count_layers = active.Size.Layers;
          self.count_tokens = active.Size.Tokens;

          self.layerInfo = data;
        },
        (error) => {
          console.log(error);
        })
    },
    snapshot_compare_getData() {
      return this.layerInfo.filter(x => !x.IsActive);
    },
    snapshot_compare_diff() {
      this.$data.diag_select_icon = "mdi-set-left-right";
      this.$data.diag_select_items = this.snapshot_compare_getData();
      this.$data.diag_select_message = this.$data.lbl_snapshot_compare_diff_msg;
      this.$data.diag_select_titel = this.$data.lbl_snapshot_compare_diff;
      this.$data.diag_select_result = (x) => console.log(x);
      this.$refs.diag_select.open();
    },
    snapshot_compare_overlap() {
      this.$data.diag_select_icon = "mdi-set-center";
      this.$data.diag_select_items = this.snapshot_compare_getData();
      this.$data.diag_select_message = this.$data.lbl_snapshot_compare_overlap_msg;
      this.$data.diag_select_titel = this.$data.lbl_snapshot_compare_overlap;
      this.$refs.diag_select.open();
    },
    snapshot_compare_join() {
      this.$data.diag_select_icon = "mdi-set-all";
      this.$data.diag_select_items = this.snapshot_compare_getData();
      this.$data.diag_select_message = this.$data.lbl_snapshot_compare_join_msg;
      this.$data.diag_select_titel = this.$data.lbl_snapshot_compare_join;
      this.$refs.diag_select.open();
    },
    snapshot_compare_joinLeft() {
      this.$data.diag_select_icon = "mdi-set-left";
      this.$data.diag_select_items = this.snapshot_compare_getData();
      this.$data.diag_select_message = this.$data.lbl_snapshot_compare_joinLeft_msg;
      this.$data.diag_select_titel = this.$data.lbl_snapshot_compare_joinLeft;
      this.$refs.diag_select.open();
    },
    snapshot_compare_invert() {
      this.$data.diag_select_icon = "mdi-circle-box";
      this.$data.diag_select_items = this.snapshot_compare_getData();
      this.$data.diag_select_message = this.$data.lbl_snapshot_compare_invert_msg;
      this.$data.diag_select_titel = this.$data.lbl_snapshot_compare_invert;
      this.$refs.diag_select.open();
    },
    snapshot_function_anticlone() {

    },
    snapshot_function_import() {

    },
    snapshot_function_export() {

    },
    snapshot_function_publish() {

    },
  }
}
</script>

<style scope>
.v-btn__content {
  text-transform: none;
}
</style>