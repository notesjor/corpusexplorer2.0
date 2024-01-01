<template>
  <v-theme-provider theme="dark">
    <v-app>
      <v-app-bar style="height: 75px;">
        <v-spacer></v-spacer>

        <div style="font-size: 46px;">CorpusExplorer</div>

        <v-spacer></v-spacer>
      </v-app-bar>
      <v-theme-provider theme="light">
        <v-main style="background-color: white; color:black">
          <v-container>
            <div>
              <v-row justify="center" style="color:black; text-align:justify">
                <v-col xs="11" sm="10" md="9" lg="8" xl="7" xxl="6">
                  <slot></slot>
                </v-col>
              </v-row>
            </div>
          </v-container>
        </v-main>
      </v-theme-provider>
      <v-footer style="max-height:32px; font-size: 12px;">
        <div style="display: inline-block">
          Copyright
          2013-2023 —
          <strong>CorpusExplorer (Web) </strong>
        </div>
        <v-spacer></v-spacer>
        <div style="display: inline-block"> by <i>J. O. Rüdiger</i> (<a
            href="mailto:corpusexplorer@jan-oliver-ruediger.de">Kontakt</a>)</div>
        <v-spacer></v-spacer>
        <div>Rechtliches:</div>
        <div style="display: inline-block">
          <a href="https://www.gnu.org/licenses/agpl-3.0.de.html" style="margin-left: 15px">Lizenz (OpenSource &
            kostenfrei)</a>
          <a href="https://notes.jan-oliver-ruediger.de/impressum/" style="margin-left: 15px">Impressum</a>
          <a href="https://notes.jan-oliver-ruediger.de/impressum/datenschutzerklaerung/"
            style="margin-left: 15px">Datenschutzhinweis</a>
          <a href="https://notes.jan-oliver-ruediger.de/impressum/haftungsausschluss-disclaimer/"
            style="margin-left: 15px">Haftungsausschluss</a>
        </div>
      </v-footer>
    </v-app>
  </v-theme-provider>
</template>

<script>
export default {
  name: "DefaultLayout",
  data() {
    return {
      title: "CorpusExplorer (Web)",
      layerInfo: [],
      app_selection: ""
    };
  },
};
</script>