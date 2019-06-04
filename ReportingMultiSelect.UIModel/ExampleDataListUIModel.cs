using Blackbaud.AppFx.UIModeling.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace ReportingMultiSelect.UIModel
{

	public partial class ExampleDataListUIModel
	{
        #region "Transaction types multi-select"

        private void _showtransactiontypesform_CustomFormConfirmed(object sender, Blackbaud.AppFx.UIModeling.Core.CustomFormConfirmedEventArgs e)
        {
            this._transactiontypes.Value = (string)e.Model.Fields["TRANSACTIONTYPESDELIMITED"].ValueObject;
        }

        private void _showtransactiontypesform_ShowCustomForm(object sender, Blackbaud.AppFx.UIModeling.Core.ShowCustomFormEventArgs e)
        {
            if (this._transactiontypes.Value != null)
            {
                e.Model.Fields["TRANSACTIONTYPESDELIMITED"].ValueObject = (object)this._transactiontypes.Value;
            }
        }

        private void _transactiontypesselector_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (this._transactiontypesselector.Value == TRANSACTIONTYPESSELECTORS.AllTransactionTypes)
            {
                this._transactiontypes.Value = null;
                this._showtransactiontypesform.Enabled = false;
            }
            else
            {
                this._showtransactiontypesform.Enabled = true;
            }
        }

        #endregion

        #region "Applications multi-select"

        private void _showapplicationsform_CustomFormConfirmed(object sender, CustomFormConfirmedEventArgs e)
        {
            this._applications.Value = (string)e.Model.Fields["APPLICATIONSDELIMITED"].ValueObject;
        }

        private void _showapplicationsform_ShowCustomForm(object sender, ShowCustomFormEventArgs e)
        {
            if (this._applications.Value != null)
            {
                e.Model.Fields["APPLICATIONSDELIMITED"].ValueObject = (object)this._applications.Value;
            }
        }

        private void _applicationsselector_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (this._applicationsselector.Value == APPLICATIONSSELECTORS.AllApplications)
            {
                this._applications.Value = null;
                this._showapplicationsform.Enabled = false;
            }
            else
            {
                this._showapplicationsform.Enabled = true;
            }
        }

        #endregion 
		private void ExampleDataListUIModel_Loaded(object sender, Blackbaud.AppFx.UIModeling.Core.LoadedEventArgs e)
		{
            // adds event handler for confirming transaction types form
            EventHandler<CustomFormConfirmedEventArgs> eh = new EventHandler<CustomFormConfirmedEventArgs>(this._showtransactiontypesform_CustomFormConfirmed);
            _showtransactiontypesform.CustomFormConfirmed += eh;

            // adds event handler for showing transaction types form
            EventHandler<ShowCustomFormEventArgs> eh2 = new EventHandler<ShowCustomFormEventArgs>(this._showtransactiontypesform_ShowCustomForm);
            _showtransactiontypesform.InvokeAction += eh2;

            // adds event handler for transaction types enabler
            EventHandler<ValueChangedEventArgs> eh3 = new EventHandler<ValueChangedEventArgs>(this._transactiontypesselector_ValueChanged);
            _transactiontypesselector.ValueChanged += eh3;

            // add event handlers for applications multi-select
            EventHandler<CustomFormConfirmedEventArgs> eh4 = new EventHandler<CustomFormConfirmedEventArgs>(this._showapplicationsform_CustomFormConfirmed);
            _showapplicationsform.CustomFormConfirmed += eh4;

            EventHandler<ShowCustomFormEventArgs> eh5 = new EventHandler<ShowCustomFormEventArgs>(this._showapplicationsform_ShowCustomForm);
            _showapplicationsform.InvokeAction += eh5;

            EventHandler<ValueChangedEventArgs> eh6 = new EventHandler<ValueChangedEventArgs>(this._applicationsselector_ValueChanged);
            this._applicationsselector.ValueChanged += eh6;

		}

#region "Event handlers"

		partial void OnCreated()
		{
			this.Loaded += ExampleDataListUIModel_Loaded;
		}

#endregion

	}

}