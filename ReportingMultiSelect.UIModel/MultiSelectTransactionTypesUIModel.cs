using Blackbaud.AppFx.UIModeling.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ReportingMultiSelect.UIModel 
{

	public partial class MultiSelectTransactionTypesUIModel
	{

        private void _form_validated(object sender, Blackbaud.AppFx.UIModeling.Core.ValidatedEventArgs e)
        {
            this._transactiontypesdelimited.Value = MultiSelectFunctions.BuildPipeDelimitedString(_transactionTypes);            
        }  

        private void _selectall_InvokeAction(object sender, InvokeActionEventArgs e)
        {
            MultiSelectFunctions.UpdateAll(ref _transactionTypes, true);
        }
        private void _unselectall_InvokeAction(object sender, InvokeActionEventArgs e)
        {
            MultiSelectFunctions.UpdateAll(ref _transactionTypes, false);
        }

		private void MultiSelectTransactionTypesUIModel_Loaded(object sender, Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs e)
		{

            // adds select all / unselect event handlers 
            EventHandler<InvokeActionEventArgs> eventHandler1 = new EventHandler<InvokeActionEventArgs>(this._selectall_InvokeAction);
            EventHandler<InvokeActionEventArgs> eventHandler2 = new EventHandler<InvokeActionEventArgs>(this._unselectall_InvokeAction);

            this._selectall.InvokeAction += eventHandler1;
            this._unselectall.InvokeAction += eventHandler2;            
            
            // adds form validated arguments
            EventHandler<ValidatedEventArgs> eh3 = new EventHandler<ValidatedEventArgs>(this._form_validated);
            this.Validated += eh3;

            if (this._transactiontypesdelimited.Value != null)
            {
                foreach (string type in this._transactiontypesdelimited.Value.Split('|'))
                {
                    foreach (BooleanField bf in this._transactionTypes)
                    {
                        if (bf.Caption == type)
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
			this.Loaded += MultiSelectTransactionTypesUIModel_Loaded;            
		}

#endregion

	}

}