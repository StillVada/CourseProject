   M S B A M L   `   `   `  ���� A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf     WpfApp.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:WpfApp     Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf       � Title$#  Курсовой проект��$	��500��$
��1000�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.��� .+��� .@��� $#��Исходные данные��.��� $��800px��$��0,50,0,0q� � RowDefinitions �� $
��50px ��� $
��50px ��� $
��50px ��� $
��50px ��� $
��50px ��� $
��auto � � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $+��%Начальное значение x��$��0��$��0��$��Center=�$
��16px(��� -    ��Name$ iStart��$��0��$��1�� � ToolTip$U OЭто начальное значение x для числового ряда���� $)��#Конечное значение x��$��1��$��0��$��Center=�$
��16px(��� -   $
 iEnd��$��1��$��1��$S MЭто конечное значение x для числового ряда���� $��Шаг x��$��2��$��0��$��Center=�$
��16px(��� -   $ hstep��$��2��$��1��$^ XШаг x для вычисления числового ряда для массива A���� $)��#Точность измерения��$��3��$��0��$��Center=�$
��16px(��� -   $ epsilon��$��3��$��1��$s mТочность до которой будет вычисляться сумма числового ряда���� $��Шаг g��$��4��$��0��$��Center=�$
��16px(��� -   $ gstep��$��4��$��1��$� �Шаг для вычисления интерполирующей функции для массива Y (Введите шаг по модулю)���� $��5��$��0�� �� Orientation$ 
Horizontal=�$
��Left=�   Buttons#��[  .+��� -    ��Name$ 	PresetBtn��$)��#Контрольный пример��$��0,0,20,0q�$K EЗаполнить поля примерными значениями���� $��5��$��1��$ 
Horizontal=�$��Right=�#��[  .+��� -   $ ClearBtn��$��Очистить��$��0,0,5,0q�$
��80px��$&  Очистить все поля���� -   $ CalculateBtn��$��Посчитать��	 �� 	IsDefault	 .   
PrimaryBtn#��[ �� $��Массив A��{��� *IsTabsEnable+.��&   System.Windows.Controls.DataGrid  -	   
  Name$
 DgArrayA��   
IsReadOnly . ��. $
��Auto=�   AutoGenerateColumns .  ���� *ListA+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Индекс��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *x+  $ Элемент��$ *  �� *y+  $+ %Контрольная формула��$ *  �� *
ControlSum+�� $��Массив B��{��� *IsTabsEnable+.��  -
   $
 DgArrayB�� . ��. $
��Auto=� .  ���� *ListB+   $ [i, j]��$ *  �� *x+  $ Элемент��$ *  �� *y+�� $��Массив C��{��� *IsTabsEnable+.��  -   $
 DgArrayC�� . ��. $
��Auto=� .  ���� *ListC+   $ Индекс��$ *  �� *x+  $ Элемент��$ *  �� *y+�� $��Массив Y��{��� *IsTabsEnable+.��  -   $
 DgArrayY�� . ��. $
��Auto=� .  ���� *ListY+   $ X��$ *  �� *x+  $ Y��$ *  �� *y+�� $/��)Сортированный массив Y��{��� *IsTabsEnable+.��  -   $
 DgArraySortY�� . ��. $
��Auto=� .  ���� *ListSortedY+   $ X��$ *  �� *x+  $ Y��$ *  �� *y+�� $��График Y��{��� *IsTabsEnable+.��#  LiveCharts.Wpf.CartesianChart  &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�   Series �� *Series+   AxisX   LiveCharts.Wpf.Axis     Title$ Ось X��   Labels �� *AxisXLabels+   AxisY   $ Ось Y���� $!��Текстовый файл��{��� *IsTabsEnable+.���  �� $��* ��� $
��Auto �.+��� $��0��$
��Auto=�$
��Auto=�.���� -   $ TbFileContent�� �� TextWrapping$
 Wrap=�  
FileViewer#��[ ���� *FileContent+�� -   $ SaveFileBtn��$��1��$!��Сохранить Файл��$��Right=�$��
0,15,10,10q��� -   $ 	FAQButton��$��Right=�$	��Top=�$��80��$��25��$��0,1,5,0q�$	��5pxq�#��[ .���� $
��12px(�$��Center=�$��Center=�$��Справка��