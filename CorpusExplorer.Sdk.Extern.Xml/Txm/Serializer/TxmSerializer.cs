﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorpusExplorer.Sdk.Extern.Xml.Abstract.SerializerBasedScraper;
using CorpusExplorer.Sdk.Extern.Xml.Txm.Model;

namespace CorpusExplorer.Sdk.Extern.Xml.Txm.Serializer
{
  public class TxmSerializer : AbstractGenericSerializer<TEI>
  {
    protected override void DeserializePostValidation(TEI obj, string path)
    {
    }

    protected override void DeserializePreValidation(string path)
    {
      CheckFileExtension(path, "xml");
    }

    protected override void SerializePostValidation(TEI obj, string path)
    {
    }

    protected override void SerializePreValidation(TEI obj, string path)
    {
      CheckFileExtension(path, "xml");
    }
  }
}
