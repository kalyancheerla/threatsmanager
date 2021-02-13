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
    /// <summary>
/// This element represents a detailed description of an attack pattern. Content may include a summary and a list of steps taken by the attacker. USAGE: This element can be used to capture a range of descriptive information. Comprehensive descriptions might include attack trees, exploit graphs, etc., to more clearly elaborate this type of attack.
/// </summary>
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
[Serializable]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(AnonymousType=true, Namespace="http://capec.mitre.org/capec-2")]
[XmlRoot(Namespace="http://capec.mitre.org/capec-2", IsNullable=false)]
public partial class Attack_Execution_Flow
{
    #region Private fields
    private List<Attack_Execution_FlowAttack_Phase> _attack_Phases;
    #endregion
    
    /// <summary>
    /// Attack_Execution_Flow class constructor
    /// </summary>
    public Attack_Execution_Flow()
    {
        _attack_Phases = new List<Attack_Execution_FlowAttack_Phase>();
    }
    
    [XmlArrayItem("Attack_Phase", IsNullable=false)]
    public List<Attack_Execution_FlowAttack_Phase> Attack_Phases
    {
        get => _attack_Phases;
        set => _attack_Phases = value;
    }
}
}
#pragma warning restore
