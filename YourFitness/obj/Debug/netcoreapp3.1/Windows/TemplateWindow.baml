   M S B A M L   `   `   `  ????F  BYourFitness, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:YourFitness.WindowsYourFitness.Windows  5   	   (    "YourFitness.Windows.TemplateWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:YourFitness.Windows     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  69   S OHandyControl, Version=3.3.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  6?   
?????? $??Cascadia Mono Light)?5   4     ? Title$  TemplateWindow??5   	   $	??800??6    $	??900??6-   .??5	      ? .+?5   
   ?? $??0 10 0 0q?6   
???????$	??800??66   $??Center=?6C    ?? CornerRadius$ 20??5      $	??Top=?6+   ._?5      ?  ? RowDefinitions 5      ?? 5      $
??auto ?6$   ?? 5      $
??auto ?6$   ?? 5      $
??auto ?6$   ?? 5      $??70 ?6$   .+?5      $  HandyControl.Controls.Gravatar  	   Id$
 1234??6      GravatarCircleImg#??[  6)   .??5      ?? 5      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  5      C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 66   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *
ExpandIn+.??5      ?? Hello World6-   5      ?? 5      $??10q?6    ?? TextWrapping$
 Wrap=?6&   
??????? ! MaterialDesignOutlinedTextBox#??[ 5      ???#ff844b$??3q?5    0   $??25(?5!      $	??110??6(   $??1??68   ?? 5%      $??2??6   .+?5)      ?? $	??300??6   $	??300??6&   $
??Left=?62   $??10q?6M   ._?5+      ? .+?5-      ?? $??
/Res/1.jpg??6%   $
??Fill=?69   ?? 5/      -   5        $??btnImage??5/   %   $	??Top=?50      $??Right=?51      $??25??52      $??45??6   
?????? $??0q?6A    ? Cursor$
 Hand??6U   .??53   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowClose=?55      ???	#FF494949$??Center=?56      57      59      5;      ?? 5=      
???   ?$??1q?61   
???????$
??Left=?6X   $??10q?6s   $	??300??6   $??45??6?   $ 20??6?   ._?5>      ? .+?5?      ?? $??Тренировка??6(   $??Center=?6:   $??Center=?6W   $??20(?5@   A   ?? 5B      -   5        $??btnDeleteWorkout??5B   %   $??5q?5C      $??Center=?6   $??Right=?5D      $??25??5E      $??45??6   
?????? $??0q?6A   $
 Hand??6U   .??5F   "     $ WindowClose=?5H      ???	#FF494949$??Center=?5I      5K      5M      5P      5R      ?? 5X      $??3??6   $??Right=?6*    ?? Orientation$ 
Horizontal=?6F   .+?5Y      '  !MaterialDesignThemes.Wpf.PopupBox  $??0 0 10 0q?5Z      $??35??6(   $??35??63    - )MaterialDesignMultiFloatingActionPopupBox#??[ 5[      	   PlacementMode$	 BottomAndAlignCentres=?5\      
 ^? 	Placement$
 Right=?5]      $??Right=?6$    ? ToolTip$? 9PopupBox, Style MaterialDesignMultiFloatingActionPopupBox??5^      {?5_      ?? *DataContext.ControlsEnabled+ ?? RelativeSource ?? *FindAncestor+ ?? AncestorType
 Window   PopupContent. 5`      ?? .+?5a      ?? $ Добавить фото??5b      ??5c      0  *MaterialDesignThemes.Wpf.PackIconExtension  *FileImagePlus+?? 5d      $+ %Добавить тренировку??5e      ??5f        *WeightLifter+5g      5h      ?? 5j      -   5         ??Name$ btnSave??5n   /   $??3??5k      $??Center=?6'   $??0 0 10 0q?5m      $??1??5o   1   $	??130??5p   /   $??35??6;   ???#ff844b???#ff844b
???????$??Опубликовать??5t   /   $??10(?5u   /   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10??5v   p   5w      5z      ?? 5?      -   5        $??exitBtn??5?      $??5q?6   $??Right=?5?      $	??Top=?6*   )	  #MaterialDesignThemes.Wpf.DialogHost 	  CloseDialogCommand#??Z 5?      $??25??5?      $??45??6   
?????? $??0q?6A   $
 Hand??6U   .??5?        $ WindowClose=?5?      ???	#FF494949$??Center=?5?      5?      5?      5?      5?      5?      