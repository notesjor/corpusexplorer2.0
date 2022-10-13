<template>
  <div>
    <v-row>
      
    </v-row>
    <v-row>

    </v-row>
    <v-row>
      <Big4Numbers :n1="count_corpora" :n2="count_documents" :n3="count_layers" :n4="count_tokens"></Big4Numbers>
    </v-row>
  </div>
</template>

<script>
import Big4Numbers from "/components/Big4Numbers.vue"
export default {
  name: 'CorporaOverview',
  components:{
    Big4Numbers
  },
  data() {
    return {
      count_corpora: 0,
      count_documents: 0,
      count_layers: 0,
      count_tokens: 0
    };
  },
  async mounted(){
    var response = await this.$axios.get("http://localhost:12712/selection/info");
    console.log(response);

    var current = response.data[0];

    this.count_corpora = current.Size.Corpora;
    this.count_documents = current.Size.Documents;
    this.count_layers = current.Size.Layers;
    this.count_tokens = current.Size.Tokens;
  }
}
</script>
