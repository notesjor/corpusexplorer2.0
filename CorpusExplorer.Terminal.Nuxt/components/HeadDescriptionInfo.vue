<template>
  <head-description :head="head" :description="description"></head-description>
  <div>
    <big-button icon="mdi-television-classic" style="margin:5px 10px 20px 0px" :label="lbl_hdi_video" />
    <big-button icon="mdi-gesture-double-tap" style="margin:5px 10px 20px 0px" :label="lbl_hdi_exercises" />
    <big-button icon="mdi-book-open-variant" style="margin:5px 10px 20px 0px" :label="lbl_hdi_manual" />
    <big-button icon="mdi-card-account-mail-outline" style="margin:5px 10px 20px 0px" :label="lbl_hdi_contact"
      @click="dialog_contact = true" />
  </div>

  <v-dialog v-model="dialog_contact" max-width="500">
    <v-card>
      <v-card-title>
        <span class="headline" v-html="lbl_hdi_contact.replace('<br/>', ' ').replace('<br />',' ')"></span>
      </v-card-title>
      <v-card-text>
        <p>Manchmal braucht es den persönlichen Kotakt, um Probleme zu lösen, Ideen zu besprechen oder gemeinsam einen Weg zu finden. Bei Fragen, Anregungen oder Problemen wenden Sie sich bitte an:</p>
        <br/>
        <p class="text-xl font-light">Dr. Jan Oliver Rüdiger</p>
        <p>CorpusExplorer-Entwickler</p>
        <p class="text-sm -light">Antwortet i. d. R. innerhalb von 2-3 Werktagen.</p>
        <div style="margin-top:5px">
          <a href="mailto:cehelp@jan-oliver-ruediger.de" target="_blank" style="margin:10px 10px 20px 0px">
            <v-btn prepend-icon="mdi-email">E-Mail</v-btn>
          </a>
          <a href="https://notes.jan-oliver-ruediger.de/kontakt/" target="_blank" style="margin:10px 10px 20px 0px">
            <v-btn prepend-icon="mdi-web">Webseite</v-btn>
          </a>
        </div>
      </v-card-text>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
  name: 'HeadDescriptionInfo',
  props: {
    head: String,
    description: String,
  },

  data() {
    return {
      lbl_hdi_video: this.$t('hdi_video'),
      lbl_hdi_exercises: this.$t('hdi_exercises'),
      lbl_hdi_manual: this.$t('hdi_manual'),
      lbl_hdi_contact: this.$t('hdi_contact'),

      dialog_contact: false,
    };
  },
}
</script>

<style></style>