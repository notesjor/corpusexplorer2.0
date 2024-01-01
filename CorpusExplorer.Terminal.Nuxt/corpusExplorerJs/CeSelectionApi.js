export default class CeSelectionApi {
  static __snapshotAllName = "ALL";

  constructor(connection) {
    this.__connection = connection;
  }

  SelectionNew(data, func, funcError) {
    console.log(data);
    fetch(this.__connection.basePath + "/selection/new", { 
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

  SelectionReduce(data, func, funcError) {
    console.log(data);
    fetch(this.__connection.basePath + "/selection/reduce", { 
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

  SnapshotInfo(func, funcError) {
    fetch(this.__connection.basePath + "/selection/info")
      .then((response) => response.json())
      .then((data) => {
        return func(data);
      })
      .catch((error) => {
        funcError(error);
      });
  }  

  SnapshotMeta(guid, func, funcError) {
    fetch(this.__connection.basePath + "/selection/meta?guid=" + guid)
      .then((response) => response.json())
      .then((data) => {
        return func(data);
      })
      .catch((error) => {
        funcError(error);
      });
  } 

  SnapshotChange(guid, func, funcError) {
    fetch(this.__connection.basePath + "/selection/change?guid=" + guid)
      .then(() => {
        return func();
      })
      .catch((error) => {
        funcError(error);
      });
  } 
}
