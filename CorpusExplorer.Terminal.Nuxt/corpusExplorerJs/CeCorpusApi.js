export default class CeCorpusApi {
  constructor(connection) {
    this.__connection = connection;
  }

  CorpusAnnotateInfo(func, funcError) {
    fetch(this.__connection.basePath + "/corpus/annotate")
      .then((response) => response.json())
      .then((data) => {
        return func(data);
      })
      .catch((error) => {
        funcError(error);
      });
  }

  CorpusAnnotate(data, func, funcError) {
    fetch(this.__connection.basePath + "/corpus/annotate", { 
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
    })
      .then((response) => response.json())
      .then((data) => {
        return func(data);
      })
      .catch((error) => {
        funcError(error);
      });
  }

  CorpusImportInfo(func, funcError) {
    fetch(this.__connection.basePath + "/corpus/import")
      .then((response) => response.json())
      .then((data) => {
        return func(data);
      })
      .catch((error) => {
        funcError(error);
      });
  }

  CorpusImport(data, func, funcError) {
    console.log(data);
    fetch(this.__connection.basePath + "/corpus/import", { 
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
    })
      .then((response) => response.json())
      .then((data) => {
        return func(data);
      })
      .catch((error) => {
        funcError(error);
      });
  }
}
