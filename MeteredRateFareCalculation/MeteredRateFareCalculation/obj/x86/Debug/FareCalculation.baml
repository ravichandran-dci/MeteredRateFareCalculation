   M S B A M L   `   `   `  ����U  QMeteredRateFareCalculation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:MeteredRateFareCalculation.Utility"MeteredRateFareCalculation.Utility  5   	   0    *MeteredRateFareCalculation.FareCalculation   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   >m0clr-namespace:MeteredRateFareCalculation.Utility     5   	   -   5          � Title$  Fare Calculation��5   	   $	��300��6"   $	��550��6/   $	��300��6;   $	��550��6K    � WindowStartupLocation$ CenterScreen=�6Z    J� Opacity$ 1Q�6�   .��5      � $��2q�6   
������� � RowDefinitions 5   
   �� 5	      $	��42* �6   �� 5
      $	��42* �6   �� 5      $	��42* �6   �� 5      $	��42* �6   �� 5      $	��42* �6    � ColumnDefinitions 5   
   �� 5      $
��207* �6   �� 5      $
��317* �6   .+�5   
   ��    SideLabelControlStyle#��[  6   Number of minutes traveled :�� 6`   �� 6l     SubTitleHint#��[ 6p   .�6�   (at 12 mph or above)6�   6�   �� 5   
   #��[  6   $��1��6C   Number of miles traveled :�� 6k   �� 6w   #��[ 6{   .�6�    (while traveling below 12 mph)6�   6�   �� 5   
   #��[  6   $��2��6C   $��Date of start of ride :��6P   �� 5   
   #��[  6   $��3��6C   $��Time of start of ride :��6P   �� 5   
   -   5        $��txtNumberOfminutes��5   "   $��1��6    �� 	MaxLength$ 5��6�   4   .MeteredRateFareCalculation.Utility.MaskTextBox   Mask$ Integer=�6�   ��6<   ��  �� Path$ NumberOfMinutesTraveled� �� ValidatesOnDataErrors . 	 �� ValidatesOnExceptions	 . 
 �� TargetNullValue$
  ��6�   �� 5   
   -   5        $��txtNumberOfMiles��5   /   $��1��6   $��1��6   $ 5��6�   $ Integer=�6�   ��6G   �� $ NumberOfMilesTraveled� . $
  ��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpStartDate��5   3   $��2��6   $��1��6"      SelectedDate 6F   �� $ JourneyStartDateTime� . �� 5   
   -   5        $��txtStartTime��5   /   $��3��6   $��1��6   $ 5��6�   ��6C   �� $ JourneyStartTime� . 	 . $
  ��6�   �� 5   
   -   5        $��btnCalculate��5   G   $��Calculate Fare��6   $��1��6*   $��4��6:     ButtonControlStyle#��[ 6v   5      5      