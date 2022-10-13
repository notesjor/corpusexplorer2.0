<template>
  <v-row>
    <v-col>
      <BigNumber Unit="Korpora" :Value="n1" :Decimal="0"></BigNumber>
    </v-col>
    <v-col>
      <BigNumber Unit="Dokumente" :Value="n2"></BigNumber>
    </v-col>
    <v-col>
      <BigNumber Unit="Layer" :Value="n3" :Decimal="0"></BigNumber>
    </v-col>
    <v-col>
      <BigNumber Unit="Token" :Value="n4"></BigNumber>
    </v-col>
  </v-row>
</template>
    
<script>
export default {
  name: "Big4Numbers",
  props: ["n1", "n2", "n3", "n4"],
};
</script>