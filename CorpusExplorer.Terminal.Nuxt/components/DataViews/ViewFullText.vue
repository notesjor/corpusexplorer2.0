<template>
  <div>
    <v-row>
      <v-toolbar>
        <v-btn fab small
        style="margin-right:20px"
        ><v-icon>mdi-arrow-left</v-icon></v-btn>  
        <v-select
          :items="meta_labels"
          v-model="selected_meta_label"
          label="Metaangabe (z. B. Titel):"   
          style="margin: 40px 0px 20px 0px"       
        ></v-select> 
        <span style="margin-right:20px">:</span> 
        <v-select
          :items="meta_values"
          v-model="selected_meta_value"
          label="Ausgewählter Wert (Bezieht sich auf Metaangabe)" 
          style="margin: 40px 20px 20px 0px"
          dense
          outlined         
        ></v-select>  
        <v-btn fab small><v-icon>mdi-arrow-right</v-icon></v-btn>   
      </v-toolbar>
    </v-row>
  </div>
</template>
  
  <script>

export default {
  name: "ViewFullText",
  components: {
  },
  data() {
    return {
      data: {
        meta_labels: ["Titel", "Autor", "GUID"],
        selected_meta_label: "Titel",
        meta_values: ["Titel 1", "Titel 2", "Titel 3"],
        selected_meta_value: "Titel 1",
      },
    };
  },
  mounted() {},
};
</script>