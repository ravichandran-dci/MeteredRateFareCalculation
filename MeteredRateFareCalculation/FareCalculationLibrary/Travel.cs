/****************************************************************************************************
 * Copyright © Dot Com Infoway. All rights reserved.      
 * 
 * Created By : Ravichandran
 * Created Date : 28-Aug-2013
 * Purpose : Provides an entity with data validation for metered rate fare calculation.
 * 
 * Change History
 * Updated By       Updated Date        Purpose/Changes made
 * Ravichandran     28-Aug-2013         Initial Version
 * Ravichandran     29-Aug-2013         Implemented IDataErrorInfo and INotifyPropertyChanged interfaces for data validation
 * ***************************************************************************************************/

#region Assemblies

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

#endregion

#region Namespace
namespace FareCalculationLibrary
{
    #region Travel Entity
    /// <summary>
    /// Travel entity
    /// </summary>
    public class Travel : IDisposable, IDataErrorInfo, INotifyPropertyChanged
    {
        #region Private Members

        private Int32? _numberOfMinutesTraveled;
        private Int32? _numberOfMilesTraveled;
        private DateTime? _journeyStartDateTime;
        private String _journeyStartTime;

        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or Sets the Number of minutes traveled at 12 mph or above.
        /// </summary>
        public Int32? NumberOfMinutesTraveled
        {
            get { return _numberOfMinutesTraveled; }
            set
            {
                _numberOfMinutesTraveled = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("NumberOfMinutesTraveled"));
            }
        }
        /// <summary>
        /// Gets or Sets the Number of miles traveled below 12 mph.
        /// </summary>
        public Int32? NumberOfMilesTraveled
        {
            get { return _numberOfMilesTraveled; }
            set
            {
                _numberOfMilesTraveled = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("NumberOfMilesTraveled"));
            }
        }
        /// <summary>
        /// Gets or Sets the Start Date and Time of a journey.
        /// </summary>
        public DateTime? JourneyStartDateTime
        {
            get { return _journeyStartDateTime; }
            set
            {
                _journeyStartDateTime = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("JourneyStartDateTime"));
            }
        }
        /// <summary>
        /// Gets or Sets the Start Time of a journey.
        /// </summary>
        public String JourneyStartTime
        {
            get { return _journeyStartTime; }
            set
            {
                _journeyStartTime = FormatToTimeString(value);
                this.OnPropertyChanged(new PropertyChangedEventArgs("JourneyStartTime"));
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor - creates a new instance of this object.
        /// </summary>
        public Travel() { }
        /// <summary>
        /// Initializes properties of Travel entity
        /// </summary>
        /// <param name="numberOfMinutes">Number of minutes traveled at 12 mph or above.</param>
        /// <param name="numberOfMiles">Number of miles traveled below 12 mph.</param>
        /// <param name="dtJourneyStart">Start Date and Time of a journey. Combine the date and time of journey start.</param>
        public Travel(Int32 numberOfMinutes, Int32 numberOfMiles, DateTime dtJourneyStart, String strStartTime)
        {
            NumberOfMinutesTraveled = numberOfMinutes;
            NumberOfMilesTraveled = numberOfMiles;
            JourneyStartDateTime = dtJourneyStart;
            JourneyStartTime = strStartTime;
        }
        #endregion

        #region Private Properties
        /// <summary>
        /// Gets the fare for one fifth of mile
        /// </summary>
        private Double OneFifthOfMileFare
        {
            get { return (NumberOfMilesTraveled == null ? 0 : (Int32)NumberOfMilesTraveled) * 5 * GlobalConstants.AdditionalFarePerunit; }
        }
        /// <summary>
        /// Gets the fare for minutes travelled at 12 mph or above.
        /// </summary>
        private Double AdditionalFare
        {
            get { return (NumberOfMinutesTraveled == null ? 0 : (Int32)NumberOfMinutesTraveled) * GlobalConstants.AdditionalFarePerunit; }
        }
        /// <summary>
        /// Gets Night Surcharge for the given journey start datetime.
        /// </summary>
        private Double NightSurcharge
        {
            get
            {
                DateTime startDateTime = (JourneyStartDateTime == null ? DateTime.Now : (DateTime)JourneyStartDateTime);
                if (startDateTime.CompareTo(startDateTime.Date.Add(GlobalConstants.NightTimeStart)) >= 0 || startDateTime.CompareTo(startDateTime.Date.Add(GlobalConstants.NightTimeEnd)) < 0)
                { return GlobalConstants.NightSurcharge; }
                else
                { return 0; }
            }
        }
        /// <summary>
        /// Gets Peak hour Weekday Surcharge for the given journey start datetime.
        /// </summary>
        private Double PeakHourSurcharge
        {
            get
            {
                DateTime startDateTime = (JourneyStartDateTime == null ? DateTime.Now : (DateTime)JourneyStartDateTime);
                if (startDateTime.DayOfWeek != DayOfWeek.Saturday && startDateTime.DayOfWeek != DayOfWeek.Sunday)
                {
                    if (startDateTime.CompareTo(startDateTime.Date.Add(GlobalConstants.WeekdayPeekHourTimeStart)) >= 0 && startDateTime.CompareTo(startDateTime.Date.Add(GlobalConstants.WeekdayPeekHourTimeEnd)) < 0)
                    { return GlobalConstants.WeekdayPeekHourSurcharge; }
                    else { return 0; }
                }
                else { return 0; }
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Calculates the total fare including surcharge.
        /// </summary>
        public Double CalculateFare()
        {
            return GlobalConstants.StartFare + OneFifthOfMileFare + AdditionalFare + NightSurcharge + PeakHourSurcharge + GlobalConstants.NewyorkStateTaxSurcharge;
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Dispose resource and frees up memory occupied by this instance.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion

        #region IDataErrorInfo Members

        public string Error
        {
            get { return this[null]; }
        }

        public string this[string propertyName]
        {
            get
            {
                string result = string.Empty;
                propertyName = propertyName ?? string.Empty;
                if (propertyName == string.Empty || propertyName == "NumberOfMinutesTraveled")
                {
                    if (string.IsNullOrEmpty(this.NumberOfMinutesTraveled.ToString()))
                    {
                        result += "- Number of Minutes is mandatory." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "NumberOfMilesTraveled")
                {
                    if (string.IsNullOrEmpty(this.NumberOfMilesTraveled.ToString()))
                    {
                        result += "- Number of Miles is mandatory." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "JourneyStartDateTime")
                {
                    if (string.IsNullOrEmpty(this.JourneyStartDateTime.ToString()))
                    {
                        result += "- Date is mandatory." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "JourneyStartTime")
                {
                    if (string.IsNullOrEmpty(this.JourneyStartTime))
                    {
                        result += "- Time is mandatory." + Environment.NewLine;
                    }
                    else
                    {
                        TimeSpan tsStartTime;
                        if (TimeSpan.TryParse(JourneyStartTime, out tsStartTime))
                        {
                            if (tsStartTime.Days == 0)
                            {
                                _journeyStartTime = DateTime.Now.Date.Add(tsStartTime).ToString("HH:mm");
                            }
                            else
                            { result += "- Time is invalid. Enter in 24 hrs format." + Environment.NewLine + "Eg:- 15:25, 00:01" + Environment.NewLine; }
                        }
                        else
                        { result += "- Time is invalid. Enter in 24 hrs format." + Environment.NewLine + "Eg:- 15:25, 00:01" + Environment.NewLine; }
                    }
                }

                return result.TrimEnd();
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, e);
            }
        }

        #endregion

        #region Helper Methods
        /// <summary>
        /// Format the given value to Time format string if it could be parsed. Otherwise returns the given same input.
        /// </summary>
        /// <param name="inputTime"></param>
        /// <returns></returns>
        private string FormatToTimeString(string inputTime)
        {
            if (!String.IsNullOrEmpty(inputTime))
            {
                inputTime = inputTime.Replace(".", ":");

                TimeSpan tsFormatTime;
                if (TimeSpan.TryParse(inputTime, out tsFormatTime))
                {
                    if (tsFormatTime.Days == 0)
                    {
                        inputTime = DateTime.Now.Date.Add(tsFormatTime).ToString("HH:mm");
                    }
                }
            }
            return inputTime;
        }
        #endregion
    }
    #endregion
}
#endregion