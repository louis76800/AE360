   M S B A M L   `   `   `  ����@  <pb360, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:pb360.components.Administration.Gestion_salarie/pb360.components.Administration.Gestion_salarie  5      K    Epb360.components.Administration.Gestion_salarie.Page_modifier_salarie   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Olocal=clr-namespace:pb360.components.Administration.Gestion_salarie     5        N� Title$  Page_modifier_salarie��5	      .��5      �  J� RenderTransformOrigin$ 0.503,0.548&�6    � ColumnDefinitions 5   
   �� 5      $	��50* �6   �� 5      $��5* �6   �� 5      $	��50* �6   �� 5      $��5* �6   �� 5      $	��50* �6    � RowDefinitions 5   
   �� 5      $	��20* �6   �� 5      $	��15* �6   �� 5      $	��25* �6   �� 5      $	��15* �6   �� 5      $	��25* �6   �� 5      $	��15* �6   �� 5      $	��25* �6   �� 5      $	��15* �6   �� 5      $	��25* �6   �� 5      $	��15* �6   �� 5      $	��25* �6   �� 5      $	��15* �6   .+�5#   
   �� 
�������$��20��6(   $��12��6:   5$      �� 5%   
   $��1��6   $��2��6!   $
��Wrap=�61   $��Inscription��6E   $��20(�6X   $��Center=�6f   �� 5'   
   $��3��6   $��0��6"   $
��Wrap=�62   $	��Nom��6F   $��20(�6Q   $��Center=�6_   �� 5(   
   $��3��6   $��2��6"   $
��Wrap=�62   $��Prénom��6F   $��20(�6T   $��Center=�6b   �� 5)   
   $��3��6   $��4��6"   $
��Wrap=�62   $��Téléphone fixe��6F   $��20(�6\   $��Center=�6j   �� 5+   
   -   5         ��Name$	 nom��5+      $��4��6    $	��top=�6-    �� 	UndoLimit$ 1��6E   $��0��6S    �� TextWrapping$
 Wrap=�6c   $��20(�6x   �� 5,   
   -   5        $ prenom��5,      $��4��6#   $	��top=�60   $ 1��6H   $��2��6V   $
 Wrap=�6f   $��20(�6{   �� 5-   
   -   5        $ tel_fix��5-      $��4��6$   $	��top=�61   $ 1��6I   $��4��6W   $
 Wrap=�6g   $��20(�6|   �� 50   
   $��5��6   $��0��6"   $
��Wrap=�62   $��Téléphone portable��6F   $��20(�6`   $��Center=�6n   �� 51   
   $��5��6   $��2��6"   $
��Wrap=�62   $��Email��6F   $��20(�6S   $��Center=�6a   �� 52   
   $��5��6   $��4��6"   $
��Wrap=�62   $��Service��6F   $��20(�6U   $��Center=�6c   �� 54   
   -   5        $ tel_port��54      $��6��6%   $	��top=�62   $ 1��6J   $��0��6X   $
 Wrap=�6h   $��20(�6}   �� 55   
   -   5        $ email��55      $��6��6"   $	��top=�6/   $ 1��6G   $��2��6U   $
 Wrap=�6e   $��20(�6z   �� 56   
   -   5         ��Name$ service��56      $��6��6#   $	��top=�60   $��4��6I   $��Choix du service��6Y   $��20(�6u   6�   �� 58   
   $��7��6   $��0��6"   $
��Wrap=�62   $
��Site��6F   $��20(�6R   $��Center=�6`   �� 59   
   $��7��6   $��2��6"   $
��Wrap=�62   $��Mot de passe��6F   $��20(�6Z   $��Center=�6h   �� 5:   
   $��7��6   $��4��6"   $
��Wrap=�62   $��Confirmation mot de passe��6F   $��20(�6g   $��Center=�6u   �� 5<   
   -   5        $
 site��5<      $��8��6    $	��top=�6-   $��0��6F   $��Choix du site��6W   $��20(�6p   6~   G� 5=   
   -   5         G�Name$ mot_de_passe��5=      $��8��6,   $	��top=�69   $��2��6R   $��20(�6d   G� 5>   
   -	   5        $ confirmation_mot_de_passe��5>      $��8��6:   $	��top=�6G   $��4��6`   $��20(�6r   �� 5?   
   -
   5        	 ��Name$	 isadmin��5?      $��Administrateur��6$   $��center=�6=   $��10��6Z   $��Center=�6h   $��20(�6�   �� 5A   
   -   5        $��10��5A      $��2��6   $��20(�6/   $��Modification��6>   6U   5C      5D      