   M S B A M L   `   `   `  ����^  ZProyecto Final Gonzalo Cardo Muñoz, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:Proyecto_Final_Gonzalo_Cardo_Muñoz.Paginas+Proyecto_Final_Gonzalo_Cardo_Muñoz.Paginas  5      C    =Proyecto_Final_Gonzalo_Cardo_Muñoz.Paginas.AdministrarPagina   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Klocal9clr-namespace:Proyecto_Final_Gonzalo_Cardo_Muñoz.Paginas     5        N� Title$  AdministrarPagina��5	      .��5      � ��5   
   �� 5      .��5      �  � Color$ SkyBlue��6    � Offset$ 1Q�6/   5      .+�5   
   �� -   5         ��Name$ textuser��5      $
��Left=�6$   $�� ��6?   $��Center=�6G   $	��265��6b   $��0��6n   $��1��6~   $��2��6�   $��140,0,0,220q�6�   �� 5   
   $��Lista de usuarios��6   $
��Left=�6,   
����  �$
��Bold"�6]   $��Center=�6o   $��1��6�   $��0��6�   $	��170��6�   $��
10,0,0,120q�6�   �� 5   
   $��ADMINISTRACIÓN��6   $
��Left=�6)   
����  �$
��Bold"�6V   $��Center=�6h   $��0��6�   $��20(�6�   $	��200��6�   $��40��6�   $��
10,0,0,300q�6�   $��0��6�   �� 5   
   -   5         ��Name$ BotonBorrar��5      $��420,0,0,220q�6&   $��Borrar��6;   $
��Left=�6L   $��Center=�6g   $��35��6�   $��80��6�   $��1��6�   $��1��6�    � ToolTip 5      �� 5      $3��-Haz click para borrar al usuario de la barra.��6   5      �� 5   
   -   5         ��Name$ ListaUsuarios��5      $��0��6)   $	��200��69   $	��150��6E   $
��Left=�6R   $��2��6m   $��3��6z   $��	10,70,0,0q�6�   6�   �� 5   
   -   5         ��Name$ usuarios��5      
����  �$
��Bold"�68   $��Búsqueda de usuarios��6J   $��1��6i   $��0��6v   $��Center=�6�   $
��Left=�6�   $��
10,0,0,220q�6�   6�   �� 5   
   -   5        $ BotonBorrarTODO��5      $ ��Borrar todos los pacientes��6*   $
��Left=�6O   
���  ��$��
10,320,0,0q�6{   
�������$��Center=�6�   $��35��6�   $	��200��6�   $��5��6�   $��0��6�    5      �� 5      $v��pCUIDADO, este botón borra TODOS los datos de los pacientes, (Nombre, edad, localidad, alertas, patologías...).��6   5!      �� 5"   
   $&�� Cambiar nombre del administrador��6   
����  �$
��Bold"�6Q   $
��Left=�6c   $��Center=�6~   $��1��6�   $��0��6�   $	��250��6�   $��300,0,0,120q�6�   �� 5#   
   $+��%Cambiar contraseña del administrador��6   
����  �$
��Bold"�6U   $
��Left=�6g   $��Center=�6�   $��1��6�   $��0��6�   $	��250��6�   $��	300,0,0,0q�6�   �� 5$   
   $��Confirmar contraseña��6   $
��Left=�6/   
����  �$
��Bold"�6`   $��Center=�6r   $��1��6�   $��0��6�   $	��200��6�   $��
300,90,0,0q�6�   �� 5%   
   -   5        $ 
textnombre��5%      $
��Left=�6&   $�� ��6A   $��Center=�6I   $	��265��6d   $��0��6p   $��1��6�   $��2��6�   $��
300,0,0,70q�6�   �� 5&   
   -   5        $ BotonNombre��5&      $��
600,0,0,70q�6&   $��Cambiar nombre��6:   $
��Left=�6S   $��Center=�6n   $��35��6�   $	��120��6�   $��1��6�   $��1��6�    5'      �� 5(      $9��3Haz click para cambiar el nombre del administrador.��6   5*      �� 5+   
   -   5        $ BotonContraseña��5+      $��600,130,0,0q�6*   $��Cambiar contraseña��6?   $
��Left=�6\   $��Center=�6w   $��35��6�   $	��120��6�   $��1��6�   $��1��6�    5,      �� 5-      $>��8Haz click para cambiar la contraseña del administrador.��6   5/      G� 50   
   -	   5         G�Name$ 	txtcontra��50      $
��Left=�6)   $��Center=�6D   $	��265��6_   $��0��6k   $��1��6{   $��2��6�   $��
300,50,0,0q�6�   6�   G� 51   
   -
   5        $ 
txtcontra2��51      $
��Left=�6*   $��Center=�6E   $	��265��6`   $��0��6l   $��1��6|   $��2��6�   $��300,130,0,0q�6�   6�   53      54      