﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by BBUIModelLibrary
//     Version:  4.0.173.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Collections.Generic;
using Blackbaud.AppFx.UIModeling.Core;
namespace ReportingMultiSelect.UIModel
{

/// <summary>
/// Represents the UI model for the 'Multi Select Applications' data form
/// </summary>
public partial class @MultiSelectApplicationsUIModel : global::Blackbaud.AppFx.UIModeling.Core.CustomUIModel
{

#region "Extensibility methods"

	partial void OnCreated();

#endregion

    private global::Blackbaud.AppFx.UIModeling.Core.BooleanField _donation;
    private global::Blackbaud.AppFx.UIModeling.Core.BooleanField _eventregistration;
    private global::Blackbaud.AppFx.UIModeling.Core.BooleanField _matchinggift;
    private global::Blackbaud.AppFx.UIModeling.Core.BooleanField _plannedgift;
    private global::Blackbaud.AppFx.UIModeling.Core.BooleanField _pledge;
    private global::Blackbaud.AppFx.UIModeling.Core.BooleanField _recurringgift;
    private global::Blackbaud.AppFx.UIModeling.Core.BooleanField _other;
    private global::Blackbaud.AppFx.UIModeling.Core.StringField _applicationsdelimited;
    private global::Blackbaud.AppFx.UIModeling.Core.GenericUIAction _selectall;
    private global::Blackbaud.AppFx.UIModeling.Core.GenericUIAction _unselect;
    private global::System.Collections.Generic.List<BooleanField> _applications;

	[System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.173.0")]
	public @MultiSelectApplicationsUIModel() : base()
	{


        _donation = new global::Blackbaud.AppFx.UIModeling.Core.BooleanField();
        _eventregistration = new global::Blackbaud.AppFx.UIModeling.Core.BooleanField();
        _matchinggift = new global::Blackbaud.AppFx.UIModeling.Core.BooleanField();
        _plannedgift = new global::Blackbaud.AppFx.UIModeling.Core.BooleanField();
        _pledge = new global::Blackbaud.AppFx.UIModeling.Core.BooleanField();
        _recurringgift = new global::Blackbaud.AppFx.UIModeling.Core.BooleanField();
        _other = new global::Blackbaud.AppFx.UIModeling.Core.BooleanField();
        _applicationsdelimited = new global::Blackbaud.AppFx.UIModeling.Core.StringField();
        _selectall = new global::Blackbaud.AppFx.UIModeling.Core.GenericUIAction();
        _unselect = new global::Blackbaud.AppFx.UIModeling.Core.GenericUIAction();
        _applications = new global::System.Collections.Generic.List<BooleanField>();

        this.FORMHEADER.Value = "Select applications";
        this.UserInterfaceUrl = "browser/htmlforms/custom/reportingmultiselect/MultiSelectApplications.html";

        //
        //_donation
        //
        _donation.Name = "DONATION";
        _donation.Caption = "Donation";
        this.Fields.Add(_donation);
        //
        //_eventregistration
        //
        _eventregistration.Name = "EVENTREGISTRATION";
        _eventregistration.Caption = "Event registration";
        this.Fields.Add(_eventregistration);
        //
        //_matchinggift
        //
        _matchinggift.Name = "MATCHINGGIFT";
        _matchinggift.Caption = "Matching gift";
        this.Fields.Add(_matchinggift);
        //
        //_plannedgift
        //
        _plannedgift.Name = "PLANNEDGIFT";
        _plannedgift.Caption = "Planned gift";
        this.Fields.Add(_plannedgift);
        //
        //_pledge
        //
        _pledge.Name = "PLEDGE";
        _pledge.Caption = "Pledge";
        this.Fields.Add(_pledge);
        //
        //_recurringgift
        //
        _recurringgift.Name = "RECURRINGGIFT";
        _recurringgift.Caption = "Recurring gift";
        this.Fields.Add(_recurringgift);
        //
        //_other
        //
        _other.Name = "OTHER";
        _other.Caption = "Other";
        this.Fields.Add(_other);
        //
        //_applicationsdelimited
        //
        _applicationsdelimited.Name = "APPLICATIONSDELIMITED";
        _applicationsdelimited.Caption = "APPLICATIONSDELIMITED";
        this.Fields.Add(_applicationsdelimited);
        //
        //_selectall
        //
        _selectall.Name = "SELECTALL";
        _selectall.Caption = "Select all";
        this.Actions.Add(_selectall);
        //
        //_unselect
        //
        _unselect.Name = "UNSELECT";
        _unselect.Caption = "Unselect all";
        this.Actions.Add(_unselect);

        _applications.Add(_donation);
        _applications.Add(_eventregistration);
        _applications.Add(_matchinggift);
        _applications.Add(_plannedgift);
        _applications.Add(_pledge);
        _applications.Add(_recurringgift);
        _applications.Add(_other);

		OnCreated();

	}

    /// <summary>
    /// Donation
    /// </summary>
    [System.ComponentModel.Description("Donation")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.173.0")]
	public global::Blackbaud.AppFx.UIModeling.Core.BooleanField @DONATION {
		get { return _donation; }
	}

    /// <summary>
    /// Event registration
    /// </summary>
    [System.ComponentModel.Description("Event registration")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.173.0")]
	public global::Blackbaud.AppFx.UIModeling.Core.BooleanField @EVENTREGISTRATION {
		get { return _eventregistration; }
	}

    /// <summary>
    /// Matching gift
    /// </summary>
    [System.ComponentModel.Description("Matching gift")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.173.0")]
	public global::Blackbaud.AppFx.UIModeling.Core.BooleanField @MATCHINGGIFT {
		get { return _matchinggift; }
	}

    /// <summary>
    /// Planned gift
    /// </summary>
    [System.ComponentModel.Description("Planned gift")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.173.0")]
	public global::Blackbaud.AppFx.UIModeling.Core.BooleanField @PLANNEDGIFT {
		get { return _plannedgift; }
	}

    /// <summary>
    /// Pledge
    /// </summary>
    [System.ComponentModel.Description("Pledge")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.173.0")]
	public global::Blackbaud.AppFx.UIModeling.Core.BooleanField @PLEDGE {
		get { return _pledge; }
	}

    /// <summary>
    /// Recurring gift
    /// </summary>
    [System.ComponentModel.Description("Recurring gift")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.173.0")]
	public global::Blackbaud.AppFx.UIModeling.Core.BooleanField @RECURRINGGIFT {
		get { return _recurringgift; }
	}

    /// <summary>
    /// Other
    /// </summary>
    [System.ComponentModel.Description("Other")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.173.0")]
	public global::Blackbaud.AppFx.UIModeling.Core.BooleanField @OTHER {
		get { return _other; }
	}

    [System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.173.0")]
	public global::Blackbaud.AppFx.UIModeling.Core.StringField @APPLICATIONSDELIMITED {
		get { return _applicationsdelimited; }
	}

    /// <summary>
    /// Select all
    /// </summary>
    [System.ComponentModel.Description("Select all")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.173.0")]
	public global::Blackbaud.AppFx.UIModeling.Core.GenericUIAction @SELECTALL {
		get { return _selectall; }
	}

    /// <summary>
    /// Unselect all
    /// </summary>
    [System.ComponentModel.Description("Unselect all")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "4.0.173.0")]
	public global::Blackbaud.AppFx.UIModeling.Core.GenericUIAction @UNSELECT {
		get { return _unselect; }
	}

}

}