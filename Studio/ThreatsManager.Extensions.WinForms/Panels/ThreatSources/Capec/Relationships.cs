// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code++. Version 4.2.0.44
//  </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

#pragma warning disable
namespace ThreatsManager.Extensions.Panels.ThreatSources.Capec
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
[Serializable]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(AnonymousType=true, Namespace="http://capec.mitre.org/capec-2")]
[XmlRoot(Namespace="http://capec.mitre.org/capec-2", IsNullable=false)]
public partial class Relationships
{
    #region Private fields
    private List<RelationshipType> _relationship;
    #endregion
    
    /// <summary>
    /// Relationships class constructor
    /// </summary>
    public Relationships()
    {
        _relationship = new List<RelationshipType>();
    }
    
    [XmlElement("Relationship")]
    public List<RelationshipType> Relationship
    {
        get => _relationship;
        set => _relationship = value;
    }
}
}
#pragma warning restore
