// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code++. Version 4.2.0.44
//  </auto-generated>
// ------------------------------------------------------------------------------

using System;
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
public partial class Attack_PatternTypeIndicatorWarning_of_Attack
{
    #region Private fields
    private Structured_Text_Type _description;
    private ObservablesType2 _observables;
    #endregion
    
    /// <summary>
    /// Attack_PatternTypeIndicatorWarning_of_Attack class constructor
    /// </summary>
    public Attack_PatternTypeIndicatorWarning_of_Attack()
    {
        _observables = new ObservablesType2();
        _description = new Structured_Text_Type();
    }
    
    /// <summary>
    /// This element represents a detailed description of an attack pattern. Content may include a summary and a list of steps taken by the attacker. USAGE: This element can be used to capture a range of descriptive information. Comprehensive descriptions might include attack trees, exploit graphs, etc., to more clearly elaborate this type of attack.
    /// </summary>
    public Structured_Text_Type Description
    {
        get => _description;
        set => _description = value;
    }
    
    /// <summary>
    /// This element specifies detailed cyber observable patterns for potential detection of the probing technique activity.
    /// </summary>
    public ObservablesType2 Observables
    {
        get => _observables;
        set => _observables = value;
    }
}
}
#pragma warning restore
