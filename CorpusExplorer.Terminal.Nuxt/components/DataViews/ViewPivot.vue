<template>
  <div id="app">
    <DxPivotGrid id="pivotgrid" ref="grid" :data-source="dataSource" :allow-sorting-by-summary="true"
      :allow-filtering="true" :show-borders="true" :show-column-grand-totals="true" :show-row-grand-totals="true"
      :show-row-totals="false" :show-column-totals="false">
      <DxFieldChooser :enabled="true" :height="400" />
    </DxPivotGrid>
  </div>
</template>
  
<script>
import 'devextreme/dist/css/dx.material.blue.light.compact.css';

import {
  DxChart,
  DxAdaptiveLayout,
  DxCommonSeriesSettings,
  DxSize,
  DxTooltip,
  DxExport
} from 'devextreme-vue/chart';

import Chart from "devextreme/viz/chart";

import {
  DxPivotGrid,
  DxFieldChooser
} from 'devextreme-vue/pivot-grid';

export default {
  name: "ViewPivot",
  components: {
    DxChart,
    DxAdaptiveLayout,
    DxCommonSeriesSettings,
    DxSize,
    DxTooltip,
    DxPivotGrid,
    DxFieldChooser,
    DxExport,
    Chart
  },
  data() {
    return {
      vizMode: { title: "Balken", value: "bar" },
      vizModes: [
        { title: "Balken", value: "bar" },
        { title: "Linien", value: "line" },
        { title: "Flächen", value: "area" },
        { title: "Scatter", value: "scatter" },
        { title: "Bubble", value: "bubble" },
        { title: "Balken (gestapelt)", value: "stackedbar" },
        { title: "Linien (gestapelt)", value: "stackedline" },
        { title: "Flächen (gestapelt)", value: "stackedarea" },
        { title: "Balken (auf 100%)", value: "fullstackedbar" },
        { title: "Linien (auf 100%)", value: "fullstackedline" },
        { title: "Flächen (auf 100%)", value: "fullstackedarea" },
      ],
      fieldsOriginal: [],
      dataSource: {
        fields: [],
        store: []
        ,
      },
      customizeTooltip(args) {
        return {
          html: `${args.argumentText} / ${args.seriesName}: ${args.originalValue}`,
        };
      },
      height: 600,
      renderMode: "Fixed",
    };
  },
  mounted() {
    this.height = window.innerHeight - 150;

    var self = this;

    /* COPILOT
    fetch('http://localhost:12712/analyze', {
      method: 'POST',
      body: JSON.stringify({
        "Action": "frequency3",
        "Arguments": []
      })
    }).then(response => response.json())
      .then(data => {
        self.dataSource = {
          fields: data.fields,
          store: data.store
        };
        self.fieldsOriginal = data.fields;
      });
      */

     /* Notwendig
     fetch(`${basePath}/schema.json`)
        .then(response => response.json())
        .then(schema => {
          fetch(`${basePath}/data.json`)
            .then(response => response.json())
            .then(data => {
              self.$data.fieldsOriginal = schema;
              self.$data.dataSource = {
                fields: schema,
                store: data
              };

              const pivotGrid = self.$refs.grid.instance;
              const chart = self.$refs.chart.instance;
              pivotGrid.bindChart(chart, {
                dataFieldsDisplayMode: 'splitPanes',
                alternateDataFields: false,
              });
              self.setProfile(0);
            });
        });
        */
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
