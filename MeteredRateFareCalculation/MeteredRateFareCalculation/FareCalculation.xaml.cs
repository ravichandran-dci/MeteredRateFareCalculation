/****************************************************************************************************
 * Copyright © Dot Com Infoway. All rights reserved.      
 * 
 * Created By : Ravichandran
 * Created Date : 29-Aug-2013
 * Purpose : User Interface for Metered Rate Fare Calculation.
 * 
 * Change History
 * Updated By       Updated Date        Purpose/Changes made
 * Ravichandran     29-Aug-2013         Initial Version
 * ***************************************************************************************************/

#region Assemblies
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FareCalculationLibrary;
#endregion

#region Namespace
namespace MeteredRateFareCalculation
{
    /// <summary>
    /// Interaction logic for FareCalculation.xaml
    /// </summary>
    public partial class FareCalculation : Window
    {
        #region DataContext

        Travel objTravel = new Travel();

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes the controls
        /// </summary>
        public FareCalculation()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles Window loaded event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Initializing DataContext with default values.
            objTravel.NumberOfMinutesTraveled = 0;
            objTravel.NumberOfMilesTraveled = 0;
            objTravel.JourneyStartDateTime = DateTime.Now;
            objTravel.JourneyStartTime = DateTime.Now.ToString("HH:mm");
            this.DataContext = objTravel;

        }
        /// <summary>
        /// Handles Calculate button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.objTravel.Error))
            {
                MessageBox.Show("Please correct the below errors." + Environment.NewLine + Environment.NewLine + this.objTravel.Error);
            }
            else
            {
                Travel objTravel = this.DataContext as Travel;
                Double totalFare = objTravel.CalculateFare();
                MessageBox.Show("Total Fare: " + totalFare.ToString());
                //using (Travel objTravel = new Travel(5, 2, DateTime.Now.AddHours(-4)))
                //{
                //    Double totalFare = objTravel.CalculateFare();
                //    MessageBox.Show("Total Fare: " + totalFare.ToString());
                //}
            }
        }
        #endregion
    }
}
#endregion
