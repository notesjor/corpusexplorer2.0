export const state = () => ({
  data: {
    numberFormatShort: new Intl.NumberFormat('de-DE', { maximumSignificantDigits: 2 }),
    numberFormatLong: new Intl.NumberFormat('de-DE', { maximumSignificantDigits: 5 }),
  }
});

export const mutations = {
  set_numberFormatShort(state, newFormat){
    state.data.numberFormatShort = newFormat;
  },
  set_numberFormatLong(state, newFormat){
    state.data.numberFormatLong = newFormat;
  },
}
