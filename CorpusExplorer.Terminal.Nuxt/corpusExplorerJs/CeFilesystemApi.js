export default class CeFilesystemApi {
  constructor(connection) {
    this.__connection = connection;
  }
  
  GetFileSystemInfo(func, funcError) {
    console.log(this.__connection.basePath);
    fetch(this.__connection.basePath + "/fs/get")
      .then((response) => response.json())
      .then((data) => {
        return func(data);
      })
      .catch((error) => {
        funcError(error);
      });
  }
  SetFileSystemPath(path, funcError) {
    fetch(
      this.__connection.basePath + "/fs/set?path=" + encodeURIComponent(path)
    ).catch((error) => {
      funcError(error);
    });
  }
}
