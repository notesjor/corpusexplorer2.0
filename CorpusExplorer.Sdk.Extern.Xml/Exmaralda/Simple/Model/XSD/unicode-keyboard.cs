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
[System.Xml.Serialization.XmlRootAttribute("unicode-keyboard", Namespace="", IsNullable=false)]
public partial class unicodekeyboard {
    
    private key[] keyField;
    
    private string nameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("key")]
    public key[] key {
        get {
            return this.keyField;
        }
        set {
            this.keyField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
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
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class key {
    
    private string contentField;
    
    private string descriptionField;
    
    private font fontField;
    
    /// <remarks/>
    public string content {
        get {
            return this.contentField;
        }
        set {
            this.contentField = value;
        }
    }
    
    /// <remarks/>
    public string description {
        get {
            return this.descriptionField;
        }
        set {
            this.descriptionField = value;
        }
    }
    
    /// <remarks/>
    public font font {
        get {
            return this.fontField;
        }
        set {
            this.fontField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class font {
    
    private string nameField;
    
    private fontSize sizeField;
    
    private fontFace faceField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public fontSize size {
        get {
            return this.sizeField;
        }
        set {
            this.sizeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public fontFace face {
        get {
            return this.faceField;
        }
        set {
            this.faceField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public enum fontSize {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("3")]
    Item3,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("4")]
    Item4,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("5")]
    Item5,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("6")]
    Item6,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("7")]
    Item7,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("8")]
    Item8,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("9")]
    Item9,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("10")]
    Item10,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("11")]
    Item11,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("12")]
    Item12,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("13")]
    Item13,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("14")]
    Item14,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("15")]
    Item15,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("16")]
    Item16,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("17")]
    Item17,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("18")]
    Item18,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("19")]
    Item19,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("20")]
    Item20,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("21")]
    Item21,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("22")]
    Item22,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("23")]
    Item23,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("24")]
    Item24,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("25")]
    Item25,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("26")]
    Item26,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("27")]
    Item27,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("28")]
    Item28,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("29")]
    Item29,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("30")]
    Item30,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("31")]
    Item31,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("32")]
    Item32,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("33")]
    Item33,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("34")]
    Item34,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("35")]
    Item35,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("36")]
    Item36,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("37")]
    Item37,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("38")]
    Item38,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("39")]
    Item39,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("40")]
    Item40,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("41")]
    Item41,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("42")]
    Item42,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("43")]
    Item43,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("44")]
    Item44,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("45")]
    Item45,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("46")]
    Item46,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("47")]
    Item47,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("48")]
    Item48,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("72")]
    Item72,
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public enum fontFace {
    
    /// <remarks/>
    plain,
    
    /// <remarks/>
    bold,
    
    /// <remarks/>
    italic,
}