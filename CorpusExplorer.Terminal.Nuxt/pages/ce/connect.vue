<template>
  <v-row>
    <v-col>
      <FileManagerLoad @loadFiles="save" :Filter="Filter"></FileManagerLoad>
    </v-col>
  </v-row>
</template>

<script>
import FileManagerLoad from "~/components/FileManagerLoadStandalone.vue"

export default {
  name: "InspirePage",
  components: {
    FileManagerLoad
  },
  data() {
    return {
      Filter: ['.xml']
    }
  },
  methods:{
    save(file){
      console.log(file);
    }
  }
};
</script>
