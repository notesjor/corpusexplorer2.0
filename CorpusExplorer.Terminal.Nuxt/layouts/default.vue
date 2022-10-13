<template>
  <v-app>
    <v-app-bar app class="d-print-none" style="z-index: 999">
      <v-menu close-on-click bottom offset-y>
        <template v-slot:activator="{ on, attrs }">
          <v-btn color="#080" fab elevation="8" v-bind="attrs" v-on="on">
            <img alt="Logo" height="40px" src="/logo/CorpusExplorer_MENU.svg" />
          </v-btn>
        </template>
        <v-list>
          <v-list-item to="/ce/new">
            <v-list-item-icon><v-icon>mdi-file-outline</v-icon></v-list-item-icon>
            <v-list-item-title>Neues Projekt</v-list-item-title>
          </v-list-item>
          <v-list-item to="/ce/load">
            <v-list-item-icon><v-icon>mdi-folder-arrow-up-outline</v-icon></v-list-item-icon>
            <v-list-item-title>Projekt laden</v-list-item-title>
          </v-list-item>
          <v-list-item to="/ce/save">
            <v-list-item-icon><v-icon>mdi-folder-arrow-down-outline</v-icon></v-list-item-icon>
            <v-list-item-title>Projekt speichern</v-list-item-title>
          </v-list-item>
          <v-divider></v-divider>
          <v-list-item to="/ce/settings">
            <v-list-item-icon><v-icon>mdi-cog-outline</v-icon></v-list-item-icon>
            <v-list-item-title>Projekt-Einstellungen</v-list-item-title>
          </v-list-item>
          <v-divider></v-divider>
          <v-list-item to="/ce/exit">
            <v-list-item-icon><v-icon>mdi-location-exit</v-icon></v-list-item-icon>
            <v-list-item-title>Beenden</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>

      <div style="min-width:20px"></div>

      <v-btn color="grey darken-2" fab small elevation="4" to="/">
        <v-icon color="white">mdi-home-variant-outline</v-icon>
      </v-btn>

      <div style="min-width:10px"></div>

      <v-menu close-on-click bottom offset-y>
        <template v-slot:activator="{ on, attrs }">
          <v-btn color="grey darken-2" fab small elevation="4" v-bind="attrs" v-on="on">
            <v-icon color="white">mdi-file-cabinet</v-icon>
          </v-btn>
        </template>
        <v-list>
          <v-list-item to="/corpus/overview">
            <v-list-item-icon><v-icon>mdi-eye-outline</v-icon></v-list-item-icon>
            <v-list-item-title>Korpora-Übersicht</v-list-item-title>
          </v-list-item>
          <v-divider></v-divider>
          <v-list-item to="/corpus/annotate">
            <v-list-item-icon><v-icon>mdi-folder-outline</v-icon></v-list-item-icon>
            <v-list-item-title>Dokumente annotieren</v-list-item-title>
          </v-list-item>
          <v-list-item to="/corpus/import">
            <v-list-item-icon><v-icon>mdi-archive-outline</v-icon></v-list-item-icon>
            <v-list-item-title>Korpus importieren</v-list-item-title>
          </v-list-item>
          <!-- TODO BETA
          <v-list-item to="/corpus/">
            <v-list-item-icon><v-icon>mdi-web</v-icon></v-list-item-icon>
            <v-list-item-title>Online-Korpus akquirieren</v-list-item-title>
          </v-list-item>
          <v-list-item to="/corpus/">
            <v-list-item-icon><v-icon>mdi-pencil-ruler</v-icon></v-list-item-icon>
            <v-list-item-title>Korpus manuell erstellen</v-list-item-title>
          </v-list-item>
          -->
        </v-list>
      </v-menu>

      <div style="min-width:10px"></div>

      <v-menu close-on-click bottom offset-y>
        <template v-slot:activator="{ on, attrs }">
          <v-btn color="grey darken-2" fab small elevation="4" v-bind="attrs" v-on="on">
            <v-icon color="white">mdi-camera-outline</v-icon>
          </v-btn>
        </template>
        <v-list>
          <v-list-item to="/snapshot/overview">
            <v-list-item-icon><v-icon>mdi-eye-outline</v-icon></v-list-item-icon>
            <v-list-item-title>Schnappschuss-Übersicht</v-list-item-title>
          </v-list-item>
          <v-divider></v-divider>
          <v-list-item to="/snapshot/new">
            <v-list-item-icon><v-icon>mdi-plus</v-icon></v-list-item-icon>
            <v-list-item-title>Neuer Schnappschuss</v-list-item-title>
          </v-list-item>
          <v-list-item to="/snapshot/reduce">
            <v-list-item-icon><v-icon>mdi-plus-circle-outline</v-icon></v-list-item-icon>
            <v-list-item-title>Schnappschuss eingrenzen</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>

      <div style="min-width:10px"></div>

      <v-btn color="grey darken-2" fab small elevation="4" to="/analyze">
        <v-icon color="white">mdi-chart-box-outline</v-icon>
      </v-btn>
      
      <v-spacer></v-spacer>

      <v-spacer></v-spacer>

      <v-spacer></v-spacer>

      <v-combobox style="margin-top:28px"></v-combobox>
    </v-app-bar>
    <v-main>
      <v-container>
        <Nuxt />
      </v-container>
    </v-main>
    <v-footer padless>
      <v-card class="flex" flat tile>
        <v-card-text class="py-2" style="text-align: right">
          <div style="display: inline-block">
            Copyright
            2013-{{ new Date().getFullYear() }} —
            <strong>CorpusExplorer (Web) </strong> — 
          </div>
          <div style="display: inline-block">by <i>Dr. Jan Oliver Rüdiger</i> (<a href="mailto:corpusexplorer@jan-oliver-ruediger.de"
              >Kontakt</a
            >) — Rechtliches:</div>
          <div style="display: inline-block"> 
            <a
              href="https://www.gnu.org/licenses/agpl-3.0.de.html"
              style="margin-left: 15px"
              >Lizenz (OpenSource / kostenfrei)</a
            >           
            <a
              href="https://notes.jan-oliver-ruediger.de/impressum/"
              style="margin-left: 15px"
              >Impressum</a
            >
            <a
              href="https://notes.jan-oliver-ruediger.de/impressum/datenschutzerklaerung/"
              style="margin-left: 15px"
              >Datenschutzhinweis</a
            >
            <a
              href="https://notes.jan-oliver-ruediger.de/impressum/haftungsausschluss-disclaimer/"
              style="margin-left: 15px"
              >Haftungsausschluss</a
            >
          </div>
        </v-card-text>
      </v-card>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  name: "DefaultLayout",
  data() {
    return {
      title: "CorpusExplorer (Web)",
    };
  },
};
</script>

<style>
.light::-webkit-scrollbar {
  width: 15px;
}

.light::-webkit-scrollbar-track {
  background: #e6e6e6;
  border-left: 1px solid #dadada;
}

.light::-webkit-scrollbar-thumb {
  background: #b0b0b0;
  border: solid 3px #e6e6e6;
  border-radius: 7px;
}

.light::-webkit-scrollbar-thumb:hover {
  background: black;
}

.dark::-webkit-scrollbar {
  width: 15px;
}

.dark::-webkit-scrollbar-track {
  background: #202020;
  border-left: 1px solid #2c2c2c;
}

.dark::-webkit-scrollbar-thumb {
  background: #3e3e3e;
  border: solid 3px #202020;
  border-radius: 7px;
}

.dark::-webkit-scrollbar-thumb:hover {
  background: white;
}
</style>