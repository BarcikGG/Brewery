   M S B A M L   `   `   `  ���� C  ?FinalWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FinalWPFFinalWPF      FinalWPF.BillsPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     (localclr-namespace:FinalWPF       N� Title$  	BillsPage��.���  � ColumnDefinitions �� $��* ��� $
��0.2* ��� $��* � � RowDefinitions �� $
��0.2* ��� $
��0.2* ��� $
��0.8* ��� $
��0.8* ��� $
��0.2* ��� $
��0.2* �.+��� $&�� Информация о чеке��$��1��$��0��$��Center=�$��Gilroy)�$��20(��� -    ��Name$ BillsBox��$��1��$��1��$��2��$��0,0,0,0q�$��Stretch=��� -    ��Name$ BillInfoBlock��$�� ��$��2��$��2��$��20,20,20,20q�$��18(�$��Gilroy)�&   System.Windows.Controls.DataGrid  -     Name$ BillGrid��$��2��$��1��$��2��$��2���� -    ��Name$ GetBill��$(��"Выгрузить этот чек��$��5��$��3�����	#FF03A9F4
�������