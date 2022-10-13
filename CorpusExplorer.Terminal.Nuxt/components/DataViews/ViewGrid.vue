<template>
  <div>
    <ejs-grid
      ref="grid"
      :dataSource="data"
      :allowSorting="true"
      :allowGrouping="true"
      :allowFiltering="true"
    >
    </ejs-grid>
  </div>
</template>
  
  <script>
import Vue from "vue";
import { GridPlugin, Sort, Group, Filter } from "@syncfusion/ej2-vue-grids";

Vue.use(GridPlugin);

export default {
  name: "Analyse",
  components: {
    GridPlugin,
  },
  data() {
    return {
      data: [
        { OrderID: 10248, CustomerID: "VINET", Freight: 32.38 },
        { OrderID: 10249, CustomerID: "TOMSP", Freight: 11.61 },
        { OrderID: 10250, CustomerID: "HANAR", Freight: 65.83 },
        { OrderID: 10251, CustomerID: "VICTE", Freight: 41.34 },
        { OrderID: 10252, CustomerID: "SUPRD", Freight: 51.3 },
        { OrderID: 10253, CustomerID: "HANAR", Freight: 58.17 },
        { OrderID: 10254, CustomerID: "CHOPS", Freight: 22.98 },
        { OrderID: 10255, CustomerID: "RICSU", Freight: 148.33 },
        { OrderID: 10256, CustomerID: "WELLI", Freight: 13.97 },
      ],
    };
  },
  mounted() {},
  provide: {
    grid: [Sort, Group, Filter],
  },
};
</script>
  
<style>
@import "@syncfusion/ej2-base/styles/material.css";
@import "@syncfusion/ej2-inputs/styles/material.css";
@import "@syncfusion/ej2-buttons/styles/material.css";
@import "@syncfusion/ej2-dropdowns/styles/material.css";
@import "@syncfusion/ej2-lists/styles/material.css";
@import "@syncfusion/ej2-popups/styles/material.css";
@import "@syncfusion/ej2-popups/styles/material.css";
@import "@syncfusion/ej2-navigations/styles/material.css";
@import "@syncfusion/ej2-grids/styles/material.css";
</style>