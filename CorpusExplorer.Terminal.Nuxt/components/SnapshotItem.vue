<template>
  <v-list-item v-if="item.Children == null" :prepend-icon="isActiveIcon()" @click="changeToMe">
    <v-list-item-title v-html="isActiveText(item.Name)"></v-list-item-title>
  </v-list-item>
  <v-list-group v-else @click="changeToMe">
    <template v-slot:activator="{ props }">
      <v-list-item v-bind="props" :prepend-icon="isActiveIcon()">
        <v-list-item-title v-html="isActiveText(item.Name)"></v-list-item-title>
      </v-list-item>
    </template>
    <snapshot-item v-for="(child, i) in item.Children" :key="i" :item="child"></snapshot-item>
  </v-list-group>
</template>

<script>
import { useConnectionStore } from '/stores/connection'

export default {
  name: "SnapshotItem",
  props: {
    item: {
      type: Object,
      required: true
    }
  },
  data() {
    return {
      snapshot_all: this.$t("snapshot_all"),
    }
  },
  methods: {
    isActiveText(name){
      return this.item.IsActive ? `<strong>${name}</strong>` : name;
    },
    isActiveIcon(){
      return this.item.IsActive ? "mdi-checkbox-marked-outline" : "mdi-checkbox-blank-outline";
    },
    changeToMe() {
      if(this.item.IsActive) 
        return;

      const store = useConnectionStore();
      var api = store.connection.getSelectionApi();

      const router = useRouter();
      api.SnapshotChange(this.item.Guid, ()=>{        
        router.go();
      }, ()=>{
        router.go();
      });
    }
  },
}
</script>