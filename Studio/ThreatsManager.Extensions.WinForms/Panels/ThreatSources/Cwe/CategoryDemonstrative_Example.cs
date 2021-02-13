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
namespace ThreatsManager.Extensions.Panels.ThreatSources.Cwe
{
    /// <summary>
/// This element illustrates how this weakness may
/// look in actual code. It contains an Intro_Text element
/// describing the context in which this code should be viewed, an
/// Example_Body element which is a mixture of code and explanatory
/// text, and Demonstrative_Example_References that provide
/// additional information.
/// </summary>
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
[Serializable]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(AnonymousType=true)]
public partial class CategoryDemonstrative_Example
{
    #region Private fields
    private string _intro_Text;
    private Structured_Text_Type _example_Body;
    private List<Reference_Type> _demonstrative_Example_References;
    private string _demonstrative_Example_ID;
    #endregion
    
    /// <summary>
    /// CategoryDemonstrative_Example class constructor
    /// </summary>
    public CategoryDemonstrative_Example()
    {
        _demonstrative_Example_References = new List<Reference_Type>();
        _example_Body = new Structured_Text_Type();
    }
    
    /// <summary>
    /// This element describes the context and
    /// setting surrounding the example to add clarity for
    /// the reader.
    /// </summary>
    public string Intro_Text
    {
        get
        {
            return _intro_Text;
        }
        set
        {
            _intro_Text = value;
        }
    }
    
    /// <summary>
    /// This element consists of a
    /// Structured_Text element which should hold the code
    /// and some explanatory information for the
    /// reader.
    /// </summary>
    public Structured_Text_Type Example_Body
    {
        get
        {
            return _example_Body;
        }
        set
        {
            _example_Body = value;
        }
    }
    
    /// <summary>
    /// The Demonstrative_Example_References
    /// element contains one or more Reference elements,
    /// each of which provide further reading and insight
    /// into this demonstrative example. This should be
    /// filled out when appropriate.
    /// </summary>
    [XmlArrayItem("Reference", IsNullable=false)]
    public List<Reference_Type> Demonstrative_Example_References
    {
        get
        {
            return _demonstrative_Example_References;
        }
        set
        {
            _demonstrative_Example_References = value;
        }
    }
    
    /// <summary>
    /// The Demonstrative_Example_ID stores the
    /// value for the related Demonstrative_Example entry
    /// identifier as a string. Only one
    /// Demonstrative_Example_ID element can exist for each
    /// Demonstrative_Example element (ex: DX-1). However,
    /// Demonstrative_Examples across CWE with the same ID
    /// should only vary in small details.
    /// </summary>
    [XmlAttribute]
    public string Demonstrative_Example_ID
    {
        get
        {
            return _demonstrative_Example_ID;
        }
        set
        {
            _demonstrative_Example_ID = value;
        }
    }
}
}
#pragma warning restore
