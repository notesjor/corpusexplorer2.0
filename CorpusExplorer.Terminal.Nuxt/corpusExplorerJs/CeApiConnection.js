import CeAppApi from './CeAppApi.js';
import CeProjectApi from './CeProjectApi.js';
import CeCorpusApi from './CeCorpusApi.js';
import CeSelectionApi from './CeSelectionApi.js';
import CeAnalyzeApi from './CeAnalyzeApi.js';
import CeFilesystemApi from './CeFilesystemApi.js';

export default class CeApiConnection {
    constructor(hostname = 'localhost', port = '12712', overrideBasePath = null) {
        this.hostname = hostname;
        this.port = port;
        this.basePath = overrideBasePath || `http://${hostname}:${port}`;
    }

    getAppApi(){
        return new CeAppApi(this);
    }

    getProjectApi(){
        return new CeProjectApi(this);
    }

    getCorpusApi(){
        return new CeCorpusApi(this);
    }

    getSelectionApi(){
        return new CeSelectionApi(this);
    }

    getAnalyzeApi(){
        return new CeAnalyzeApi(this);
    }

    getFileSystemApi(){
        return new CeFilesystemApi(this);
    }
}