/****************************************************************************************************
 * Copyright © Dot Com Infoway. All rights reserved.      
 * 
 * Created By : Ravichandran
 * Created Date : 28-Aug-2013
 * Purpose : Provides predefined values used globally accross this class library.
 * 
 * Change History
 * Updated By       Updated Date        Purpose/Changes made
 * Ravichandran     28-Aug-2013         Initial Version
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
    #region GlobalConstants
    /// <summary>
    /// Global Constants.
    /// </summary>
    public class GlobalConstants
    {
        #region Declarations
        
        internal static Double StartFare = 3.00;
        internal static Double AdditionalFarePerunit = 0.35;
        internal static Double NightSurcharge = 0.50;
        internal static TimeSpan NightTimeStart = new TimeSpan(20, 0, 0);
        internal static TimeSpan NightTimeEnd = new TimeSpan(6, 0, 0);
        internal static Double WeekdayPeekHourSurcharge = 1.00;
        internal static TimeSpan WeekdayPeekHourTimeStart = new TimeSpan(16, 0, 0);
        internal static TimeSpan WeekdayPeekHourTimeEnd = new TimeSpan(20, 0, 0);
        internal static Double NewyorkStateTaxSurcharge = 0.50;

        #endregion
    }
    #endregion
}
#endregion
