   M S B A M L   `   `   `  ????  YourFitness$    YourFitness.Windows.AuthWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   S OHandyControl, Version=3.3.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   
?????? $	??800??5
   
   $	??580??6     ? WindowStartupLocation$  CenterScreen=?5   	    ? 
ResizeMode$ NoResize=?5   	   $??Cascadia Mono Light)?5   	    ? AllowsTransparency$
 True??5   	    ? WindowStyle$
 None=?5   	    ? Title$ Авторизация??5   	   .??5      ?  ? RowDefinitions 5      ?? 5      $
??350* ?6    ?? 5      $
??239* ?6    .+?5   
   ?? $??2??6   ???#fafafa ?? CornerRadius$ 10??67   ?? 5      $??1??6   $??10??6"   $	??Top=?6.   
???????6F   ?? 5      $??1??6   
???????$ 10??65   ?? 5      -   5        $??
tabControl??5       ?? TabStripPlacement$ Bottom=?5        "  MaterialDesignFilledTabControl#??[  5!      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ Custom=?5"      	   
Foreground
	 ?????
   
Background
 ?#ff844b.@?5'      ?? $??Login??5(      .??5-      7  1HandyControl.Controls.TransitioningContentControl  .??5.      (? $	??200??6   $	??200??6+   .??5/      )  #HandyControl.Controls.AnimationPath  $??Center=?6+      Duration$ 0:0:5D?6F    ?? Stretch$ Uniform=?6W   $	??500??6i   $	??500??6u   $??20??6?   ???#ff844b  EmailGeometry   Data# [ 6?   50      51      53      ?? 54      $??Registration??55      .??56      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 66   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *
ExpandIn+.??57      ? $??Center=?6   $??Center=?69   .+?59      ?? $	 220??6!   $??0q?64   $	??280??6H   $	??280??6T   ??5:      ?? 5;   "   -   5        
photoImage?? j? Stretch$
 Fill=?5;   A   ._?5=      $  HandyControl.Controls.Gravatar  -   5        $??gravatar??5=   *   $	??280??6:   $	??280??6F   $	??0.6q?6z   ???#333333  GravatarCircle#??[ 6?   	   Id 6S   ?? *Text+ ?? ElementName$ tbName??6?   5>      ?? 5@      -   5         ??Name$ 	pickImage??5A       0 ,MaterialDesignFloatingActionMiniAccentButton#??[ 5B      ???#ff844b
???????$??50??5F      $??50??6(   $??Right=?5G      $??Bottom=?5H      $??	0 0 15 15q?5I      ???#ff844b ? Cursor$
 Hand??6@   .??5J      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	FileImage=?5K      5L      5R      5T      5U      5V      ?? 5^      $??1??6   $??Center=?6(   $??Center=?6C   .+?5b      ?? -   5         ??Name$ tbMail??5b      )	  #MaterialDesignThemes.Wpf.HintAssist 	  Hint$
 Mail??5c      $??16(?5d      $	??280??5e      $??0??6    % !MaterialDesignFloatingHintTextBox#??[ 5f      ?? 5i      -   5        $ tbName??5i      $
 Name??5j      $??16(?5k       ?? 	MaxLength$ 50??6    $??
0 30 0 30 q?5l      $	??280??5m      $??45??6   #??[ 5n      G? 5q      -   5         G?Name$ 
pbPassword??5r       ? ToolTip$? ?•Длинна от 7 до 15
•Наличие цифр 20
•Наличие прописных и строничных букв??5s      $	??280??5u      $??45??6    G? 	MaxLength$ 50??6)   $??16(?5v       G? Password$  ??5w      $ Password??5x       / +MaterialDesignFloatingHintRevealPasswordBox#??[ 5z      0
  *MaterialDesignThemes.Wpf.PasswordBoxAssist 
  Password 5y      ?? *	Password2+ ?? Mode$ TwoWay=?5z      ?? 5|      -   5        $ btnLogin??5}      $??40??5~      ???#ff844b$??	0 40 0 0 q?5?      ???#ff844b
???????$??Login??5?      $??20(?5?      $
 Hand??6   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10??5?   h   5?      5?      ?? 5?      -	   5        $??	topBorder??5?   =   $??40??5?      
?????? $	??Top=?5?   %   ._?5?      ?? -
   5        $??exitBtn??5?      $??Right=?5?      $??45??5?      $??45??6   
?????? $??0q?6A   $
 Hand??6U   .??5?        $ WindowClose=?5?      ???	#FF494949$??Center=?5?      5?      5?      5?      5?      