<template>
  <div>
    <DxDataGrid id="grid" ref="grid" :data-source="dataSource" :column-auto-width="true" :allow-column-resizing="true"
      :allow-column-reordering="true" :height="height">

      <DxColumn v-for="c in schema" :key="c" :data-field="c.dataField" :caption="c.caption" :allow-fixing="true"
        :alignment="c.align == undefined ? 'left' : c.align" />

      <DxFilterRow :visible="true" />
      <DxColumnChooser :enabled="true" mode="select" />
      <DxSorting mode="multiple" />
      <DxScrolling mode="virtual" />
      <DxGrouping :context-menu-enabled="true" />
      <DxGroupPanel :visible="true" />
    </DxDataGrid>
  </div>
</template>
  
<script>
import 'devextreme/dist/css/dx.material.blue.light.compact.css';
import { DxDataGrid, DxColumn, DxFilterRow, DxColumnChooser, DxSorting, DxScrolling, DxGrouping, DxGroupPanel } from 'devextreme-vue/data-grid';

export default {
  name: "ViewGrid",
  components: {
    DxDataGrid,
    DxColumn,
    DxFilterRow,
    DxColumnChooser,
    DxSorting,
    DxScrolling,
    DxGrouping,
    DxGroupPanel
  },
  data() {
    return {
      dataSource: {
        store: []
      },
      height: 600,
    };
  },
  mounted() {
    this.height = window.innerHeight - 150;

    var self = this;
    fetch('http://localhost:12712/analyze', {
      method: 'POST',
      body: JSON.stringify({
        "Action": "frequency3",
        "Arguments": []
      })
    }).then(response => response.json())
      .then(data => {
        self.dataSource = {
          store: data
        };
      });
  },
};
</script>