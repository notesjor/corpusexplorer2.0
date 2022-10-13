<template>
  <div>
    <v-row style="margin-top: -30px; margin-bottom: -30px">
      <v-col cols="1">
        <v-combobox
          :items="DriveLetters"
          v-model="CurrentDrive"
          @change="driveChanged"
        />
      </v-col>
      <v-col cols="11">
        <v-icon
          style="display: inline-block; margin-right: 10px"
          @click="goHome"
          >mdi-home</v-icon
        >
        <v-breadcrumbs
          style="display: inline-block; margin-top: 5px; padding-left: 0px"
        >
          <v-breadcrumbs-item
            v-for="(item, i) in CurrentPath"
            :key="i"
            @click="goToIndex(i)"
          >
            <span style="margin-right: 10px">{{ DirectorySeparatorChar }}</span>
            <span>{{ item.text }}</span>
          </v-breadcrumbs-item>
        </v-breadcrumbs>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="3">
        <v-list dense>
          <v-list-item
            v-for="(item, i) in Directories"
            :key="i"
            @click="goTo(item)"
            v-if="i == 0 && CurrentPath.length > 0"
          >
            <v-list-item-icon>
              <v-icon>mdi-folder-arrow-up-outline</v-icon>
            </v-list-item-icon>
            <v-list-item-content>
              <v-list-item-title>{{ item }}</v-list-item-title>
            </v-list-item-content>
          </v-list-item>
          <v-list-item
            v-for="(item, i) in Directories"
            :key="i"
            @click="goTo(item)"
            v-if="i > 0"
          >
            <v-list-item-icon>
              <v-icon>mdi-folder</v-icon>
            </v-list-item-icon>
            <v-list-item-content>
              <v-list-item-title>{{ item }}</v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </v-list>
      </v-col>
      <v-divider vertical></v-divider>
      <v-col cols="9">
        <v-row>
          <v-col
            ><v-text-field
              v-model="Search"
              append-icon="mdi-magnify"
              label="Suchen"
              single-line
              hide-details
              style="margin-bottom: 10px; margin-top: -10px"
            ></v-text-field
          ></v-col>
        </v-row>
        <v-data-table
          v-model="TableSelection"
          :headers="TableHeaders"
          :items="Files"
          :search="Search"
          :footer-props="{ itemsPerPageOptions: [10, 20, 50, 100, 250, -1] }"
          :single-select="SingleSelect"
          item-key="Path"
          show-select
        >
        </v-data-table>
      </v-col>
    </v-row>
  </div>
</template>

<script>
export default {
  props: ["Filter", "SingleSelect"],
  data() {
    return {
      DirectorySeparatorChar: "",
      DriveLetters: [],
      CurrentDrive: "",
      CurrentPath: [],
      Directories: [],

      Search: "",

      Files: [],
      TableHeaders: [
        { text: "Dateiname", value: "FileName", filterable: true },
        { text: "Dateityp", value: "Extension" },
        { text: "Dateigröße", value: "Size" },
        { text: "Datum", value: "Date" },
      ],
      TableSelection: [],
    };
  },
  emits: ["LoadFiles"],
  methods: {
    async updateFsInfo() {
      var data = await this.$axios.$get("http://localhost:12712/fs/get");

      this.DirectorySeparatorChar = data.DirectorySeparatorChar;
      this.DriveLetters = data.DriveLetters;
      this.CurrentDrive = data.CurrentDrive;
      this.CurrentPath = null;
      this.CurrentPath = data.CurrentPath.map((x) => ({ text: x }));
      this.Directories = data.Directories;

      if (this.Filter === undefined) {
        this.Files = data.Files;
      } else {
        var filter = new Set(this.Filter);
        this.Files = data.Files.filter(x => filter.has(x.Extension));
      }
    },
    async driveChanged() {
      await this.$axios.$get(
        "http://localhost:12712/fs/set?path=" + this.CurrentDrive
      );
      await this.updateFsInfo();
    },
    async goHome() {
      await this.$axios.$get("http://localhost:12712/fs/set?path=HOME");
      await this.updateFsInfo();
    },
    async goTo(relPath) {
      await this.$axios.$get("http://localhost:12712/fs/set?path=" + relPath);
      await this.updateFsInfo();
    },
    async goToIndex(index) {
      var relPath = [
        this.CurrentDrive.replace(this.DirectorySeparatorChar, ""),
        ...this.CurrentPath.slice(0, index + 1).map((x) => x.text),
      ].join(this.DirectorySeparatorChar);
      console.log(relPath);

      await this.$axios.$get("http://localhost:12712/fs/set?path=" + relPath);
      await this.updateFsInfo();
    },
  },
  mounted() {
    this.updateFsInfo();
  },
  watch: {
    Filter: async function () {
      this.Filter = this.Filter;
      await this.updateFsInfo();
    },
    TableSelection: function()    {
      this.$emit('LoadFiles', this.TableSelection)
    }
  }
};
</script>
