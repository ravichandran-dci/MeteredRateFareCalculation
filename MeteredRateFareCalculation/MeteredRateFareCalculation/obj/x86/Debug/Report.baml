   M S B A M L   `   `   `  ����U  QMeteredRateFareCalculation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:MeteredRateFareCalculation.Utility"MeteredRateFareCalculation.Utility  5   	   '    !MeteredRateFareCalculation.Report   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   >m0clr-namespace:MeteredRateFareCalculation.Utility     5   	     � Title$  Fare Report��5   	   $	��380��6   $	��550��6*   $	��300��66   $	��550��6F    � WindowStartupLocation$ CenterScreen=�6U    J� Opacity$	 0.8Q�6z   .��5      � $��2q�6   
������� � RowDefinitions 5   
   �� 5	      $	��42* �6   �� 5
      $	��42* �6   �� 5      $	��42* �6   �� 5      $	��42* �6   �� 5      $	��42* �6   �� 5      $	��42* �6   �� 5      $	��42* �6   �� 5      $	��42* �6   �� 5      $	��60* �6    � ColumnDefinitions 5   
   �� 5      $
��391* �6   �� 5      $
��133* �6   .+�5   
   �� -   5        $��lblMinimumFare��5   C      SideLabelControlStyle#��[  6   Minimum Fare :6i   �� 5   
   -   5        $��lblMinutesFare��5   P   #��[  6   $��1��6C   42Fare for {0} minutes traveled at 12 mph or above :6�   �� 5   
   -   5        $��lblMilesFare��5   P   #��[  6   $��2��6C   <:Fare for {0} miles traveled while traveling below 12 mph :6�   �� 5   
   -   5        $��lblNightSurcharge��5   i   #��[  6   $��3��6C   $��Night Surcharge :��6P   6i   �� 5   
   -   5        $��lblPeakHourSurcharge��5   u   #��[  6   $��4��6C   $#��Peak hour Weekday Surcharge :��6P   6u   �� 5   
   -   5        $��lblNewYorkSurcharge��5   v   #��[  6   $��5��6C   $$��New York State Tax Surcharge :��6P   6v   �� 5   
   -   5        $��lblTotalFare��5   �   #��[  6   $��6��6C   $��Total Fare :��6P   $��Right=�6d   
����d�$
��Bold"�6�   �� 5   
   -   5        $��btnClose��5   .   $��Close��6   $��8��6!   $��Center=�6U   $��Center=�6r   $��
221,5,88,5q�6�   $��82��6�   $��35��6�   �� 5!   
   -	   5        $��lblMinimumFareValue��5!   N     ReportValueStyle#��[ 6   $��1��6>   {0} $6p   �� 5"   
   -
   5        $��lblMinutesFareValue��5"   [   #��[ 6   $��1��6>   $��1��6K   {0} $6}   �� 5#   
   -   5        $��lblMilesFareValue��5#   [   #��[ 6   $��2��6>   $��1��6K   {0} $6{   �� 5$   
   -   5        $��lblNightSurchargeValue��5$   [   #��[ 6   $��3��6>   $��1��6K   {0} $6�   �� 5%   
   -   5        $��lblPeakHourSurchargeValue��5%   [   #��[ 6   $��4��6>   $��1��6K   {0} $6�   �� 5&   
   -   5        $��lblNewYorkSurchargeValue��5&   [   #��[ 6   $��5��6>   $��1��6K   {0} $6�   �� 5'   
   -   5        $��lblTotalFareValue��5'   [   #��[ 6   $��6��6>   $��1��6K   
����d�$
��Bold"�6�   {0} $6�   5)      5*      