   M S B A M L   `   `   `  ����B  >GAIExam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:GAIExamGAIExam  5   	   ?$clr-namespace:GAIExam.MVVM.ViewModelGAIExam.MVVM.ViewModel  5   	       GAIExam.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:GAIExam     5   	   :	viewModel$clr-namespace:GAIExam.MVVM.ViewModel     5   	     � Title$  
MainWindow��5	   	   $	��450��5
   	   $	��900��6    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   
������  � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   	    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        #  System.Windows.SystemCommands   CloseWindowCommand   Command# Z 5      5        5   
   -   5           MinimizeWindowCommand# Z 5      5      	 � DataContext	 5      *  $GAIExam.MVVM.ViewModel.MainViewModel  5   
   .��5!      �� ���#E0FFFF
 J� Clip
 5"   
   �� 5#       �� RadiusX$ 20Q�6     �� RadiusY$ 20Q�5$        �� Rect$ 0,0,900,450�5%       5'      ._�5)   
   �  � RowDefinitions 5-      �� 5.      $��34 �6    �� 5/      .+�54      �� -   5        $��2��54       �� Orientation$ 
Horizontal=�55      $��RightToLeft=�56      ��59      �� 5:       �� 
StartPoint$	 0,0&�6*    �� EndPoint$	 1,2&�6;   .��5;      �  � Color$ #5bc3ff��6'    � Offset$ 1Q�67   � 5<      $ #3aa0ff��6'   $ 0Q�67   5=      .+�5@      �� -   5         ��Name$ 
closeButon��5@       	  close#��[  5A      #��Z 5B      5C      �� 5E      -   5        $ minimizeButton��5E      
������   minimize#��[ 5G      #��Z 5H      5I      5K      �� 5M      $ 
Horizontal=�6   .+�5O      �� -   5        $��Leader Of Digital��5O      $��Center=�5P      $��Center=�5Q      
�������$��19(�5S      $��40,1,0,0q�5T      $��Fonts\#Dosis)�5U      $��Medium"�5V      5W      5X      �� 5Z      $��1��6   ��5[      �� *CurrentView+5]      5a      5b      5c      