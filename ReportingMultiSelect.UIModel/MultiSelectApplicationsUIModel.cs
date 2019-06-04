using Blackbaud.AppFx.UIModeling.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ReportingMultiSelect.UIModel
{

	public partial class MultiSelectApplicationsUIModel
	{
        private void _selectall_InvokeAction(object sender, InvokeActionEventArgs e)
        {
            MultiSelectFunctions.UpdateAll(ref _applications, true);
        }

        private void _unselectall_InvokeAction(object sender, InvokeActionEventArgs e)
        {
            MultiSelectFunctions.UpdateAll(ref _applications, false);
        }

        private void _form_Validated(object sender, ValidatedEventArgs e)
        {
            this._applicationsdelimited.Value = MultiSelectFunctions.BuildPipeDelimitedString(_applications);
        }

		private void MultiSelectApplicationsUIModel_Loaded(object sender, Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs e)
		{
            // adds select all / unselect all event handlers
            EventHandler<InvokeActionEventArgs> eh1 = new EventHandler<InvokeActionEventArgs>(this._selectall_InvokeAction);
            EventHandler<InvokeActionEventArgs> eh2 = new EventHandler<InvokeActionEventArgs>(this._unselectall_InvokeAction);

            this._selectall.InvokeAction += eh1;
            this._unselect.InvokeAction += eh2;

            // adds form validated arguments
            EventHandler<ValidatedEventArgs> eh3 = new EventHandler<ValidatedEventArgs>(this._form_Validated);
            this.Validated += eh3;

            if (this._applicationsdelimited.Value != null)
            {
                foreach (string application in this._applicationsdelimited.Value.Split('|'))
                {
                    foreach (BooleanField bf in this._applications)
                    {
                        if (bf.Caption == application)
                        {
                            bf.Value = true;
                        }
                    }
                }
            }
		}

#region "Event handlers"

		partial void OnCreated()
		{
			this.Loaded += MultiSelectApplicationsUIModel_Loaded;
		}

#endregion

	}

}