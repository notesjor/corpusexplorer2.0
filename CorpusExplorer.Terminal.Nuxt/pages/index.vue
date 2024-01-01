<script setup>
import HeadDescription from '~/components/HeadDescription.vue'


</script>

<template>
  <h1 class="text-3xl">{{ $t("start_Welcome") }}</h1>
  <p style="margin-bottom: 20px;">{{ $t("start_Welcome_Text") }}</p>

  <head-description :head="lbl_checklist_head" :description="lbl_checklist_description"></head-description>
  <div>
    <big-button leftIcon="mdi-numeric-1-circle" icon="mdi-form-textbox" style="margin:5px 10px 20px 0px"
      :label="lbl_check_projectName" />
    <nuxt-link to="/corpus">
      <big-button leftIcon="mdi-numeric-2-circle" icon="mdi-file-cabinet" style="margin:5px 10px 20px 0px"
        :label="lbl_check_loadCorpora" />
    </nuxt-link>
    <nuxt-link to="/snapshot">
      <big-button leftIcon="mdi-numeric-3-circle" icon="mdi-camera-outline" style="margin:5px 10px 20px 0px"
        :label="lbl_check_createSnapshot" />
    </nuxt-link>
    <big-button leftIcon="mdi-numeric-4-circle" icon="mdi-chart-box-outline" style="margin:5px 10px 20px 0px"
      :label="lbl_check_doWork" />
  </div>

  <head-description-info :head="lbl_firstSteps_head" :description="lbl_firstSteps_description" />

  <head-description :head="lbl_whatsNew_head" :description="lbl_whatsNew_description"></head-description>
  <div>
    <big-button icon="mdi-lock" style="margin:5px 10px 20px 0px" :label="lbl_info_dataprotection" />
    <big-button icon="mdi-share-variant" style="margin:5px 10px 20px 0px" :label="lbl_info_datashare" />
    <big-button icon="mdi-server-security" style="margin:5px 10px 20px 0px" :label="lbl_info_softwaredesign" />
    <big-button icon="mdi-chart-timeline-variant-shimmer" style="margin:5px 10px 20px 0px"
      :label="lbl_info_visualization" />
  </div>
</template>

<script>
export default {
  components: { HeadDescription },
  name: 'IndexPage',

  data() {
    return {
      lbl_check_projectName: this.$t('start_check_projectName'),
      lbl_check_loadCorpora: this.$t('start_check_loadCorpora'),
      lbl_check_createSnapshot: this.$t('start_check_createSnaprshot'),
      lbl_check_doWork: this.$t('start_check_doWork'),
      lbl_checklist_head: this.$t('start_Checklist'),
      lbl_checklist_description: this.$t('start_Checklist_Text'),
      lbl_firstSteps_head: this.$t('start_FirstSteps'),
      lbl_firstSteps_description: this.$t('start_FirstSteps_Text'),
      lbl_whatsNew_head: this.$t('start_WhatsNew'),
      lbl_whatsNew_description: this.$t('start_WhatsNew_Text'),
      lbl_info_dataprotection: this.$t('start_info_dataprotection'),
      lbl_info_datashare: this.$t('start_info_datashare'),
      lbl_info_softwaredesign: this.$t('start_info_softwaredesign'),
      lbl_info_visualization: this.$t('start_info_visualization'),
    }
  },
}
</script>
