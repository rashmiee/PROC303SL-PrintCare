   M S B A M L   `   `   `  ����  PrintCareThirdTry    Print_Care.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6?   -   5          �Name$  Window��5       � Title$ 
MainWindow��5      $	��250��6   
���   ����	#FF17171A$	��450��6L    � WindowStartupLocation$ CenterScreen=�6X    � 
ResizeMode$ NoResize=�6}    � 	Resources 5         txtUserName �� 
TargetType �� Property �� Value �� 
TargetType  txtPassword��%�  &	        &	 �     �� 5	      " ��6   .�5
      ��  � �� 5      �� 5      " ��6   .R�5      � .+�5   	   �� ���	#FFF4F4F5
���   �6$   5   	   5      5      5      �� 5      " G�6   .�5      ��  � �� 5      �� 5      " G�6   .R�5      � .+�5   	   �� ���	#FFF4F4F5
���   �6$   5   	   5      5      5      5      	 J� Effect	 5       3  -System.Windows.Media.Effects.DropShadowEffect  5!      
   Opacity$

 0.95Q�6   .��5$      � -   5         �Name$ 
LayoutRoot��5$       J� Opacity$
 0.69Q�6   .+�5%      �� $
��Left=�6   $��15��6)   $��	34,42,0,0q�65   $
��Wrap=�6H   $��	User Name��6\   $	��Top=�6m   $��77��6�   ���	#FFFFF6F66�   �� 5&      $
��Left=�6   $��	34,92,0,0q�6)   $
��Wrap=�6<   $��Password��6P   $��77��6`   ���	#FFFFF6F6$��15��6�   $	��Top=�6�   G� 5'      $��147,92,70.447,104q�6   $��26��6+   $��1,4,1,1q�67   ��5(      �� 5)       �� EndPoint$
 0,20&�6    � MappingMode$ Absolute=�6*    �� 
StartPoint$	 0,0&�6A   .��5*      �  � Color$ White��6   � 5+      $ 	#FFE2E3EA��6   � 5,      $ White��6   5-      5/      �� 50      $��147,36,70.447,0q�6    �� TextWrapping$
 Wrap=�6%   $	��Top=�69   $��26��6Q   $��1,4,1,1q�6]   .��6w   ��51      �� 52      $ 0.5,1&�6   $ RelativeToBoundingBox=�6+   $ 0.5,0&�6O   .��53      � $ White��6   � 54      $ White��6   � 55      $ 	#FFFAFAFB��6   56      .��57      58      �� 59      $��Login��6   $��Right=�6   $��33��67   $��	0,0,32,30q�6C   $��Bottom=�6V   $	��100��6q   ���	#FF747478��5:      �� 5;      $	 0,1&�6   $	 0,0&�6)   .��5<      � $ 	#FFF3F3F3��6    � Offset$ 0Q�6&   � 5=      $ 	#FFEBEBEB��6   $	 0.5Q�6&   � 5>      $ 	#FFDDDDDD��6   $	 0.5Q�6&   � 5?      $ 	#FF515C81��6   $ 1Q�6&   5@      5B      5C      5D      