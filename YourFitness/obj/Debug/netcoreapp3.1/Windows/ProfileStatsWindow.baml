   M S B A M L   `   `   `  ????g  cLiveChartsCore.SkiaSharpView.WPF, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc92a3e13d40c573}Xclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF LiveChartsCore.SkiaSharpView.WPF  5   	   F BYourFitness, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:YourFitness.WindowsYourFitness.Windows 5      ,   &YourFitness.Windows.ProfileStatsWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   S OHandyControl, Version=3.3.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   blvcXclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF  5   	   -local!clr-namespace:YourFitness.Windows  5      ???#f5f5f5  ? WindowStartupLocation$  CenterScreen=?5   	   $??Cascadia Mono Light)?60    ? Title$# Ваша статистика??5   	   $	??800??6!   $
??1250??6.    ? DataContext 5      #  YourFitness.Windows.ViewModel  5   
   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $	??50* ?6   ?? 5      $	??50* ?6    ? RowDefinitions 5   
   ?? 5      $??90 ?6   ?? 5      $??1* ?6   ?? 5      $??1* ?6   .+?5   
   ?? ???#ff844b ?? CornerRadius$ 20??6&   $??2??68   ?? 5   
   ???#ff844b$??50??6&   $	??Top=?62   $??2??6J   ?? 5   
   $#??Ваша статистика??6   $??2??6+   
???????$??Center=?6R   $??Center=?6o   $??35(?6?   $??40??6?   $	??308??6?   )  #MaterialDesignThemes.Wpf.DialogHost  5'         CloseOnClickAway$
 True??5(      $??1??5)      $??2??6      DialogTheme$ Inherit=?5*         DialogContent 5,      ?? 5-      $??0 10 0 0q?6   
???????$??Center=?6C   $ 20??5.      $	??Top=?6+   ._?5/      ?  50      ?? 51   "   $??50 ?60   ?? 52   "   $
??Auto ?60   ?? 53   "   $??65.06 ?60   .+?57      (  "System.Windows.Controls.DatePicker  
???   ?$??40??58      $??12(?6"   $	??140??60   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$ 	 Выберите дату ??59      
   DisplayDate$
 
05.12.2022??63      SelectedDate 
05.12.20226M   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True??5:      $
??Left=?68   $??20 0 0 0q?6S    (  $MaterialDesignFloatingHintDatePicker#??[  5;      
???   ?6A   ?? 5>      $??1??6*   $	??Top=?67   $??20q?5?   )   .+?5B   "   ??  ?? Orientation$ 
Horizontal=?6-   .+?5C   &   ?? $??Вес: ??60   $??Bottom=?6=   $??20(?6X   ?? 5D   &   $?? ??6.   $??20??66   $??Bottom=?6A   $??20(?6\   ?? 5E   &   $?? кг??60   $??Bottom=?6;   $??16(?6V   ?? 5H   &   $??
Рост: ??60   $??Bottom=?6>   $??20(?6Y   $??25 0 0 0q?6g   ?? 5I   &   $?? ??6.   $??35??66   $??Bottom=?6A   $??20(?6\   ?? 5J   &   $?? см??60   $??Bottom=?6;   $??16(?6V   5N   #   ?? 5P   "   $ 
Horizontal=?6-   $??Center=?6F   $??0 5 0 0q?6c   .+?5R   &   ? .+?5S   *   ?? -   5        $??fontBodyImg??5S   0   $??/Res/FrontMan.png??6C   $	??190??6^   ?? 5T   *   -   5        $??btnPickFontImg??5T   1   $	??190??6I   $	??190??6U   ???#ff844b$??0q?5W   -   ??5U   )   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$
 Plus=?   Size 35??5X   .   ?? 5Y   2    ?? Color$ 	LightGray??6B    ?? Opacity$	 0.4Q?6T   5\   +   5^   '   ? 5`   &   $??5 0 5 0q?6,   .+?5a   *   ?? -   5        $??BackBodyImg??5a   0   $??/Res/BackMan.png??6C   $	??190??6]   ?? 5b   *   -   5        $??btnPickBackImg??5b   1   $	??190??6I   $	??190??6U   ???#ff844b$??0q?5e   -   ??5c   )     $
 Plus=? 35??5f   .   ?? 5g   2   $ 	LightGray??6B   $	 0.4Q?6T   5j   +   5l   '   ? 5n   &   .+?5o   *   ?? -   5        $??SideBodyImg??5o   0   $??/Res/SideMan.png??6C   $	??190??6]   ?? 5p   *   -   5        $??btnPickSideImg??5p   1   $	??190??6I   $	??190??6U   ???#ff844b$??0q?5s   -   ??5q   )     $
 Plus=? 35??5t   .   ?? 5u   2   $ 	LightGray??6B   $	 0.4Q?6T   5x   +   5z   '   5|   #   5?      ?? 5?      $??8q?6)   $??2??64   $ 
Horizontal=?6A   $??Center=?6Z   .+?5?   "   ?? -   5         ??Name$ 	btnCansel??5?   /   $??	0 0 20 0 q?6B   $??1??5?   1   $	??130??5?   /   $??28??6;   ???#ff844b???#ff844b
???????   CloseDialogCommand#??Z 5?   /   $??Отмена??5?   /   $??10(?5?   /   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10??5?   |   5?   #   ?? 5?   "   -   5        $ btnSave??5?   /   $??1??5?   1   $	??130??5?   /   $??28??6;   ???#ff844b???#ff844b
???????$??Сохранить??5?   /   $??10(?5?   /   $ 10??5?   |   5?   #   5?      ?? 5?      
???????$??1??67   $??1??6D   $??Bottom=?6O   5?      5?      .??5?      ?? 
???????$??20q?6.   $??1??5?      $ 20??5?      ._?5?      ? .+?5?      (  "HandyControl.Controls.ScrollViewer  .??5?      ?  5?      ?? 5?   "   $	??20* ?60   ?? 5?   "   $
??305* ?60   .+?5?      ?? $??Замеры??6(   $??Center=?66   $??Center=?6S   $??30(?5?      ?? 5?      $??1??6)   .+?5?   "   ?? $??0 10 0 0q?6)   $	??Top=?6<   ._?5?   &   ?  5?   *   ?? 5?   .   $??30 ?6<   ?? 5?   .   $
??auto ?6<   .+?5?   *   ?? $??
05.12.2022??64   $
??Left=?6F   $??5q?5?   (   
???????$??Center=?5?   (   $??15(?5?      ?? 5?   *   $??1??66   $	??Top=?6C   $??5q?5?   )   .+?5?   .   ?? $ 
Horizontal=?69   .+?5?   2   ?? $??Вес:??6<   $??Bottom=?6H   $??20(?6c   ?? 5?   2   $??67??6<   $??Bottom=?6F   $??20(?6a   ?? 5?   2   $
??кг??6<   $??Bottom=?6F   $??16(?6a   ?? 5?   2   $??	Рост:??6<   $??Bottom=?6I   $??20(?6d   $??25 0 0 0q?6r   ?? 5?   2   $	??182??6<   $??Bottom=?6G   $??20(?6b   ?? 5?   2   $
??см??6<   $??Bottom=?6F   $??16(?6a   5?   /   ?? 5?   .   $ 
Horizontal=?69   $??Center=?6R   $??0 5 0 0q?6o   .+?5?   2   ?? $??/Res/FrontMan.png??68   $	??190??6S   ?? 5?   2   $??/Res/BackMan.png??68   $	??190??6R   ?? 5?   2   $??/Res/SideMan.png??68   $	??190??6R   5?   /   5?   +   ?? 5?   *   
???????$??1??6C   $??1??6P   $??Bottom=?6[   5?   '   5?   #   ?? 5?   #   $??0 10 0 0q?6*   $	??Top=?6=   ._?5?   "   ?  5?   &   ?? 5?   *   $??30 ?68   ?? 5?   *   $
??auto ?68   .+?5?   &   ?? $??
05.12.2022??60   $
??Left=?6B   $??5q?5?   (   
???????$??Center=?5?   (   $??15(?5?      ?? 5?   &   $??1??62   $	??Top=?6?   $??5q?5?   )   .+?5?   *   ?? $ 
Horizontal=?65   .+?5?   .   ?? $??Вес:??68   $??Bottom=?6D   $??20(?6_   ?? 5?   .   $??67??68   $??Bottom=?6B   $??20(?6]   ?? 5?   .   $
??кг??68   $??Bottom=?6B   $??16(?6]   ?? 5?   .   $??	Рост:??68   $??Bottom=?6E   $??20(?6`   $??25 0 0 0q?6n   ?? 5?   .   $	??182??68   $??Bottom=?6C   $??20(?6^   ?? 5   .   $
??см??68   $??Bottom=?6B   $??16(?6]   5  +   ?? 5  *   $ 
Horizontal=?65   $??Center=?6N   $??0 5 0 0q?6k   .+?5  .   ?? $??/Res/FrontMan.png??64   $	??190??6O   ?? 5  .   $??/Res/BackMan.png??64   $	??190??6N   ?? 5	  .   $??/Res/SideMan.png??64   $	??190??6N   5  +   5  '   ?? 5  &   
???????$??1??6?   $??1??6L   $??Bottom=?6W   5  #   5     ?? 5     $??0 10 0 0q?6%   $	??Top=?68   ._?5  "   ?  5  &   ?? 5  *   $??30 ?68   ?? 5  *   $
??auto ?68   .+?5  &   ?? $??
05.12.2022??60   $
??Left=?6B   $??5q?5  (   
???????$??Center=?5  (   $??15(?5     ?? 5   &   $??1??62   $	??Top=?6?   $??5q?5!  )   .+?5$  *   ?? $ 
Horizontal=?65   .+?5%  .   ?? $??Вес:??68   $??Bottom=?6D   $??20(?6_   ?? 5&  .   $??67??68   $??Bottom=?6B   $??20(?6]   ?? 5'  .   $
??кг??68   $??Bottom=?6B   $??16(?6]   ?? 5*  .   $??	Рост:??68   $??Bottom=?6E   $??20(?6`   $??25 0 0 0q?6n   ?? 5+  .   $	??182??68   $??Bottom=?6C   $??20(?6^   ?? 5,  .   $
??см??68   $??Bottom=?6B   $??16(?6]   50  +   ?? 52  *   $ 
Horizontal=?65   $??Center=?6N   $??0 5 0 0q?6k   .+?53  .   ?? $??/Res/FrontMan.png??64   $	??190??6O   ?? 54  .   $??/Res/BackMan.png??64   $	??190??6N   ?? 55  .   $??/Res/SideMan.png??64   $	??190??6N   57  +   5;  '   ?? 5<  &   
???????$??1??6?   $??1??6L   $??Bottom=?6W   5@  #   5A     ?? 5C     $??1??6%   $??0 10 0 0q?62   $	??Top=?6E   ._?5D  &   ?  5E  *   ?? 5F  .   $??30 ?6<   ?? 5G  .   $
??auto ?6<   .+?5I  *   ?? $??
05.12.2022??64   $
??Left=?6F   $??5q?5J  (   
???????$??Center=?5K  (   $??15(?5L     ?? 5N  *   $ 
Horizontal=?65   $??1??5O  )   $	??Top=?66   $??5q?5P  )   .+?5Q  .   ?? $??Вес:??68   $??Bottom=?6D   $??20(?6_   ?? 5R  .   $??67??68   $??Bottom=?6B   $??20(?6]   ?? 5S  .   $
??кг??68   $??Bottom=?6B   $??16(?6]   ?? 5V  .   $??	Рост:??68   $??Bottom=?6E   $??20(?6`   $??25 0 0 0q?6n   ?? 5W  .   $	??182??68   $??Bottom=?6C   $??20(?6^   ?? 5X  .   $
??см??68   $??Bottom=?6B   $??16(?6]   5[  +   ?? 5a  *   
???????$??1??6C   $??1??6P   $??Bottom=?6[   5e  '   5f  #   5g     5o     5r     ?? 5u     $??1??6    0 ,MaterialDesignFloatingActionMiniAccentButton#??[ 5v  	      OpenDialogCommand#??Z 5w  	   $??Bottom=?5x  	   ???#ff844b???#ff844b$??Right=?5z  	   $??10q?5{  	   ??5|  	     $
 Plus=? 225~     5?     5?     ?? 5?     $??1??6   $??1??6#   
???????$	??300??6G   $	??550??6X   $??20q?6g   $ 20??5?     ._?5?     ?  5?     ?? 5?     $	??19* ?6(   ?? 5?     $
??131* ?6(   .+?5?     ?? $??
Мышцы??6    $??Center=?6-   $??Center=?6J   $??30(?5?     /	   )LiveChartsCore.SkiaSharpView.WPF.PieChart	  5?     $??1??5?     ,
   &LiveChartsCore.SkiaSharpView.WPF.Chart 
  LegendPosition$ Right=?6B    	  Series 6"   ?? *SeriesMuscle+6B   5?     5?     ?? 5?  
   
???????$	??300??6$   $	??550??65   $??20q?6D   $??2??5?     $??1??6   $ 20??5?     ._?5?     ?  5?     ?? 5?     $	??19* ?6$   ?? 5?     $
??131* ?6$   .+?5?     ?? $??Активность??6   $??Center=?6.   $??Center=?6K   $??30(?5?     5   /LiveChartsCore.SkiaSharpView.WPF.CartesianChart  5?     $??1??6%   $ Right=?5?  	      Series 5?  	   ?? *
SeriesWeak+   XAxes 5?  	   ?? *XAxes+5?     5?     5?     5?     5?     