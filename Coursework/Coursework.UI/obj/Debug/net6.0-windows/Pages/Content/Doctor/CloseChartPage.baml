   M S B A M L   `   `   `  ����H  DCoursework.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:Coursework.UI.Pages.Content.Doctor"Coursework.UI.Pages.Content.Doctor  5      7    1Coursework.UI.Pages.Content.Doctor.CloseChartPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:Coursework.UI.Pages.Content.Doctor     5        N� Title$  CloseChartPage��5       � 	Resources 5	       �� 
TargetType �� Property �� Value��%�   '��       �� 5
   
   " ��6   .�5      ��  � ��$ 25(�6)   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$ 10q�6'   5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   �� -   5         ��Name$ Charts��5   C   $��0��6   $��Center=�6   ��5      �� 5      .R�5      �� $��4q�6!   $��Center=�6,   .+�5      ��  �� Orientation$ 
Horizontal=�6%   $��Center=�6>   $��2q�6[   .+�5      �� $��25(�6$   $��Болезнь:   ��62   6J   �� 5      $��25(�6$   ��62   ��  �� Path$ IllnessTitle�6Z   5      �� 5      $ 
Horizontal=�6%   $��Center=�6>   $��2q�6[   .+�5      �� $��25(�6$   $!��ФИО пациента:   ��62   6O   �� 5       $��25(�6$   ��62   �� $ 
PatientFIO�6X   5!      �� 5"      $ 
Horizontal=�6%   $��Center=�6>   $��2q�6[   .+�5#      �� $��25(�6$   $!��Номер палаты:   ��62   6O   �� 5$      $��25(�6$   ��62   �� $ ChanberNumber�6[   5%      �� 5&      $ 
Horizontal=�6%   $��Center=�6>   $��2q�6[   .+�5'      �� $��25(�6$   $��Начало:   ��62   6I   �� 5(      $��25(�6$   ��62   �� $ Start�6S   5)      �� 5*      $ 
Horizontal=�6%   $��Center=�6>   $��2q�6[   .+�5+      �� $��25(�6$   $��Конец:   ��62   6H   �� 5,      $��25(�6$   ��62   �� $ Finish�6T   5-      �� 5.      $ 
Horizontal=�6%   $��Center=�6>   $��2q�6[   .+�5/      �� $��25(�6$   $��Содержание:   ��62   6M   �� 50      $��65��6&   	 �� 
IsReadOnly$
	 True��65   
 �� TextWrapping$

 Wrap=�6G   $��25(�6[   ��6i   �� $ Content�6�   51      52      53      55      � 56   
   $��1��6   $��Center=�6   $��Center=�69   .+�57      �� $ Vertical=�6   $��Center=�60   $��2q�6M   .+�58      �� -   5        $��Close��58      $��Закрыть��6:   ${�False��6L   6`   59      5:      5;      5<      