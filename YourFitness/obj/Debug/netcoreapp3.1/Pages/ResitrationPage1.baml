   M S B A M L   `   `   `  ????F  BYourFitness, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:YourFitness.PagesYourFitness.Pages  5      (    "YourFitness.Pages.ResitrationPage1   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:YourFitness.Pages     5      _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      S OHandyControl, Version=3.3.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5        N? 
FontFamily$  Cascadia Mono Light)?5       N? Title$ ResitrationPage1??5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $	??14* ?6   .+?5(   
   ?? $??2??6   ?? 5-   
   $??Center=?6   $	??top=?62   $??0 40 0 0q?6J   $??1??6]   .+?5/      ?? $??Center=?6   $??0 30 0 0q?50      
???   ?$	??0.5q?51   )   
??????? ?? CornerRadius$ 20??52   $   ._?53      ??  ?? Orientation$ 
Horizontal=?54      $??4q?55      .+?56      	?     MaterialDesignTabRadioButton#??[  57      $??4q?58      $??20(?6   ???	#FFFF844B d? 	IsChecked$
 TrueY?59      .??5:      ?? $ 
Horizontal=?5;      .+?5<      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
GenderMale=?5=   	   $??25??6   $??25??6'   ?? 5>      $??4 0 0 0q?5?   	   $??Мужской??5@   	   5A      5B      	? 5C      #??[  5D      $??4q?5E      $??20(?6   $ FalseY?5F      ???	#FFFF844B.??5G      ?? $ 
Horizontal=?5H      .+?5I        $ GenderFemale=?5J   	   $??25??6   $??25??6)   ?? 5K      $??4 0 0 0q?5L   	   $??Женский??5M   	   5N      5O      5R      5S      ?? 5V      $??Center=?6   $	??450??62   
???   ?$	??0.5q?5W   )   $??0 30 0 0q?5X      
???????$ 20??5Y   $   ._?5\      ?? $??20q?6   .+?5]      ?? -   5         ??Name$ tbFname??5^      $??20(?6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Имя??5_      .??6(   5`      ?? 5a      -   5        $ 	tbSurname??5b      $??0 30 0 0q?5a      $??20(?5b      $ Фамилия??5c      .??6,   5d      ?? 5f      $??0 30 0 0q?6!   $ 
Horizontal=?64   .+?5g      ?? $??Вес:??6%   $??20(?61   ?? 5h      -   5        $??weightTB??5h   5   $??5 0 0 0q?6$   $??20(?6E   $??0??6S   5j      )  #HandyControl.Controls.PreviewSlider  5l      -   5        $??weightSlider??5n   #   $??	0 10 0 30q?5l   '   &   HandyControl.Controls.TipElement	   
Visibility$	 Visible=?5m   #   
   	Placement$	
 Top=?6F    ?? IsSnapToTickEnabled$
 True??6d    ? Value$ 60Q?6?    ?? TickFrequency$ 1Q?6?    ?? TickPlacement$ BottomRight=?6?   $	??300??5n   7    ? Maximum$	 120Q?6D      PreviewContent 5o      ?? 5p        LabelPrimary#??[ 6$    ?? ContentStringFormat$ #0.00??6?   ??6J   ??  ?? Path$( "(hc:PreviewSlider.PreviewPosition)? ?? RelativeSource ?? *Self+6?   5r      ?? 5t      $??0 10 0 0q?6!   $ 
Horizontal=?64   .+?5u      ?? $??	Рост:??6%   $??20(?62   ?? 5v      -   5        $??heightTB??5v   5   $??5 0 0 0q?6$   $??20(?6E   $??0??6S   5x        5z      -   5        $??heightSlider??5   #   $??0 10 0 0q?5z   '   $	 Visible=?5{   #   $	
 Top=?5|   '   $
 True??5}   '   $ 60Q?5~   '   $ 1Q?62   $ BottomRight=?6D   $	??300??5   7   $	 220Q?6D    5?      ?? 5?      #??[ 6$   $ #0.00??6?   ??6J   ?? $( "(hc:PreviewSlider.PreviewPosition)? ?? *Self+6?   5?      (  "System.Windows.Controls.DatePicker  5?      
???   ?$??50??5?      $??15(?6"   $	??320??60   $0 *Выберите дату рождения??5?      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton$
 True??5?       ( $MaterialDesignFloatingHintDatePicker#??[ 5?      
???   ?6A   5?      5?      ?? 5?      -   5         ??Name$ btnContinue??5?      $??40??5?      $	??250??5?      ???#ff844b$??
0 40 0 40 q?5?      ???#ff844b
???????$??Продолжить??5?      $??20(?5?       ? Cursor$
 Hand??6   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10??5?   h   5?      5?      5?      5?      