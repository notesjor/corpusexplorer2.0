<template>
  <div>
    <ViewPivot></ViewPivot>
    <ViewGrid></ViewGrid>
  </div>
</template>

<script>
import ViewPivot from "@/components/DataViews/ViewPivot.vue";
import ViewGrid from "@/components/DataViews/ViewGrid.vue";
export default {
  name: 'Analyse',
  components:{
    ViewPivot,
    ViewGrid
},
}
</script>

<style>
  
</style>