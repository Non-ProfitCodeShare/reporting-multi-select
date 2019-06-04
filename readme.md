# Multi Select Parameters in Blackbaud CRM

Using C# solution to create reusable multi-select parameters in Blackbaud UI model

![Alt text](/img/selector.png "Transaction Types selector")

![Alt text](/img/TransactionTypesMultiSelect.png "Multi select form")

The multi-select paramteter will return a pipe delimited string of the selections Caption or Description field.

Ex. "Payment|Pledge|Recurring Gift"

The below steps outlines the steps used to create the transaction types multi-select parameter in the Example data list spec

## Steps to creating parameter

These steps only need to be done once for each multi-select parameter

1. Create a CustomUI xml spec with a field for each option as a boolean data type and a string field for the delimited values

    ```xml
    <FormField FieldID="Payment" Caption="Payment" DataType="Boolean"  />
    <FormField FieldID="Pledge" Caption="Pledge" DataType="Boolean" />
    <FormField FieldID="RecurringGift" Caption="Recurring Gift" DataType="Boolean"/>
    <FormField FieldID="MatchingGift" Caption="Matching Gift" DataType="Boolean" />
    <FormField FieldID="TransactionTypesDelimited" DataType="String" />
    ```

2. Add two actions

    ```xml
    <UIActions>
        <UIAction ActionID="SelectAll" Caption="Select all" />
        <UIAction ActionID="UnselectAll" Caption="Unselect all" />
    </UIActions>
    ```

3. Create a Custom UI Model from the spec
4. In the code gen file create a global class member for a List\<BooleanField\>

    ```C#
    private global::System.Collections.Generic.List<BooleanField> _transactionTypes;
    ```

5. In the constructor method for the class add each field to the member

    ```C#
    _transactionTypes = new global::System.Collections.Generic.List<BooleanField>();
    _transactionTypes.Add(this._payment);
    _transactionTypes.Add(this._pledge);
    _transactionTypes.Add(this._recurringgift);
    _transactionTypes.Add(this._matchinggift);
    ```

6. Adds methods for "select all" and "unselect all" actions. The UpdateAll method is in the solution already.

    ```C#
    private void _selectall_InvokeAction(object sender, InvokeActionEventArgs e)
    {
        MultiSelectFunctions.UpdateAll(ref _transactionTypes, true);
    }
    private void _unselectall_InvokeAction(object sender, InvokeActionEventArgs e)
    {
        MultiSelectFunctions.UpdateAll(ref _transactionTypes, false);
    }
    ```

    Add event handlers to the _Loaded method

    ```C#
    // adds select all / unselect event handlers
    EventHandler<InvokeActionEventArgs> eventHandler1 = new EventHandler<InvokeActionEventArgs>(this._selectall_InvokeAction);
    EventHandler<InvokeActionEventArgs> eventHandler2 = new EventHandler<InvokeActionEventArgs>(this._unselectall_InvokeAction);

    this._selectall.InvokeAction += eventHandler1;
    this._unselectall.InvokeAction += eventHandler2;  
    ```

7. Add method to form validated to create delimited string

    ```C#
    private void _form_validated(object sender, Blackbaud.AppFx.UIModeling.Core.ValidatedEventArgs e)
    {
        this._transactiontypesdelimited.Value = MultiSelectFunctions.BuildPipeDelimitedString(_transactionTypes);
    }
    ```

    Add event handlers to the _Loaded method

    ```C#
    // adds form validated arguments
    EventHandler<ValidatedEventArgs> eh3 = new EventHandler<ValidatedEventArgs>(this._form_validated);
    this.Validated += eh3;
    ```

8. Script for _Loaded to handle currently selected values when form is created

    ```C#
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
    ```

## Steps to use parameters

1. In the spec create UI fields for the parameter as a string and a value list to use as a selector

    ```xml
    <FormField FieldID="transactiontypes" Caption="Transaction types" DataType="String" AvailableToClient="false" />
    <FormField FieldID="transactiontypesselector" Caption="Transaction types" DefaultValueText="0" Required="true" Enable="False" >
        <ValueList>
        <Items>
            <Item>
            <Value>0</Value>
            <Label>All transaction types</Label>
            </Item>
            <Item>
            <Value>1</Value>
            <Label>Selected transaction types</Label>
            </Item>
        </Items>
        </ValueList>
    </FormField>
    ```

2. Add an action to show the custom UI form created above and link it

    ```xml
    <UIAction ActionID="ShowTransactionTypesForm" ImageKey="res:editsmall" AvailableToClient="false">
        <ShowCustomForm LinkedFieldId="transactiontypes">
        <ModelComponent AssemblyName="ReportingMultiSelect.UIModel.dll" ClassName="ReportingMultiSelect.UIModel.MultiSelectTransactionTypesUIModel" />
        </ShowCustomForm>
    </UIAction>
    ```

3. Add methods to UI class for handle showing and confirming the form. These methods pass the string value between the two forms

    ```c#
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
    ```

4. Add event handlers to the UI actions

    ```C#
    // adds event handler for confirming transaction types form
    EventHandler<CustomFormConfirmedEventArgs> eh = new EventHandler<CustomFormConfirmedEventArgs>(this._showtransactiontypesform_CustomFormConfirmed);
    _showtransactiontypesform.CustomFormConfirmed += eh;

    // adds event handler for showing transaction types form
    EventHandler<ShowCustomFormEventArgs> eh2 = new EventHandler<ShowCustomFormEventArgs>(this._showtransactiontypesform_ShowCustomForm);
    _showtransactiontypesform.InvokeAction += eh2;

    // adds event handler for transaction types enabler
    EventHandler<ValueChangedEventArgs> eh3 = new EventHandler<ValueChangedEventArgs>(this._transactiontypesselector_ValueChanged);
    _transactiontypesselector.ValueChanged += eh3;
    ```

5. Create custom javascript action to handle enable/disable/auto-show for the form.

    ```javascript
    (function (c, d) {
        var e, b, a;
        b = "SHOWTRANSACTIONTYPESFORM";
        a = BBUI.forms.Utility;
        c.on("formupdated", function (h) {
            var i, g, j, f;
            j = h.formUpdateResult;
            g = a.findActionInFormUpdateResult(j, b, d);
            if (g) {
                if (g.enabled) {
                    i = e
                }
            }
            if (i) {
                c.invokeAction(d, i)
            }
        })
    })();
    ```
