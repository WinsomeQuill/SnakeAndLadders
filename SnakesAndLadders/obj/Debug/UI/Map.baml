   M S B A M L   `   `   `  ����K  GSnakesAndLadders, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SnakesAndLaddersSnakesAndLadders  5   	       SnakesAndLadders.Map   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:SnakesAndLadders     5   	     � Title$	  Map��5   	   $	��840��5	   	   $	��840��5
   	   $	��840��5   	   $
��1100��5   	   $
��1200��5   	   $
��1300��5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��800 �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ ImageMap��5      $��0��5      $��0��5      � 5   
   -   5         �Name$ GridMap��5      $��0��5      �� 5   
   $��1��6   
�������$��5,0,0,0q�5      ._�5      �  � RowDefinitions 5       �� 5!      $	��290 �6$   �� 5"      �� 5#      $��40 �6$   �� 5$      .+�5'      �� -   5        $ ImageCubeIcon��5'      $	��170��5(      $	��170��5)      �� 5+      -   5         ��Name$ ButtonDiceNext��5+      $��0��5,      $��1��5-      $��40q�5.      $��Бросить кубик��5/      $��16(�50      $��Arial)�51      $��Black"�52      53      �� 55      -   5         ��Name$ TextBlockInformer��55      $��1��56      $��2��57      $��	15,0,15,0q�58      $��16(�59      $)��#Ходит игрок WinsomeQuill!��5:      $��Center=�5;      $��Arial)�5<      $
��Bold"�5=       J� Effect 5>      3  -System.Windows.Media.Effects.DropShadowEffect  5?         ShadowDepth$ 4Q�6+   	   	Direction$		 330Q�5@   +   
   Color$
 Black��5A   +      Opacity$	 0.5Q�5B   +      
BlurRadius$ 4Q�5C   +   5E      �� 5G      $��0��6   $��3��5H      $��7q�5I      .��5J      �� -   5        $ TextBlockLog��5J       $��14(�5K       5L      5M      5N      5O      5P      