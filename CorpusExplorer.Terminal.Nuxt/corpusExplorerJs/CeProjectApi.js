export default class CeProjectApi {
  constructor(connection) {
    this.__connection = connection;
  }

  ProjectNew(func, funcError) {
    fetch(this.__connection.basePath + "/project/new", { method: "POST" })
      .then((response) => {
        if (response.status === 200) {
          func();
        } else {
          funcError(response);
        }
      })
      .catch((error) => {
        funcError(error);
      });
  }

  ProjectSave(filename, func, funcError) {
    var data = { Path: filename };

    fetch(this.__connection.basePath + "/project/save", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    })
      .then((response) => {
        if (response.status === 200) {
          func();
        } else {
          funcError(response);
        }
      })
      .catch((error) => {
        funcError(error);
      });
  }

  ProjectLoad(filename, func, funcError) {
    var data = { Path: filename };

    fetch(this.__connection.basePath + "/project/load", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    })
      .then((response) => {
        if (response.status === 200) {
          func();
        } else {
          funcError(response);
        }
      })
      .catch((error) => {
        funcError(error);
      });
  }

  ProjectSettings() {
    // NotImplementedException
  }

  ProjectInfo(func, funcError) {
    fetch(this.__connection.basePath + "/project/info")
      .then((response) => response.json())
      .then((data) => { return func(data); })
      .catch((error) => {
        funcError(error);
      });
  }
}
