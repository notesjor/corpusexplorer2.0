﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.18444
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// Dieser Quellcode wurde automatisch generiert von xsd, Version=4.0.30319.33440.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class Corpus : CorpusType {
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class CorpusType {
    
    private object dBNodeField;
    
    private KeyType[] descriptionField;
    
    private KeyType[][] mirrorsField;
    
    private object[] itemsField;
    
    private AsocFileType[] asocFileField;
    
    private string nameField;
    
    private string idField;
    
    private string parentField;
    
    private string uniqueSpeakerDistinctionField;
    
    private string schemaVersionField;
    
    /// <remarks/>
    public object DBNode {
        get {
            return this.dBNodeField;
        }
        set {
            this.dBNodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Key", IsNullable=false)]
    public KeyType[] Description {
        get {
            return this.descriptionField;
        }
        set {
            this.descriptionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Key", typeof(KeyType), IsNullable=false)]
    public KeyType[][] Mirrors {
        get {
            return this.mirrorsField;
        }
        set {
            this.mirrorsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Corpus", typeof(CorpusType))]
    [System.Xml.Serialization.XmlElementAttribute("CorpusData", typeof(CorpusData))]
    public object[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AsocFile")]
    public AsocFileType[] AsocFile {
        get {
            return this.asocFileField;
        }
        set {
            this.asocFileField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
    public string Name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, DataType="ID")]
    public string Id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, DataType="IDREF")]
    public string Parent {
        get {
            return this.parentField;
        }
        set {
            this.parentField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
    public string uniqueSpeakerDistinction {
        get {
            return this.uniqueSpeakerDistinctionField;
        }
        set {
            this.uniqueSpeakerDistinctionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
    public string schemaVersion {
        get {
            return this.schemaVersionField;
        }
        set {
            this.schemaVersionField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class CorpusData {
    
    private object[] itemsField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Communication", typeof(CommunicationType))]
    [System.Xml.Serialization.XmlElementAttribute("Speaker", typeof(PersonType))]
    public object[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class CommunicationType {
    
    private object[] itemsField;
    
    private string idField;
    
    private string nameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AsocFile", typeof(AsocFileType))]
    [System.Xml.Serialization.XmlElementAttribute("Description", typeof(DescriptionType))]
    [System.Xml.Serialization.XmlElementAttribute("File", typeof(FileType))]
    [System.Xml.Serialization.XmlElementAttribute("Language", typeof(LanguageType))]
    [System.Xml.Serialization.XmlElementAttribute("Location", typeof(LocationType))]
    [System.Xml.Serialization.XmlElementAttribute("Recording", typeof(RecordingType))]
    [System.Xml.Serialization.XmlElementAttribute("Setting", typeof(CommunicationTypeSetting))]
    [System.Xml.Serialization.XmlElementAttribute("Transcription", typeof(TranscriptionType))]
    public object[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, DataType="ID")]
    public string Id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
    public string Name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class AsocFileType {
    
    private object nameField;
    
    private FileType fileField;
    
    private KeyType[] descriptionField;
    
    private string idField;
    
    /// <remarks/>
    public object Name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    public FileType File {
        get {
            return this.fileField;
        }
        set {
            this.fileField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Key", IsNullable=false)]
    public KeyType[] Description {
        get {
            return this.descriptionField;
        }
        set {
            this.descriptionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, DataType="ID")]
    public string Id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class FileType {
    
    private AvailabilityType availabilityField;
    
    private KeyType[] descriptionField;
    
    private string filenameField;
    
    private string mimetypeField;
    
    private string relPathField;
    
    private string absPathField;
    
    private string uRLField;
    
    private string idField;
    
    /// <remarks/>
    public AvailabilityType Availability {
        get {
            return this.availabilityField;
        }
        set {
            this.availabilityField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Key", IsNullable=false)]
    public KeyType[] Description {
        get {
            return this.descriptionField;
        }
        set {
            this.descriptionField = value;
        }
    }
    
    /// <remarks/>
    public string filename {
        get {
            return this.filenameField;
        }
        set {
            this.filenameField = value;
        }
    }
    
    /// <remarks/>
    public string mimetype {
        get {
            return this.mimetypeField;
        }
        set {
            this.mimetypeField = value;
        }
    }
    
    /// <remarks/>
    public string relPath {
        get {
            return this.relPathField;
        }
        set {
            this.relPathField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI")]
    public string absPath {
        get {
            return this.absPathField;
        }
        set {
            this.absPathField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI")]
    public string URL {
        get {
            return this.uRLField;
        }
        set {
            this.uRLField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, DataType="ID")]
    public string Id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class AvailabilityType {
    
    private bool availableField;
    
    private string[] uRLField;
    
    private string copyrightField;
    
    private KeyType[] obtainingInformationField;
    
    /// <remarks/>
    public bool Available {
        get {
            return this.availableField;
        }
        set {
            this.availableField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("URL", DataType="anyURI")]
    public string[] URL {
        get {
            return this.uRLField;
        }
        set {
            this.uRLField = value;
        }
    }
    
    /// <remarks/>
    public string Copyright {
        get {
            return this.copyrightField;
        }
        set {
            this.copyrightField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Key", IsNullable=false)]
    public KeyType[] ObtainingInformation {
        get {
            return this.obtainingInformationField;
        }
        set {
            this.obtainingInformationField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class KeyType {
    
    private string nameField;
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
    public string Name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class DescriptionType {
    
    private KeyType[] keyField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Key")]
    public KeyType[] Key {
        get {
            return this.keyField;
        }
        set {
            this.keyField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class LanguageType {
    
    private string languageCodeField;
    
    private KeyType[] descriptionField;
    
    private string typeField;
    
    /// <remarks/>
    public string LanguageCode {
        get {
            return this.languageCodeField;
        }
        set {
            this.languageCodeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Key", IsNullable=false)]
    public KeyType[] Description {
        get {
            return this.descriptionField;
        }
        set {
            this.descriptionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
    public string Type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class LocationType {
    
    private string streetField;
    
    private string cityField;
    
    private string postalCodeField;
    
    private string countryField;
    
    private PeriodType periodField;
    
    private KeyType[] descriptionField;
    
    private string typeField;
    
    /// <remarks/>
    public string Street {
        get {
            return this.streetField;
        }
        set {
            this.streetField = value;
        }
    }
    
    /// <remarks/>
    public string City {
        get {
            return this.cityField;
        }
        set {
            this.cityField = value;
        }
    }
    
    /// <remarks/>
    public string PostalCode {
        get {
            return this.postalCodeField;
        }
        set {
            this.postalCodeField = value;
        }
    }
    
    /// <remarks/>
    public string Country {
        get {
            return this.countryField;
        }
        set {
            this.countryField = value;
        }
    }
    
    /// <remarks/>
    public PeriodType Period {
        get {
            return this.periodField;
        }
        set {
            this.periodField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Key", IsNullable=false)]
    public KeyType[] Description {
        get {
            return this.descriptionField;
        }
        set {
            this.descriptionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
    public string Type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class PeriodType {
    
    private System.DateTime periodStartField;
    
    private bool periodStartFieldSpecified;
    
    private bool periodExactField;
    
    private bool periodExactFieldSpecified;
    
    private long periodDurationField;
    
    private bool periodDurationFieldSpecified;
    
    /// <remarks/>
    public System.DateTime PeriodStart {
        get {
            return this.periodStartField;
        }
        set {
            this.periodStartField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool PeriodStartSpecified {
        get {
            return this.periodStartFieldSpecified;
        }
        set {
            this.periodStartFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public bool PeriodExact {
        get {
            return this.periodExactField;
        }
        set {
            this.periodExactField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool PeriodExactSpecified {
        get {
            return this.periodExactFieldSpecified;
        }
        set {
            this.periodExactFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public long PeriodDuration {
        get {
            return this.periodDurationField;
        }
        set {
            this.periodDurationField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool PeriodDurationSpecified {
        get {
            return this.periodDurationFieldSpecified;
        }
        set {
            this.periodDurationFieldSpecified = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class RecordingType {
    
    private string nameField;
    
    private KeyType[] descriptionField;
    
    private MediaType[] mediaField;
    
    private FileType[] fileField;
    
    private System.DateTime recordingDateTimeField;
    
    private bool recordingDateTimeFieldSpecified;
    
    private long recordingDurationField;
    
    private bool recordingDurationFieldSpecified;
    
    private AvailabilityType availabliltyField;
    
    private string idField;
    
    /// <remarks/>
    public string Name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Key", IsNullable=false)]
    public KeyType[] Description {
        get {
            return this.descriptionField;
        }
        set {
            this.descriptionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Media")]
    public MediaType[] Media {
        get {
            return this.mediaField;
        }
        set {
            this.mediaField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("File")]
    public FileType[] File {
        get {
            return this.fileField;
        }
        set {
            this.fileField = value;
        }
    }
    
    /// <remarks/>
    public System.DateTime RecordingDateTime {
        get {
            return this.recordingDateTimeField;
        }
        set {
            this.recordingDateTimeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool RecordingDateTimeSpecified {
        get {
            return this.recordingDateTimeFieldSpecified;
        }
        set {
            this.recordingDateTimeFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public long RecordingDuration {
        get {
            return this.recordingDurationField;
        }
        set {
            this.recordingDurationField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool RecordingDurationSpecified {
        get {
            return this.recordingDurationFieldSpecified;
        }
        set {
            this.recordingDurationFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public AvailabilityType Availablilty {
        get {
            return this.availabliltyField;
        }
        set {
            this.availabliltyField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, DataType="ID")]
    public string Id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class MediaType {
    
    private KeyType[] descriptionField;
    
    private string fileStoreField;
    
    private object filenameField;
    
    private string nSLinkField;
    
    private System.DateTime lastBackupField;
    
    private bool lastBackupFieldSpecified;
    
    private AvailabilityType availabilityField;
    
    private string idField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Key", IsNullable=false)]
    public KeyType[] Description {
        get {
            return this.descriptionField;
        }
        set {
            this.descriptionField = value;
        }
    }
    
    /// <remarks/>
    public string FileStore {
        get {
            return this.fileStoreField;
        }
        set {
            this.fileStoreField = value;
        }
    }
    
    /// <remarks/>
    public object Filename {
        get {
            return this.filenameField;
        }
        set {
            this.filenameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI")]
    public string NSLink {
        get {
            return this.nSLinkField;
        }
        set {
            this.nSLinkField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
    public System.DateTime LastBackup {
        get {
            return this.lastBackupField;
        }
        set {
            this.lastBackupField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool LastBackupSpecified {
        get {
            return this.lastBackupFieldSpecified;
        }
        set {
            this.lastBackupFieldSpecified = value;
        }
    }
    
    /// <remarks/>
    public AvailabilityType Availability {
        get {
            return this.availabilityField;
        }
        set {
            this.availabilityField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, DataType="ID")]
    public string Id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class CommunicationTypeSetting : SettingType {
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class SettingType {
    
    private object[] itemsField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Description", typeof(DescriptionType))]
    [System.Xml.Serialization.XmlElementAttribute("Object", typeof(ObjectType))]
    [System.Xml.Serialization.XmlElementAttribute("Person", typeof(string), DataType="IDREF")]
    public object[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class ObjectType {
    
    private string nameField;
    
    private KeyType[] descriptionField;
    
    private AvailabilityType availabilityField;
    
    private string idField;
    
    /// <remarks/>
    public string Name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Key", IsNullable=false)]
    public KeyType[] Description {
        get {
            return this.descriptionField;
        }
        set {
            this.descriptionField = value;
        }
    }
    
    /// <remarks/>
    public AvailabilityType Availability {
        get {
            return this.availabilityField;
        }
        set {
            this.availabilityField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, DataType="ID")]
    public string Id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class TranscriptionType {
    
    private object nameField;
    
    private FileType fileField;
    
    private string fileStoreField;
    
    private object filenameField;
    
    private string nSLinkField;
    
    private KeyType[] descriptionField;
    
    private AvailabilityType availabilityField;
    
    private AnnotationType annotationField;
    
    private string idField;
    
    /// <remarks/>
    public object Name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    public FileType File {
        get {
            return this.fileField;
        }
        set {
            this.fileField = value;
        }
    }
    
    /// <remarks/>
    public string FileStore {
        get {
            return this.fileStoreField;
        }
        set {
            this.fileStoreField = value;
        }
    }
    
    /// <remarks/>
    public object Filename {
        get {
            return this.filenameField;
        }
        set {
            this.filenameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI")]
    public string NSLink {
        get {
            return this.nSLinkField;
        }
        set {
            this.nSLinkField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Key", IsNullable=false)]
    public KeyType[] Description {
        get {
            return this.descriptionField;
        }
        set {
            this.descriptionField = value;
        }
    }
    
    /// <remarks/>
    public AvailabilityType Availability {
        get {
            return this.availabilityField;
        }
        set {
            this.availabilityField = value;
        }
    }
    
    /// <remarks/>
    public AnnotationType Annotation {
        get {
            return this.annotationField;
        }
        set {
            this.annotationField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, DataType="ID")]
    public string Id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class AnnotationType {
    
    private KeyType[] descriptionField;
    
    private FileType fileField;
    
    private string idField;
    
    private string nameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("Key", IsNullable=false)]
    public KeyType[] Description {
        get {
            return this.descriptionField;
        }
        set {
            this.descriptionField = value;
        }
    }
    
    /// <remarks/>
    public FileType File {
        get {
            return this.fileField;
        }
        set {
            this.fileField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, DataType="ID")]
    public string Id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
    public string Name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class PersonType {
    
    private object[] itemsField;
    
    private ItemsChoiceType[] itemsElementNameField;
    
    private string idField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AsocFile", typeof(AsocFileType))]
    [System.Xml.Serialization.XmlElementAttribute("Description", typeof(DescriptionType))]
    [System.Xml.Serialization.XmlElementAttribute("KnownHuman", typeof(bool))]
    [System.Xml.Serialization.XmlElementAttribute("Language", typeof(LanguageType))]
    [System.Xml.Serialization.XmlElementAttribute("Location", typeof(LocationType))]
    [System.Xml.Serialization.XmlElementAttribute("Pseudo", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("Sex", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("Sigle", typeof(string))]
    [System.Xml.Serialization.XmlElementAttribute("role", typeof(roleType))]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    public object[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public ItemsChoiceType[] ItemsElementName {
        get {
            return this.itemsElementNameField;
        }
        set {
            this.itemsElementNameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, DataType="ID")]
    public string Id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class roleType {
    
    private DescriptionType[] itemsField;
    
    private string typeField;
    
    private string targetField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Description")]
    public DescriptionType[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
    public string Type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified, DataType="IDREF")]
    public string target {
        get {
            return this.targetField;
        }
        set {
            this.targetField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema=false)]
public enum ItemsChoiceType {
    
    /// <remarks/>
    AsocFile,
    
    /// <remarks/>
    Description,
    
    /// <remarks/>
    KnownHuman,
    
    /// <remarks/>
    Language,
    
    /// <remarks/>
    Location,
    
    /// <remarks/>
    Pseudo,
    
    /// <remarks/>
    Sex,
    
    /// <remarks/>
    Sigle,
    
    /// <remarks/>
    role,
}
