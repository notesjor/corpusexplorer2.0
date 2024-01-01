// plugins/vuetify.js
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

export default defineNuxtPlugin(nuxtApp => {
  const vuetify = createVuetify({
    components,
    directives,
    theme: {
      themes: {
        light: {
          dark: false,
          colors: {
            primary: '#4CAF50',
            secondary: '#2196F3',
            accent: '#FFC107',
            error: '#FF5252',
            info: '#2196F3',
            success: '#1B5E20',
            warning: '#D50000'
          }
        }
      }
    }
  })

  nuxtApp.vueApp.use(vuetify)
})