   M S B A M L   `   `   `  ����I  EWPFDataBinding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WPFDataBinding.DemoWPFDataBinding.Demo  5   	        WPFDataBinding.Demo.Stocks   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:WPFDataBinding.Demo     5   	     � Title$  Stocks��5   	   $��271.688��6   $��745.916��6)   .��5	      � $��0,0,7,11q�6   .+�5
   
   �� -   5         ��Name$ inp_ItemName��5
      $
��Left=�6(   $��23��6C   $��
560,21,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $	��Top=�6w   $	��120��6�   �� 5   
   $��	Item Name��6   $
��Left=�6$   $��
486,21,0,0q�6?   $	��Top=�6S   �� 5   
   $��	Order Qty��6   $
��Left=�6$   $��
486,52,0,0q�6?   $	��Top=�6S   �� 5   
   -   5        $ inp_OrderQty��5      $
��Left=�6(   $��23��6C   $��
560,55,0,0q�6O   $
 Wrap=�6c   $	��Top=�6w   $	��120��6�   �� 5   
   $��Vendor��6   $
��Left=�6!   $��
496,89,0,0q�6<   $	��Top=�6P   �� 5   
   -   5        $ 
inp_vendor��5      $
��Left=�6&   $��23��6A   $��
560,92,0,0q�6M   $
 Wrap=�6a   $	��Top=�6u   $	��120��6�   �� 5   
   -   5         ��Name$ btn_Edit��5      $
��Edit��6#   $
��Left=�62   $��469,172,0,0q�6M   $	��Top=�6b   $��75��6z   6�   �� 5   
   -   5        $ 
btn_Delete��5      $��Delete��6%   $
��Left=�66   $��560,172,0,0q�6Q   $	��Top=�6f   $��75��6~   6�   �� 5   
   -   5        $ 	btn_Close��5      $��Close��6$   $
��Left=�64   $��648,172,0,0q�6O   $	��Top=�6d   $��75��6|   6�   �� 5   
   -   5        $ btn_add1��5      $	��Add��6#   $
��Left=�61   $��605,128,0,0q�6L   $	��Top=�6a   $��75��6y   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
StocksGrid��5      $
��Left=�6'   $	��209��6B   $��	10,11,0,0q�6O   $	��Top=�6b   $	��447��6z   5      5      