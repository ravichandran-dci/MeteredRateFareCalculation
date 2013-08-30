/****************************************************************************************************
 * Copyright © Dot Com Infoway. All rights reserved.      
 * 
 * Created By : Ravichandran
 * Created Date : 30-Aug-2013
 * Purpose : Provides properties and methods for Mask Textbox. Integer or Decimal value type is validated here.
 * 
 * Change History
 * Updated By       Updated Date        Purpose/Changes made
 * Ravichandran     30-Aug-2013         Initial Version
 * ***************************************************************************************************/

#region Assemblies
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
#endregion

#region Namespace
namespace MeteredRateFareCalculation.Utility
{
    #region MaskTextBox
    public class MaskTextBox
    {
        #region Mask Property

        #region GetMask
        /// <summary>
        /// Gets the Mask Type
        /// </summary>
        /// <param name="obj">DependencyObject</param>
        /// <returns>MaskType</returns>
        public static MaskType GetMask(DependencyObject obj)
        {
            return (MaskType)obj.GetValue(MaskProperty);
        }
        #endregion

        #region SetMask
        /// <summary>
        /// Sets the Mask type
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetMask(DependencyObject obj, MaskType value)
        {
            obj.SetValue(MaskProperty, value);
        }
        #endregion

        #region MaskProperty
        /// <summary>
        /// Dependency Property for Mask Type Property
        /// </summary>
        public static readonly DependencyProperty MaskProperty =
            DependencyProperty.RegisterAttached(
                "Mask",
                typeof(MaskType),
                typeof(MaskTextBox),
                new FrameworkPropertyMetadata(MaskChangedCallback)
                );
        #endregion

        #region MaskChangedCallback
        /// <summary>
        /// Callback function when Mask Type is changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void MaskChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue is TextBox)
            {
                (e.OldValue as TextBox).PreviewTextInput -= TextBox_PreviewTextInput;
                DataObject.RemovePastingHandler((e.OldValue as TextBox), (DataObjectPastingEventHandler)TextBoxPastingEventHandler);
            }

            TextBox _this = (d as TextBox);
            if (_this == null)
                return;

            if ((MaskType)e.NewValue != MaskType.Any)
            {
                _this.PreviewTextInput += TextBox_PreviewTextInput;
                DataObject.AddPastingHandler(_this, (DataObjectPastingEventHandler)TextBoxPastingEventHandler);
            }

            ValidateTextBox(_this);
        }
        #endregion

        #endregion

        #region Private Static Methods

        #region ValidateTextBox
        /// <summary>
        /// Method to Validate Textbox value
        /// </summary>
        /// <param name="_this"></param>
        private static void ValidateTextBox(TextBox _this)
        {
            if (GetMask(_this) != MaskType.Any)
            {
                _this.Text = ValidateValue(GetMask(_this), _this.Text);
            }
        }
        #endregion

        #region TextBoxPastingEventHandler
        /// <summary>
        /// Handler to Validate Textbox value while pasting
        /// </summary>
        private static void TextBoxPastingEventHandler(object sender, DataObjectPastingEventArgs e)
        {
            TextBox _this = (sender as TextBox);
            string clipboard = e.DataObject.GetData(typeof(string)) as string;
            clipboard = ValidateValue(GetMask(_this), clipboard);
            if (!string.IsNullOrEmpty(clipboard))
            {
                _this.Text = clipboard;
            }
            e.CancelCommand();
            e.Handled = true;
        }
        #endregion

        #region TextBox_PreviewTextInput
        /// <summary>
        /// Event to be raised while input the text
        /// </summary>
        private static void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            TextBox _this = (sender as TextBox);
            if (GetMask(_this) == MaskType.Integer)
            {
                try
                {
                    Convert.ToInt64(e.Text);
                }
                catch (Exception)
                {
                    _this.Text = _this.Text.Replace(e.Text, "");
                    _this.Select(_this.SelectionStart, 0);
                    e.Handled = true;
                }
            }
        }
        #endregion

        #region ValidateValue
        /// <summary>
        /// Validates the given value based on Mask Type, Minimum and Maximum values
        /// </summary>
        /// <param name="mask">The mask.</param>
        /// <param name="value">The value.</param>
        /// <returns>string</returns>
        private static string ValidateValue(MaskType mask, string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            value = value.Trim();
            switch (mask)
            {
                case MaskType.Integer:
                    Int32 outVal = 0;
                    if (Int32.TryParse(value, out outVal)) { return value; }
                    else { return string.Empty; }
                default:
                    return value;
            }
        }
        #endregion

        #endregion
    }
    #endregion

    #region Enumeration
    public enum MaskType
    {
        Any,
        Integer
    }
    #endregion
}
#endregion
