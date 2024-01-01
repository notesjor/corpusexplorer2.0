<template>
  <v-theme-provider theme="dark">
    <v-app>
      <v-app-bar style="height: 75px;">
        <!-- MENU: Main -->
        <v-btn icon style="background-color: green; margin:10px 20px 0px 10px">
          <img alt="Logo" src="../../logo/CorpusExplorer_MENU.svg" style="max-height:32px" />
          <v-menu location="bottom" activator="parent">
            <v-list>
              <v-list-item to="/ce/new">
                <v-icon>mdi-file-outline</v-icon>
                Neues Projekt
              </v-list-item>
              <v-divider></v-divider>
              <v-list-item to="/ce/load">
                <v-icon>mdi-folder-arrow-up-outline</v-icon>
                Projekt laden
              </v-list-item>
              <v-list-item to="/ce/save">
                <v-icon>mdi-folder-arrow-down-outline</v-icon>
                Projekt speichern
              </v-list-item>
              <v-divider></v-divider>
              <v-list-item to="/ce/settings">
                <v-icon>mdi-cog-outline</v-icon>
                Projekt-Einstellungen
              </v-list-item>
              <v-divider></v-divider>
              <v-list-item to="/ce/exit">
                <v-icon>mdi-location-exit</v-icon>
                Beenden
              </v-list-item>
            </v-list>
          </v-menu>
        </v-btn>
        <!-- HOME -->
        <v-btn icon to="/" style="margin:10px 10px 0px 0px">
          <v-icon>mdi-home-outline</v-icon>
        </v-btn>
        <!-- MENU: Corpora -->
        <v-btn icon style="margin:10px 0px 0px 0px">
          <v-icon>mdi-file-cabinet</v-icon>
          <v-menu location="bottom" activator="parent">
            <v-list>
              <v-list-item to="/corpus">
                <v-icon>mdi-eye-outline</v-icon>
                Korpora-Übersicht
              </v-list-item>
              <v-divider></v-divider>
              <v-list-item to="/corpus/annotate">
                <v-icon>mdi-folder-outline</v-icon>
                Dokumente annotieren
              </v-list-item>
              <v-list-item to="/corpus/import">
                <v-icon>mdi-archive-outline</v-icon>
                Korpus importieren
              </v-list-item>
            </v-list>
          </v-menu>
        </v-btn>

        <!-- MENU: Snapshot -->
        <v-btn icon style="margin:10px 0px 0px 0px">
          <v-icon icon>mdi-camera-outline</v-icon>
          <v-menu location="bottom" activator="parent">
            <v-list>
              <v-list-item to="/snapshot">
                <v-icon>mdi-eye-outline</v-icon>
                Schnappschuss-Übersicht
              </v-list-item>
              <v-divider></v-divider>
              <v-list-item to="/snapshot/new">
                <v-icon>mdi-plus</v-icon>
                Neuer Schnappschuss
              </v-list-item>
              <v-list-item to="/snapshot/reduce">
                <v-icon>mdi-plus-circle-outline</v-icon>
                Schnappschuss eingrenzen
              </v-list-item>
            </v-list>
          </v-menu>
        </v-btn>

        <!-- MENU: Analytics -->
        <v-btn icon style="margin:10px 0px 0px 0px">
          <v-icon color="white">mdi-chart-box-outline</v-icon>
          <v-menu location="bottom" activator="parent">
            <v-list>
              <v-list-item to="/analyze">
                <v-icon>mdi-eye-outline</v-icon>
                Eigene Analyse erstellen
              </v-list-item>
              <v-divider></v-divider>
              <v-list-item to="/analyze">
                <v-icon>mdi-table</v-icon>
                Tabelle
              </v-list-item>
            </v-list>
          </v-menu>
        </v-btn>

        <v-spacer></v-spacer>

        <v-combobox style="margin:45px 5px 10px 0px;" variant="outlined" label="Aktiver Schnappschuss" :items="layerInfo"
          item-title="Name" item-value="Guid" v-model="app_selection">
          <template v-slot:selection="{ item }">
            <div v-html="item.title"></div>
          </template>
          <template v-slot:item="{ item }">
            <v-list-item v-html="item.title" @click="changeToMe(item)"></v-list-item>
          </template>
        </v-combobox>
        <!-- MENU __ ENDE __ -->
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
import { useConnectionStore } from '/stores/connection'

export default {
  name: "DefaultLayout",
  data() {
    return {
      title: "CorpusExplorer (Web)",
      layerInfo: [],
      app_selection: ""
    };
  },

  mounted() {
    this.refreshData();
  },

  methods: {
    refreshData() {
      var self = this;

      const store = useConnectionStore();

      var translate = {
        "ALL": self.$t("server_snapshot_all")
      };
      var app = store.connection.getAppApi();
      app.SetTranslation(translate)

      var api = store.connection.getSelectionApi();
      api.SnapshotInfo(
        (data) => {
          self.layerInfo = data;
          var current = self.layerInfo.find(x => x.IsActive);
          if (current) {
            self.app_selection = current.Name;
          }
        },
        (error) => {
          console.log(error);
        })
    },
    changeToMe(item) {
      if(item.value == undefined || item.value == null)
        return;
      
      var self = this;

      const store = useConnectionStore();
      var api = store.connection.getSelectionApi();
      api.SnapshotChange(item.value.Guid,
        (data) => {
          self.$router.go();          
        },
        (error) => {
          console.log(error);
        })
    }
  },

  watch: {
    app_selection: function (val) {
      this.changeToMe(val);
    }
  }
};
</script>