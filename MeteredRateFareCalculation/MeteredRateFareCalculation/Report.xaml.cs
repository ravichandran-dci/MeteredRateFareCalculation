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

namespace MeteredRateFareCalculation
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        public Report()
        {
            InitializeComponent();
        }

        public Report(Fare objFareReport, Int32 numberOfMilesTraveled, Int32 numberOfMinutesTraveled)
        {
            InitializeComponent();

            lblMinutesFare.Text = String.Format(lblMinutesFare.Text, numberOfMinutesTraveled);
            lblMilesFare.Text = String.Format(lblMilesFare.Text, numberOfMilesTraveled);
            lblMinimumFareValue.Text = String.Format(lblMinimumFareValue.Text, objFareReport.MinimumFare);
            lblMinutesFareValue.Text = String.Format(lblMinutesFareValue.Text, objFareReport.AdditionalFare);
            lblMilesFareValue.Text = String.Format(lblMilesFareValue.Text, objFareReport.OneFifthOfMileFare);
            lblNightSurchargeValue.Text = String.Format(lblNightSurchargeValue.Text, objFareReport.NightSurcharge);
            lblPeakHourSurchargeValue.Text = String.Format(lblPeakHourSurchargeValue.Text, objFareReport.PeakHourSurcharge);
            lblNewYorkSurchargeValue.Text = String.Format(lblNewYorkSurchargeValue.Text, objFareReport.NewyorkStateTaxSurcharge);
            lblTotalFareValue.Text = String.Format(lblTotalFareValue.Text, objFareReport.MinimumFare + objFareReport.AdditionalFare + objFareReport.OneFifthOfMileFare + objFareReport.NightSurcharge + objFareReport.PeakHourSurcharge + objFareReport.NewyorkStateTaxSurcharge);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
