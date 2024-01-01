export default class CeAppApi {
  constructor(connection) {
    this.__connection = connection;
  }

  SetTranslation(data) {
    fetch(this.__connection.basePath + "/app/translate", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    })
      .catch((error) => {
        funcError(error);
      });
  }
}
