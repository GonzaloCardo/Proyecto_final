   M S B A M L   `   `   `  ����^  ZProyecto Final Gonzalo Cardo Muñoz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:Proyecto_Final_Gonzalo_Cardo_Muñoz.Paginas+Proyecto_Final_Gonzalo_Cardo_Muñoz.Paginas  5      >    8Proyecto_Final_Gonzalo_Cardo_Muñoz.Paginas.PaginaAlerta   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Klocal9clr-namespace:Proyecto_Final_Gonzalo_Cardo_Muñoz.Paginas     5        N� Title$  PaginaAlerta��5	      .��5      � ��5   
   �� 5      .��5      �  � Color$ Lavender��6    � Offset$ 1Q�60   5       � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   
����  �$
��Bold"�6C   $	��Top=�6U   $
��Left=�6m   $��5,0,0,0q�6�   .��6�   Descripción:6�   �� 5   
   $��0��6   $��0��6   
����  �$
��Bold"�6C   $��Bottom=�6U   $
��Left=�6p   $��5,0,0,30q�6�   .��6�   Detalles sobre la alerta:6�   �� 5   
   $��0��6   $��0��6   
����  �$
��Bold"�6C   $	��Top=�6U   $
��Left=�6m   $��5,45,0,0q�6�   .��6�   Fecha de la alerta:6�   �� 5   
   -   5         ��Name$ 	txtalerta��5      $��0��6%   $��0��62   $	��Top=�6B   $
��Left=�6Z   $��5,25,0,0q�6u   $��20��6�   $	��270��6�   6�   �� 5   
   -   5        $ txtfecha��5      $��0��6$   $��0��61   $	��Top=�6A   $
��Left=�6Y   $��5,70,0,0q�6t   $��20��6�   $	��270��6�   6�   �� 5    
   -   5        $ txtdetalles��5        �� TextWrapping$
 Wrap=�6'   $��0��6<   $��0��6I   $��Bottom=�6Y   $
��Left=�6t   $��2��6�   $��5,0,0,60q�6�   $	��110��6�   $	��270��6�   6�   �� 5!   
   -   5        $��1��5!      $��0��6   $��Bottom=�6.   $��Right=�6I   $��	0,0,10,20q�6e   $��25��6x   $��82��6�   $��Guardar��6�    � ToolTip 5"      �� 5#      $4��.Haz click para guardar la alerta del paciente.��6   5%      �� 5&   
   -   5         ��Name$ 	btnBorrar��5&      $��1��6$   $��0��61   $��Bottom=�6A   $
��Left=�6\   $��	10,0,0,20q�6w   $��25��6�   $��80��6�   $��Borrar��6�    5'      �� 5(      $3��-Haz click para borrar la alerta del paciente.��6   5*      �� 5+   
   -   5        $��1��5+      $��0��6   $��Bottom=�6.   $��Right=�6I   $��
0,0,100,20q�6e   $��25��6y   $	��100��6�   $��
Actualizar��6�    5,      �� 5-      $7��1Haz click para actualizar la alerta del paciente.��6   5/      50      51      