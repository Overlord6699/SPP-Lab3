   M S B A M L   `   `   `  ????D  @Scaner_UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Scaner_UI	Scaner_UI  5   	   D @Emoji.Wpf, Version=0.3.3.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:Emoji.Wpf;assembly=Emoji.Wpf	Emoji.Wpf 5   	       Scaner_UI.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Scaner_UI     5   	   <emoji*clr-namespace:Emoji.Wpf;assembly=Emoji.Wpf     5   	     ? Title$  SPP LAB3??5	   	   $	??800??6   $	??600??6'   .??5
      ? .+?5   
   R? ??6   ??  ?? Path$ FileDataModels???5      ?? 5       ?? ItemsSource 6+   ?? *
Children+.R?5      ??  ?? Orientation$ 
Horizontal=?6!   .+?5        Emoji.Wpf.TextBlock  $??0,0,8,0q?6*      Text 6;   ?? *Emoji+?? 5      $??0,0,8,0q?6$   ??5      `? 5   "    ?? StringFormat$ {0} ({1} байт, {2}%)??6/   .1?5   &   ?? $
 Name?6.   ?? 5   &   $
 Size?6.   ?? 5   &   $ 
Percentage?6.   5   #   5      5      5      ??5      ?? 5       ?? 
TargetType" Q?6   .?5      ??  ?? Property ?@Q?
IsSelected ?? Value 63   ?? *
IsSelected+?? 5       ?@Q?
IsExpanded 63   ?? *
IsExpanded+5       5#      ?? 5%   
   -   5        $??StartBtn??5&   7   $??
Старт??5%   2   $??16(?6B   $??80??6P   $??50??6[   
???   ?
??? ? ?$??	0 20 25 0q?5&   G   $??Right=?6Z   $	??Top=?5'      ??5%      ?? *StartCommand+5(      ?? 5)   
   -   5        $??	CancelBtn??5*   ;   $??Стоп??5)   3   $??16(?6B   $??80??6P   $??50??6[   
???   ?
??? E??${?False??5*   L   $??	0 75 25 0q?6^   $??Right=?5+      $	??Top=?6-   ??5)      ?? *CancelCommand+5,      5-      5.      