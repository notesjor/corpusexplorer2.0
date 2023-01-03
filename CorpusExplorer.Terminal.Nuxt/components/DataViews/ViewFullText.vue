<template>
  <div>
    <v-row>
      <v-toolbar>
        <v-btn fab small
        style="margin-right:20px"
        ><v-icon>mdi-arrow-left</v-icon></v-btn>  
        <v-select
          :items="items"
          label="Standard"   
          style="margin: 40px 0px 20px 0px"       
        ></v-select> 
        <span style="margin-right:20px">:</span> 
        <v-select
          :items="items"
          label="Standard" 
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

      },
    };
  },
  mounted() {},
};
</script>