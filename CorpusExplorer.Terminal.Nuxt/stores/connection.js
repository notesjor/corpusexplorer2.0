// stores/connection.js
import { defineStore } from "pinia";
import CeApiConnection from "/corpusExplorerJs/CeApiConnection.js";

export const useConnectionStore = defineStore("connection", {
  persist: {
    storage: persistedState.localStorage,
  },

  state: () => {
    return { 
      hostname: "localhost",
      port: "12712",
      basePath: "http://localhost:12712",
     };
  },

  actions: {
    create(hostname = "localhost", port = "12712", overrideBasePath = null) {
      this.hostname = hostname;
      this.port = port;
      if (overrideBasePath) {
        this.basePath = overrideBasePath;
      } else {
        this.basePath = "http://" + hostname + ":" + port;
      }
    },
  },

  getters: {
    connection (state) {
      return new CeApiConnection(
        state.hostname,
        state.port,
        state.basePath
      )
    }
  },
});
