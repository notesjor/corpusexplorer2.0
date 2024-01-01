<template>
  <v-row style="margin-bottom: 10px;">
    <v-col>
      <BigNumber :Unit="lbl_unit_corpora" :Value="count_corpora" :Decimal="0"></BigNumber>
    </v-col>
    <v-col>
      <BigNumber :Unit="lbl_unit_documents" :Value="count_documents"></BigNumber>
    </v-col>
    <v-col>
      <BigNumber :Unit="lbl_unit_layer" :Value="count_layers" :Decimal="0"></BigNumber>
    </v-col>
    <v-col>
      <BigNumber :Unit="lbl_unit_token" :Value="count_tokens"></BigNumber>
    </v-col>
  </v-row>
</template>
    
<script>
export default {
  name: "Big4Numbers",
  props: ["count_corpora", "count_documents", "count_layers", "count_tokens"],
  data() {
    return {
      lbl_unit_corpora: this.$t('unit_corpora'),
      lbl_unit_documents: this.$t('unit_documents'),
      lbl_unit_layer: this.$t('unit_layer'),
      lbl_unit_token: this.$t('unit_token'),
    }
  }
};
</script>