<template>
  <div id="app">
    <ejs-pivotview id="pivotview_flist" :height="height"></ejs-pivotview>
    <ejs-pivotfieldlist
      id="pivotfieldlist1"
      :dataSourceSettings="dataSourceSettings"
      :enginePopulated="fieldEnginePopulated"
      :renderMode="renderMode"
    ></ejs-pivotfieldlist>
  </div>
</template>
  
  <script>
import Vue from "vue";
import {
  PivotViewPlugin,
  PivotFieldListPlugin,
} from "@syncfusion/ej2-vue-pivotview";

Vue.use(PivotViewPlugin);
Vue.use(PivotFieldListPlugin);

export default {
  data() {
    return {
      dataSourceSettings: {
        dataSource: [
          {
            balance: 2430.87,
            quantity: 11,
            name: "Skinner Ward",
            gender: "male",
            company: "GROK",
            state: "New Jercy",
          },
          {
            balance: 3192.7,
            quantity: 15,
            name: "Gwen Dixon",
            gender: "female",
            company: "ICOLOGY",
            state: "Vetaikan",
          },
          {
            balance: 1663.84,
            quantity: 14,
            name: "Deena Gillespie",
            gender: "female",
            company: "OVERPLEX",
            state: "New Jercy",
          },
        ],
        expandAll: true,
      },
      height: 350,
      renderMode: "Fixed",
    };
  },
  methods: {
    fieldEnginePopulated: function (args) {
      let fieldListObj =
        document.getElementById("pivotfieldlist1").ej2_instances[0];
      let pivotGridObj =
        document.getElementById("pivotview_flist").ej2_instances[0];
      fieldListObj.updateView(pivotGridObj);
    },
  },
};
</script>
<style>
@import "@syncfusion/ej2-vue-pivotview/styles/material.css";
@import "@syncfusion/ej2-inputs/styles/material.css";
@import "@syncfusion/ej2-buttons/styles/material.css";
@import "@syncfusion/ej2-dropdowns/styles/material.css";
@import "@syncfusion/ej2-lists/styles/material.css";
@import "@syncfusion/ej2-popups/styles/material.css";
@import "@syncfusion/ej2-popups/styles/material.css";
@import "@syncfusion/ej2-navigations/styles/material.css";
@import "@syncfusion/ej2-grids/styles/material.css";
</style>