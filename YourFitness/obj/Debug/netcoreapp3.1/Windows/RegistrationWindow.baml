   M S B A M L   `   `   `  ????F  BYourFitness, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:YourFitness.WindowsYourFitness.Windows  5   	   ,    &YourFitness.Windows.RegistrationWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:YourFitness.Windows     5   	   S OHandyControl, Version=3.3.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $??Cascadia Mono Light)?5
   	     ? WindowStartupLocation$  CenterScreen=?6*    ? Title$ RegistrationWindow??5   	   $
??1000??6$   $
??1500??62   .??5      ?  ? RowDefinitions 5   
   ?? 5      $??3* ?6   ?? 5      $	??14* ?6   .+?5%   
   ?? ???#6db4b8$	??100??6'   $	??Top=?64   ?? 5&   
   ???#6db4b8 ?? CornerRadius$ 20??6&   ?? 5(   
   ???#f3f3f5 J? Opacity$ 1Q?6&   $??2??62   ?? 5)   
   $??/Res/bacground1.png??6   $	??350??6-   $	??350??69   $??
0 0 70 -80q?6F   $??1??6Z   $??Right=?6g   ?? 5*   
   $??/Res/bacground2.png??6   $??1??6-   $	??350??6:   $	??350??6F   $??
70 0 0 -80q?6S   $
??Left=?6g   ?? 5P   
   $3??-Несколько шагов до мечты??6   $??Center=?5Q      $??80(?61   
???????$??Center=?5S      ?? 5V   
   $??Center=?6   $	??top=?5W      $??0 40 0 0q?5X      $??1??5Y      .+?5[      ?? $??Center=?6   $??2??62   
???   ?$	??0.5q?5\   )   
???????$ 20??5]   $   ._?5^      #  HandyControl.Controls.StepBar  -   5          Name$ stepBar??5_      $??2??5`      $??15q?6)      	StepIndex$ 0??5a      .@?5b      '  !HandyControl.Controls.StepBarItem  $(??"Ввод личных данных??6%     5c      $??Выберите цели??6%     5d      $>??8Как часто вы хотите заниматься??6%     5e      $J??DКак долго вы хотите заниматься в день??6%   5f      5h       ? 5j      -   5          ?Name$ RegistrationFrame??5j      $??0 30 0 0q?6/   $??0q?6B     ? NavigationUIVisibility$ Hidden=?5k      5l      5o      5p      