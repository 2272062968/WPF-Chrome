   M S B A M L   `   `   `  ���� A  =Chrome, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ChromeChrome      Chrome.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:Chrome     -     � WindowStyle$
  None=����	#FFF4F4F4 � Title$ 
MainWindow��$	��200��$	��550��$	��900��$
��1300��.���  � ColumnDefinitions �� �� .+�� $��2��.+��� .+��� -   $��tbcTitle��$
��1300��$
��Left=�.@��� -   $��tbm_0��$	��100����� -   $��gridBtnTitle�� �� $��* ��� $��26 �.+��� -   $
��lab0��$��微软 Bing 搜索���� -   $��btnCloseItem_0��$��1��$��20����Z� ��Z� .��x.���  � RowDefinitions �� $��30 ��� �� $��* � �� $��80 ��� $��* ��� $
��auto �.+��� $��0��$��35��$	��Top=� �� Orientation$ 
Horizontal=�.+��� -    � ToolTip$ 点击可后退��$��26��$��26��
�������$
��Left=���Z� .���� $��img/back.ico���� -   $ 点击可前进��$��26��$��26��
�������$
��Left=���Z� .���� $��img/Forward.ico���� -	   $��Refresh��$ 点此刷新页面��$��26��$��25��$
��Left=���Z� ��Z� .���� $��img/Refresh.ico���� ���	#FFE8E6E6���#ccc$��1q� �� CornerRadius$ 15��$��5 0 0 0q�$��1��$
��Auto��$��25��._��  �� $��26 ��� $��* ��� $��26 �.+��� ��Z� ��Z� .���� $��img/security.ico���� -
   $	��Url��$��1�� �� TextWrapping$ NoWrap=�$
��Auto��$��30��$��Center=�.���� -   $��2 ����Z� ��Z� .���� $��img/Collection.ico���� $��5 0 15 0q�$��2��$��Center=�$ 
Horizontal=�.+��� $��26��$��26��$��Right=���Z� ��Z� ��Z� .���� $��img/user.ico���� $��26��$��26��$��Right=���Z� ��Z� .���� $��img/more.png���� -   $��border��$��1��$��3�����	#FFDDDDDD$
��1300��$��1q�._��� -   $��shoucang��$��30��$ 
Horizontal=�(  "System.Windows.Controls.WebBrowser  -   $	��web��$��2��   Source$ https://cn.bing.com/?�� $��1��$��26��$��Right=����	#FFC8C8C8$	��Top=� �� $��26 ��� $��26 ��� $��26 �.+��� -   $��btnMin��$��26��$��0��
������ .���� $��img/minBg.png���� -   $��btnMax��$��26��$��1��
������ .���� $��img/maxBg.png���� -   $��btnClose��$��26��$��2��
������ .���� $��img/closeBg.png��