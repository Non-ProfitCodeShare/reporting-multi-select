using Blackbaud.AppFx.UIModeling.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSKCC.CustomFx.ReportingMultiSelect.UIModel 
{
    public class MultiSelect : MultiSelectParametersUIModel
    {
        // TODO: Build classes for recognition filter, transaction type, application type        

#region "Revenue filters"
        public new void UpdatesForAllRevenueTypeSelector()
        {
            UIModelCollection<MultiSelectParametersREVENUEFILTERSUIModel> uiModelCollection = this.REVENUEFILTERS.Value;
            uiModelCollection.Clear();
            IEnumerator<ValueListItem<System.String>> enumerator;
            enumerator = this.REVENUEFILTERS.DefaultItem.REVENUEFILTER.DataSource.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    //ValueListItem<MultiSelectParametersTRANSACTIONTYPESUIModel.TRANSACTIONTYPES?> current = enumerator.Current;
                    var current = enumerator.Current;
                    if (current.Visible)
                        uiModelCollection.Add(new MultiSelectParametersREVENUEFILTERSUIModel()
                        {
                            REVENUEFILTER =
                            {
                                Value = current.Value.ToString()
                            }
                        });
                }
            }
            finally
            {
                if (enumerator != null)
                    enumerator.Dispose();
            }
        }
        public new void _selectrevenuefilters_InvokeAction(object sender, ShowCustomFormEventArgs e)
        {
            // collection of payment method indicator
            CollectionField<MultiSelectFormCOLLECTIONITEMSUIModel> revenueFilters = ((MultiSelectFormUIModel)e.Model).COLLECTIONITEMS;

            // enumerator for payment methods
            IEnumerator<ValueListItem<System.String>> enumerator;
            enumerator = this.REVENUEFILTERS.DefaultItem.REVENUEFILTER.DataSource.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    var current = enumerator.Current;
                    if (current.Visible)
                        revenueFilters.Value.Add(new MultiSelectFormCOLLECTIONITEMSUIModel()
                        {
                            COLLECTIONITEM =
                            {
                                Value = current.Translation
                            },
                            SELECTED =
                            {
                                //Value = this.TransactionTypeIsSelected((MultiSelectParametersTRANSACTIONTYPESUIModel.TRANSACTIONTYPES)current.Value)
                                Value = true

                            }
                        });
                }
            }
            finally
            {
                if (enumerator != null)
                    enumerator.Dispose();
            }
        }
#endregion

#region "Transaction types"
        public new void UpdatesForAllTransactionTypeSelector()
        {            
            UIModelCollection<MultiSelectParametersTRANSACTIONTYPESUIModel> uiModelCollection = this.TRANSACTIONTYPES.Value;
            uiModelCollection.Clear();
            IEnumerator<ValueListItem<MultiSelectParametersTRANSACTIONTYPESUIModel.TRANSACTIONTYPES?>> enumerator;
            enumerator = this.TRANSACTIONTYPES.DefaultItem.TRANSACTIONTYPE.DataSource.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    ValueListItem<MultiSelectParametersTRANSACTIONTYPESUIModel.TRANSACTIONTYPES?> current = enumerator.Current;
                    if (current.Visible)
                        uiModelCollection.Add(new MultiSelectParametersTRANSACTIONTYPESUIModel()
                        {
                            TRANSACTIONTYPE =
                            {
                                Value = current.Value
                            }
                        });
                }
            }
            finally
            {
                if (enumerator != null)
                    enumerator.Dispose();                    
            }
            
        }
        public new string UpdateTransactionTypesString()
        {
            // string variable to hold full string
            StringBuilder str = new StringBuilder();

            //var enumerator = _paymentmethods.DefaultItem.PAYMENTMETHOD.DataSource.GetEnumerator();
            var enumerator = this.TRANSACTIONTYPES.Value.GetEnumerator();
            while (enumerator.MoveNext())
            {
                //str.Append(enumerator.Current.Value.ToString());
                str.Append(enumerator.Current.TRANSACTIONTYPE.Value.ToString());
            }

            //this._paymentmethodstring.Value = str.ToString();
            return str.ToString();
        }
        private new bool TransactionTypeIsSelected(MultiSelectParametersTRANSACTIONTYPESUIModel.TRANSACTIONTYPES transactionTypes)
        {
            IEnumerator<MultiSelectParametersTRANSACTIONTYPESUIModel> enumerator;
            enumerator = this.TRANSACTIONTYPES.Value.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    MultiSelectParametersTRANSACTIONTYPESUIModel current = enumerator.Current;
                    int num = (int)transactionTypes;
                    MultiSelectParametersTRANSACTIONTYPESUIModel.TRANSACTIONTYPES? nullable1 = current.TRANSACTIONTYPE.Value;
                    int? nullable2 = nullable1.HasValue ? new int?((int)nullable1.GetValueOrDefault()) : new int?();
                    if ((nullable2.HasValue ? new bool?(nullable2.GetValueOrDefault() == num) : new bool?()).GetValueOrDefault())
                        return true;
                }
            }
            finally
            {
                if (enumerator != null)
                    enumerator.Dispose();
            }
            return false;
        }
        public new void _selecttransactiontypes_InvokeAction(object sender, ShowCustomFormEventArgs e)
        {
            // collection of payment method indicator
            CollectionField<MultiSelectFormCOLLECTIONITEMSUIModel> transactionTypes = ((MultiSelectFormUIModel)e.Model).COLLECTIONITEMS;

            // enumerator for payment methods
            IEnumerator<ValueListItem<MultiSelectParametersTRANSACTIONTYPESUIModel.TRANSACTIONTYPES?>> enumerator; 
            enumerator = this.TRANSACTIONTYPES.DefaultItem.TRANSACTIONTYPE.DataSource.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    ValueListItem<MultiSelectParametersTRANSACTIONTYPESUIModel.TRANSACTIONTYPES?> current = enumerator.Current;
                    if (current.Visible)
                        transactionTypes.Value.Add(new MultiSelectFormCOLLECTIONITEMSUIModel()
                        {
                            COLLECTIONITEM =
                            {
                                Value = current.Translation
                            },
                            SELECTED =
                            {
                                Value = this.TransactionTypeIsSelected((MultiSelectParametersTRANSACTIONTYPESUIModel.TRANSACTIONTYPES)current.Value)
                                
                            }
                        });
                }
            }
            finally
            {
                if (enumerator != null)
                    enumerator.Dispose();
            }
        }
        public new void _selecttransactiontypes_CustomFormConfirmed(object sender, CustomFormConfirmedEventArgs e)
        {
            CollectionField<MultiSelectFormCOLLECTIONITEMSUIModel> transactionTypes = ((MultiSelectFormUIModel)e.Model).COLLECTIONITEMS;
            UIModelCollection<MultiSelectParametersTRANSACTIONTYPESUIModel> uiModelCollection = this.TRANSACTIONTYPES.Value;
            ValueListItemCollection<MultiSelectParametersTRANSACTIONTYPESUIModel.TRANSACTIONTYPES?> dataSource = this.TRANSACTIONTYPES.DefaultItem.TRANSACTIONTYPE.DataSource;
            uiModelCollection.Clear();
            int num1 = 0;
            int num2 = checked(transactionTypes.Value.Count - 1);
            int index = num1;
            while (index <= num2)
            {
                if (transactionTypes.Value[index].SELECTED.Value)
                    uiModelCollection.Add(new MultiSelectParametersTRANSACTIONTYPESUIModel()
                    {
                        TRANSACTIONTYPE =
                        {
                            Value = dataSource[index].Value
                        }
                    });
                checked { ++index; }
            }            
        }
#endregion

#region "Constructors"
        public MultiSelect() { }
#endregion
    }
}
