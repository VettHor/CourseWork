   M S B A M L   `   `   `  ����B  >Highway, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:HighwayHighway  5   	       Highway.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Highway     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962ac _MaterialDesignThemes.MahApps, Version=0.1.9.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	   $	��600��5      $
��1024��6'     � WindowStartupLocation$  CenterScreen=�64    � 
ResizeMode$ NoResize=�6Y    � WindowStyle$
 None=�6o    � Icon$ Assets/road.png��6�   .��5	      � -   5        ���	#FFEEEEEE.+�5
   
   �� $	��Top=�6   .+�5      � ���	#FFC00000$��10��6*   � 5      $��	300,5,5,5q�6   $��50��6&    � ColumnDefinitions 5      �� 5      $
��665* �6'   �� 5      $
��344* �6'   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�66   $��	0,0,9.8,0q�6R   $��1��6e   $	��170��6u   .+�5      �� -   5         ��Name$ Delete��5      $��60��6-   $��40��68   $��0q�6q   
���������6D   Z� ��6Z   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Delete=�62   $��40��6@   $��40��6K    � ToolTip 5      _� 5      $��25(�6&   $��Goudy Old Style)�64   .��6Q   Delete HighwayTable5      5      �� 5      -   5        $ AboutProgram��5      $��60��63   $��40��6>   $��0q�6w   
�������$��0 0 10 0q�6�   ��6J   Z� ��6`   Z� .��5        $ QuestionMarkCircle=�62   $��40��6L   $��40��6W    5      _� 5      $��25(�6&   $��Goudy Old Style)�64   .��6Q   About the program5      5!      �� 5"      -   5        $ ButtonFechar��5"      $��45��63   $��45��6>   $��0q�6w   
���������6J   Z� ��6`   Z� .��5#        $ Power=�62   $��45��6?   $��45��6J    5$      _� 5%      $��25(�6&   $��Goudy Old Style)�64   .��6Q   Turn off the app5'      5)      5*      �� 5+      $��Highways��6   $��Stretch=�6,   $��45(�6H   $��Goudy Old Style)�6V   $��175,0,124.4,0q�6s   5,      5-      � 5/   
   $��65,69,0,195q�6   .+�50      � -   5        	 �Name$	 GridPrincipal��50      $��Center=�6*   $��Center=�6G   �� 51      $��Hidden=�6   $��Hidden=�52      .��53         Highway.HighwayTable  -   5        
  Name$
 Table��53   %   $��1��64   $	��336��6A   $	��724��6N   $��Right=�6Z   $��Bottom=�6v   54      55      � 57   
   $��
65,410,0,0q�6   .+�58      � -   5        $	 PanelToMove��58      $��Center=�6(   $��Center=�6E   59      � 5;   
   -   5        $	 nav_pnl��5;      $	��297��6    $
��Left=�6,   ���	#FF222222.+�5<      �� $��0��5=   %   $��100,15,0,545q�5>   %   $��M E N U��5?   %   
�������$��30(�5A   %   
������ $
��Left=�5C   %   $��Center=�5D   %   $��40��6@   $	��115��6L    J� Effect 5E      3  -System.Windows.Media.Effects.DropShadowEffect  5F         
BlurRadius$ 10Q�6(      ShadowDepth$ 1Q�68      	Direction$	 -90Q�6H      Color$ White��6X   5H      d� 5K      -	   5         d�Name$ Tg_Btn��5K      $��0��5L   '   $��Center=�5M   '   $
��Left=�5N   '   $��10 -5 0 520q�5O   '   $��40��5P   '   $��40��5Q   '   $��0q�5R   '   .��5T      �� $��Assets/user-menu.png��6   $
��None=�66    � Triggers 5U      :� 5V       :� RoutedEvent$ ToggleButton.Checked��6#   .[�5W      �� .��5X      �� -
   5         ��Name$ ShowStackPanel��5X   )   .��5Y   "   W�  �� 
TargetName$ nav_pnl��5Z   1    �� TargetProperty$ Width�5[   1    g� 	BeginTime$ 0:0:0X�5\   1    W� From$ 65X�5]   1   	 W� To$	 297X�6;    g� Duration$ 0:0:0.3D�5^   1   5_   #   5`      5a      5b      :� 5c      $ ToggleButton.Unchecked��6#   .[�5d      �� .��5e      �� -   5        $ HideStackPanel��5e   )   .��5f   "   W� $ nav_pnl��5g   1   $ Width�5h   1   $ 0:0:0X�5i   1   $	 297X�5j   1   $ 65X�6<   $ 0:0:0.2D�5k   1   5l   #   5m      5n      5o      5q      �� 5s      $��Stretch=�6   ���	#FFC00000$��
0,71,0,522q�6G    J� RenderTransformOrigin$ 0.5,0.5&�6[   z�5t      V� 5u      .~�5v      ��  �� ScaleY$ -1Q�6)   �� 5w      �� 5x      T� 5y      5z      5|      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  5~      -   5          Name$ TrainsitionContentSlide��5~   2   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6S   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:0.2X�.��5      � -   5        $	 
GridCursor��5      $��	0 100 0 0q�6+   ���	#FFC00000$��8��6U   $
��Left=�6_   $��70��6z   $	��Top=�6�   5�      �� 5�      -   5         ��Name$ ListViewMenu��5�      $��	0,100,0,5q�6-   
�������$��Goudy Old Style)�6W   $��Disabled=�6�   .@�5�      �� $��70��6   .��5�      �� $ 
Horizontal=�6!   .+�5�        $ TrayArrowUp=�62   $��40��6E   $��40��6P   $��Center=�6\   $��5q�6w   �� 5�      $��	Open file��6$   $��25(�65   $��Center=�6C   $
��20 0q�6^   5�      5�      �� 5�      $��70��6   .��5�      �� $ 
Horizontal=�6!   .+�5�        $ TrayArrowDown=�62   $��40��6G   $��40��6R   $��Center=�6^   $��5q�6y   �� 5�      $��Save to file��6$   $��25(�68   $��Center=�6F   $
��20 0q�6a   5�      5�      �� 5�      $��70��6   .��5�      �� $ 
Horizontal=�6!   .+�5�        $
 Sort=�62   $��40��6>   $��40��6I   $��Center=�6U   $��5q�6p   �� 5�      $��Sort with road 
length��6$   $��25(�6F   $��Center=�6T   $
��20 0q�6o   5�      5�      �� 5�      $��70��6   .��5�      �� $ 
Horizontal=�6!   .+�5�        $ ViewWeek=�62   $��40��6B   $��40��6M   $��Center=�6Y   $��5q�6t   �� 5�      $(��"Shortest road with 
the most lanes��6$   $��25(�6R   $��Center=�6`   $
��20 0q�6{   5�      5�      �� 5�      $��70��6   .��5�      �� $ 
Horizontal=�6!   .+�5�        $ 	ValveOpen=�62   $��40��6C   $��40��6N   $��Center=�6Z   $��5q�6u   �� 5�      $#��Grouped roads 
with separator��6$   $��25(�6M   $��Center=�6[   $
��20 0q�6v   5�      5�      �� 5�      $��70��6   .��5�      �� $ 
Horizontal=�6!   .+�5�        $ HumanMaleFemaleChild=�62   $��40��6N   $��40��6Y   $��Center=�6e   $��5q�6�   �� 5�      $)��#Longest road types 
with crosswalks��6$   $��25(�6S   $��Center=�6a   $
��20 0q�6|   5�      5�      �� 5�      $��70��6   .��5�      �� $ 
Horizontal=�6!   .+�5�        $ Walker=�62   $��40��6@   $��40��6K   $��Center=�6W   $��5q�6r   �� 5�      $%��Regional roads with 
crosswalks��6$   $��25(�6O   $��Center=�6]   $
��20 0q�6x   5�      5�      5�      5�      5�      5�      