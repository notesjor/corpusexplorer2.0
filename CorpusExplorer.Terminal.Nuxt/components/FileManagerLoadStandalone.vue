<template>
  <div>
    <v-row>
      <v-col>
        <div style="display: inline-block;"><v-icon style="margin-top:-50px" @click="goHome">mdi-home</v-icon></div>
        <div style="display: inline-block;"><v-combobox style="margin:0px 10px 0px 10px" :items="DriveLetters"
            v-model="CurrentDrive" @change="driveChanged" /></div>
        <div style="display: inline-block;">
          <v-breadcrumbs style="display: inline-block; padding-left: 0px;">
            <v-breadcrumbs-item v-for="(item, i) in CurrentPath" :key="i" @click="goToIndex(i)"
              style="margin-top: -50px;">
              <span style="font-weight: 400;">{{ item.text }}</span>
              <span style="margin-left: 10px; font-weight: 200;">{{ DirectorySeparatorChar }}</span>
            </v-breadcrumbs-item>
          </v-breadcrumbs>
        </div>
      </v-col>
    </v-row>
  <!--
    <v-row style="margin-top:-40px">
      <v-col cols="3"></v-col>
      <v-col cols="9">
        <v-text-field v-model="Search" append-icon="mdi-magnify" label="Suchen" single-line hide-details></v-text-field>
      </v-col>
    </v-row>
  -->
    <v-row style="margin-top:-40px">
      <v-col cols="3">
        <v-list dense>
          <v-list-item v-for="(item, i) in Directories" :key="i" @click="goTo(item)"
            :prepend-icon="item == '..' ? 'mdi-folder-arrow-up-outline' : 'mdi-folder'">
            {{ item }}
          </v-list-item>
        </v-list>
      </v-col>
      <v-col cols="9">
        <v-table>
          <thead>
            <tr>
              <th class="text-left">
                <v-icon style="margin-left:7px">mdi-format-list-checks</v-icon>
              </th>
              <th class="text-left">
                Dateiname
              </th>
              <th class="text-left">
                Dateityp
              </th>
              <th class="text-left">
                Dateigröße
              </th>
              <th class="text-left">
                Datum
              </th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="file in Files" :key="file.FileName">
              <td><v-checkbox @change="switchFile(file.FileName)"></v-checkbox></td>
              <td><div style="margin-top:-20px">{{ file.FileName }}</div></td>
              <td><div style="margin-top:-20px">{{ file.Extension }}</div></td>
              <td><div style="margin-top:-20px">{{ fileSizeLabel(file.Size) }}</div></td>
              <td><div style="margin-top:-20px">{{ file.Date }}</div></td>
            </tr>
          </tbody>
        </v-table>
        <v-table v-model="TableSelection" :headers="TableHeaders" :items="Files" :search="Search"
          :footer-props="{ itemsPerPageOptions: [10, 20, 50, 100, 250, -1] }" :single-select="SingleSelect"
          item-key="Path" show-select>
        </v-table>
      </v-col>
    </v-row>
  </div>
</template>

<script>
import { useConnectionStore } from '/stores/connection'

export default {
  props: {
    Filter: {
      type: String,
      default: null,
    },
    SingleSelect: {
      type: Boolean,
      default: false,
    },
  },
  data() {
    return {
      api: null,

      DirectorySeparatorChar: "",
      DriveLetters: [],
      CurrentDrive: "",
      CurrentPath: [],
      Directories: [],

      Search: "",

      FilesRaw: [],
      Files: [],
      TableSelection: [],
    };
  },
  emits: ["LoadFiles"],
  methods: {
    applyFilter() {
      if (this.Filter === undefined) {
        this.Files = this.FilesRaw;
      } else {
        var filter = new Set(this.Filter);
        this.Files = this.FilesRaw.filter(x => filter.has(x.Extension));
      }
    },
    async updateFsInfo() {
      var self = this;
      this.api.GetFileSystemInfo(
        (data) => {
          self.DirectorySeparatorChar = data.DirectorySeparatorChar;
          self.DriveLetters = data.DriveLetters;
          self.CurrentDrive = data.CurrentDrive;
          self.CurrentPath = null;
          self.CurrentPath = data.CurrentPath.map((x) => ({ text: x }));
          self.Directories = data.Directories;
          self.FilesRaw = data.Files;

          self.applyFilter();
        },
        (error) => {
          console.log(error);
        }
      )
    },
    async driveChanged() {
      this.api.SetFileSystemPath(this.CurrentDrive);
      //await this.$axios.$get(
      //  "http://localhost:12712/fs/set?path=" + this.CurrentDrive
      //);
      await this.updateFsInfo();
    },
    async goHome() {
      this.api.SetFileSystemPath("HOME");
      //await this.$axios.$get("http://localhost:12712/fs/set?path=HOME");
      await this.updateFsInfo();
    },
    async goTo(relPath) {
      this.api.SetFileSystemPath(relPath);
      //await this.$axios.$get("http://localhost:12712/fs/set?path=" + relPath);
      await this.updateFsInfo();
    },
    async goToIndex(index) {
      var relPath = [
        this.CurrentDrive.replace(this.DirectorySeparatorChar, ""),
        ...this.CurrentPath.slice(0, index + 1).map((x) => x.text),
      ].join(this.DirectorySeparatorChar);
      //console.log(relPath);
      //
      this.api.SetFileSystemPath(relPath);
      //await this.$axios.$get("http://localhost:12712/fs/set?path=" + relPath);
      await this.updateFsInfo();
    },
    fileSizeLabel(size){
      if (size < 1024) {
        return size + ' B';
      } else if (size < 1024 * 1024) {
        return (size / 1024).toFixed(2) + ' KB';
      } else if (size < 1024 * 1024 * 1024) {
        return (size / 1024 / 1024).toFixed(2) + ' MB';
      } else if (size < 1024 * 1024 * 1024 * 1024) {
        return (size / 1024 / 1024 / 1024).toFixed(2) + ' GB';
      } else {
        return (size / 1024 / 1024 / 1024 / 1024).toFixed(2) + ' TB';
      }
    },
    switchFile(fileName) {
      if (this.SingleSelect) {
        this.TableSelection = [fileName];
      } else {
        var index = this.TableSelection.indexOf(fileName);
        if (index === -1) {
          this.TableSelection.push(fileName);
        } else {
          this.TableSelection.splice(index, 1);
        }
      }
      
      this.$emit('LoadFiles', this.TableSelection);
    },
  },
  mounted() {
    const store = useConnectionStore();
    console.log(store.connection);
    this.api = store.connection.getFileSystemApi();

    this.updateFsInfo();
  },
  watch: {
    Filter: async function () {
      this.applyFilter();
    },
    TableSelection: function () {
      this.$emit('LoadFiles', this.TableSelection)
    }
  }
};
</script>
