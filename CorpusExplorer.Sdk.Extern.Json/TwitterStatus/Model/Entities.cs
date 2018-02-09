﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CorpusExplorer.Sdk.Extern.Json.TwitterStatus.Model
{

    public class Entities
    {

        [JsonProperty("UserMentionEntities")]
        public UserMentionEntity[] UserMentionEntities { get; set; }

        [JsonProperty("UrlEntities")]
        public UrlEntity[] UrlEntities { get; set; }

        [JsonProperty("HashTagEntities")]
        public object[] HashTagEntities { get; set; }

        [JsonProperty("MediaEntities")]
        public MediaEntity[] MediaEntities { get; set; }

        [JsonProperty("SymbolEntities")]
        public object[] SymbolEntities { get; set; }
    }

}