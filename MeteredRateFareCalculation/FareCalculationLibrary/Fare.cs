/****************************************************************************************************
 * Copyright © Dot Com Infoway. All rights reserved.      
 * 
 * Created By : Ravichandran
 * Created Date : 30-Aug-2013
 * Purpose : Provides an entity for fare calculation result.
 * 
 * Change History
 * Updated By       Updated Date        Purpose/Changes made
 * Ravichandran     30-Aug-2013         Initial Version
 * ***************************************************************************************************/

#region Assemblies
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

#region Namespace
namespace FareCalculationLibrary
{
    #region Fare
    /// <summary>
    /// An entity - Fare to hold calculated fare.
    /// </summary>
    public class Fare
    {
        #region Private Properties
        /// <summary>
        /// Gets the minimum fare
        /// </summary>
        public Double MinimumFare { get; private set; }
        /// <summary>
        /// Gets the fare for one fifth of mile
        /// </summary>
        public Double OneFifthOfMileFare { get; private set; }
        /// <summary>
        /// Gets the fare for minutes travelled at 12 mph or above.
        /// </summary>
        public Double AdditionalFare { get; private set; }
        /// <summary>
        /// Gets Night Surcharge for the given journey start datetime.
        /// </summary>
        public Double NightSurcharge { get; private set; }
        /// <summary>
        /// Gets Peak hour Weekday Surcharge for the given journey start datetime.
        /// </summary>
        public Double PeakHourSurcharge { get; private set; }
        /// <summary>
        /// Gets Newyork State Tax Surcharge.
        /// </summary>
        public Double NewyorkStateTaxSurcharge { get; private set; }
        #endregion


        #region Constructor
        /// <summary>
        /// Initialises Fare entity with the supplied value.
        /// </summary>
        /// <param name="minimumFare">Minimum fare.</param>
        /// <param name="oneFifthOfMileFare">Fare for number of miles traveled below 12 mph.</param>
        /// <param name="additionalFare">Fare for number of minutes traveled at 12mph or above.</param>
        /// <param name="nightSurcharge">Night Surcharge for after 8:00 PM & before 6:00 AM.</param>
        /// <param name="peakHourSurcharge">Peak hour Weekday Surcharge on Monday - Friday after 4:00 PM & before 8:00 PM.</param>
        /// <param name="newyorkStateTaxSurcharge">New York State Tax Surcharge.</param>
        public Fare(Double minimumFare, Double oneFifthOfMileFare, Double additionalFare, Double nightSurcharge, Double peakHourSurcharge, Double newyorkStateTaxSurcharge)
        {
            MinimumFare = minimumFare;
            OneFifthOfMileFare = oneFifthOfMileFare;
            AdditionalFare = additionalFare;
            NightSurcharge = nightSurcharge;
            PeakHourSurcharge = peakHourSurcharge;
            NewyorkStateTaxSurcharge = newyorkStateTaxSurcharge;
        }
        #endregion

    }
    #endregion
}
#endregion
