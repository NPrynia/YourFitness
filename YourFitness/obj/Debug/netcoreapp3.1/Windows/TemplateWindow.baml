   M S B A M L   `   `   `  ����F  BYourFitness, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:YourFitness.WindowsYourFitness.Windows  5   	   g cLiveChartsCore.SkiaSharpView.WPF, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc92a3e13d40c573}Xclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF LiveChartsCore.SkiaSharpView.WPF 5
   R   (    "YourFitness.Windows.TemplateWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:YourFitness.Windows     5   	   S OHandyControl, Version=3.3.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   blvcXclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF  6R   
������ $��Cascadia Mono Light)�5	   	     � Title$  TemplateWindow��5   	   $
��1050��6    $
��1000��6.   .��5      � .+�5   
   �� 
������� �� CornerRadius$ 20��6%   ._�5      �� $��16q�5      .+�5      �� $%��Найти упражнение��5   	   $
��0 10q�6!   �� 5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Поиск��5         HintOpacity$	 .26Q�5      -  'MaterialDesignThemes.Wpf.ComboBoxAssist   	MaxLength$ 2��5       �� 
IsEditable$
 True��5      .@�5      �� $��Приседания��5      �� 5      $��Отжимания��5      �� 5       $��Подтягивание��5!      �� 5"      $��Планка��5#      5$      �� 5&      $
��0 10q�6    �� Orientation$ 
Horizontal=�6,   .+�5(      �� $)��#Количество|Секунд :��6    $��Center=�6;   �� 5)      $�� ��6   $��30��6&   5+      �� 5-      $ 
Horizontal=�5.   	   $��Center=�5/   	   .+�50      ��    MaterialDesignFlatButton#��[  51       �� IsCancel$
 True��52      $��0 8 8 0q�53      $��Отмена��54      )  #MaterialDesignThemes.Wpf.DialogHost   CloseDialogCommand#��Z 55      56      �� 57      #��[  58      	 �� 	IsDefault$
	 True��59      $��0 8 8 0q�5:      $��Добавить��5;      #��Z 5<      5=      5?      �� 5C      $��1��6   $��	0 100 0 0q�6*   .+�5D      �� $	��dfg��6   $��	0 30 0 20q�5E   !   $	��650��64   $# Название услуги��5F      
 �� TextWrapping$

 Wrap=�5G      $��35(�5H      �� 5I      $	��850��5J   *    ! MaterialDesignOutlinedTextBox#��[ 5K   -   $ Описание��5M   -   $

 Wrap=�5N   &   $��30(�5O         
IsFloating$
 True��5P      ��5L   -   �� *description+5P      �� 5Q      $ 
Horizontal=�6!   $	��Top=�6:   .+�5S      �� ���#ff844b$��0 20 0 0q�5T   !   $��Стоимость:��63   $
��Wrap=�5U   )   $��30(�5V      $��Bottom=�6    �� 5W      ���#ff844b$��0 20 0 0q�5X   !   $ Стоимость��63   $

 Wrap=�5Y   )   $��30(�5Z      ��6    �� *cost+�� 5\      -   5        $��btnDeleteService��5]   >   $��33��5^   .   $��40 0 0 0q�6:   $	��250��6L   $��Bottom=�6X   ���#ff844b���#ff844b
�������$��Удалить��5b   .   $��20(�5c   .   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5d   t   5e      5h      5k      5l      5n      5r      5s      