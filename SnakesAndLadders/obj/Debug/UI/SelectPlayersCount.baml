   M S B A M L   `   `   `  ����K  GSnakesAndLadders, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SnakesAndLadders.UISnakesAndLadders.UI  5   	   ,    &SnakesAndLadders.UI.SelectPlayersCount   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:SnakesAndLadders.UI     5   	     � Title$)  #Количество игроков��5   	   $	��300��6$   $	��500��61    � 
ResizeMode$ CanMinimize=�6=    � 	Resources 5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $* $../Resources/Styles/Dictionary1.xaml?�6%   %    5      .��5      � ��5   
   �� 5       �� ImageSource$# ../Resources/Images/photo.jpg��6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� $#��../Resources/Images/Cloud.png��6   �� 5   
   $:��4Выберите количество игроков��6   $��0��66   $��Center=�6C   $��Center=�6^   $��16(�6{   �� 5   
   -   5         ��Name$ ComboBoxPlayersCount��5      $��1��61   $	��100��6>   $��30��6J   $��Center=�6V   $	��Top=�6x   .@�5      ��  �� 
IsSelected . .��5       �� 2 игрока6&   5!      �� 5"      .��5#      �� 3 игрока6&   5$      �� 5%      .��5&      �� 4 игрока6&   5'      5(      �� 5)   
   -   5        $
��Back��5)      $��35��6   $��35��6)   $
��Left=�65   $	��Top=�6P   
������ $��0q�6�   .��5*      �� ��5+      !� 5,      	 !� Source$"	 ../Resources/Images/Exit.png��6,   5.      5/      �� 51   
   -   5        $��Ok��51         launcher#��[  6   $��1��6@   6M   54      55      