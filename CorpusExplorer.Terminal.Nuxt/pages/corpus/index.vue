<template>
  <div>
    <head-description :head="lbl_corpora_Welcome" :description="lbl_corpora_Welcome_Text"></head-description>
    <div>
      <big-button icon="mdi-folder-zip-outline" style="margin:5px 10px 20px 0px" :label="lbl_corpora_reload" />
      <big-button icon="mdi-file-cog-outline" style="margin:5px 10px 20px 0px" :label="lbl_corpora_annotate"
        to="/corpus/annotate" />
      <big-button icon="mdi-archive-outline" style="margin:5px 10px 20px 0px" :label="lbl_corpora_import"
        to="/corpus/import" />
      <big-button icon="mdi-dots-horizontal-circle-outline" disabled style="margin:5px 10px 20px 0px"
        :label="lbl_commingsoon_btn" />
      <!--<big-button icon="mdi-web" style="margin:5px 10px 20px 0px;" :label="lbl_corpora_crawl" />-->
    </div>

    <head-description :head="lbl_corpora_info" :description="lbl_corpora_info_Text"></head-description>
    <big-4-numbers :count_corpora="count_corpora" :count_documents="count_documents" :count_layers="count_layers"
      :count_tokens="count_tokens"></big-4-numbers>

    <head-description-info :head="lbl_corpora_help" :description="lbl_corpora_help_Text" />

    <head-description :head="lbl_corpora_download" :description="lbl_corpora_download_Text"></head-description>
  </div>
</template>

<script>
import { useConnectionStore } from '/stores/connection'

export default {
  name: 'CorporaOverview',
  data() {
    return {
      lbl_corpora_reload: this.$t('corpora_reload'),
      lbl_corpora_annotate: this.$t('corpora_annotate'),
      lbl_corpora_import: this.$t('corpora_import'),
      lbl_corpora_crawl: this.$t('corpora_crawl'),
      lbl_corpora_Welcome: this.$t('corpora_Welcome'),
      lbl_corpora_Welcome_Text: this.$t('corpora_Welcome_Text'),
      lbl_corpora_info: this.$t('corpora_info'),
      lbl_corpora_info_Text: this.$t('corpora_info_Text'),
      lbl_corpora_help: this.$t('corpora_help'),
      lbl_corpora_help_Text: this.$t('corpora_help_Text'),
      lbl_corpora_download: this.$t('corpora_download'),
      lbl_corpora_download_Text: this.$t('corpora_download_Text'),
      lbl_commingsoon_btn: this.$t('commingson_btn'),

      count_corpora: 0,
      count_documents: 0,
      count_layers: 0,
      count_tokens: 0
    };
  },
  mounted() {
    this.refreshData();
  },
  methods: {
    refreshData() {
      const store = useConnectionStore();
      var api = store.connection.getProjectApi();

      var self = this;

      api.ProjectInfo(
        (data) => {
          self.count_corpora = data.Corpora;
          self.count_documents = data.Documents;
          self.count_layers = data.Layers;
          self.count_tokens = data.Tokens;
        },
        (error) => {
          console.log(error);
        })
    }
  }
}
</script>
