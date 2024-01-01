<template>
  <div style="text-align:center; display:inline">      
    <div style="font-size:64px; font-weight:300">
      {{ PrivateValue }}
    </div>
    <div>
      {{ Size }} {{ Unit }}
    </div>
  </div>
</template>
  
<script>
var size = []

export default {
name: "BigNumber",
props:{
  Value: {
    type: Number,
    default: 0
  },
  Unit: {
    type: String,
    default: ""
  },
  Decimal: {
    type: Number,
    default: 2
  },
},
mounted() {
  size.push(this.$t('size_1K'));
  size.push(this.$t('size_1M'));
  size.push(this.$t('size_1G'));
},
watch: {
  Value: function(newVal, oldVal){
    var idx = -1;
    var val = newVal * 1.0;
    while(idx < size.length && val > 1000)
      {
        idx++;
        val = val / 1000.0;
      }

    this.PrivateValue = val.toFixed(idx < 0 ? 0 : this.Decimal);
    this.Size = idx < 0 ? "" : size[idx];
  }
},
data() {
  return {
    Size: '',
    PrivateValue: 0
  }
}
};
</script>