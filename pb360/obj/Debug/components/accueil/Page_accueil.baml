   M S B A M L   `   `   `  ����@  <pb360, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:pb360.components.acceuilpb360.components.acceuil  5      +    %pb360.components.acceuil.Page_accueil   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:pb360.components.acceuil     5        N� Title$  Page_accueil��5	      .��5
      �  J� RenderTransformOrigin$ 0.503,0.548&�6    � ColumnDefinitions 5   
   �� 5      $��114.4 �6   �� 5      $
��116* �6   �� 5      $
��101* �6   �� 5      $
��157* �6   �� 5      $	��28* �6   �� 5      $
��284* �6    � RowDefinitions 5   
   �� 5      $	��35* �6   �� 5      $	��26* �6   �� 5      $	��73* �6   �� 5      $��6* �6   �� 5      $	��73* �6   �� 5      $��6* �6   �� 5      $	��73* �6   �� 5      $��6* �6   �� 5      $	��73* �6   �� 5      $��6* �6   �� 5      $	��72* �6   .+�5    
   �� 
�������$��11��6(   $��6��6:   �� 5!   
   -   5        $��retour��5!      $��15(�6   $��Retour��6J   $��0��6[   $��Center=�6h   $��Center=�6�   6�   �� 5"   
   -   5        $��service��5"      $��15(�6    $��Choix service��6R   $��2��6k   $��1��6{   $��Center=�6�   �� 5#   
   -   5        $
��site��5#      $��15(�6   $��
Choix site��6L   $��1��6b   $��1��6r   $��Center=�6   �� 5$   
   -   5        $��reinit��5$      $��15(�6   $��Réinitialiser��6Q   $��3��6j   $��1��6z   $��Center=�6�   o� 5%   
   -   5         o�Name$ onglet��5%      $��5��6    $��Center=�61   $��Center=�6L   .@�5&      m� $��Administration��6   $��20(�60   
���   �$
��Left=�6S   .@�5'      m� -   5         m�Name$ onglet_admin��5'      $��Gestion Salariés��62   $��18(�6j   m� 5(      -   5        $��Gestion Site��5(      $��18(�6L   m� 5)      -   5        $��Gestion Service��5)      $��18(�6R   5*      5+       � 5,   
   -	   5          �Name$ Contents_accueil��5,      $��11��6*   $��40(�6<   $��6��6J     � NavigationUIVisibility$ Hidden=�6_   $��0,35,0,-0.4q�6   �� 5.   
   -
   5         ��Name$ 	recherche��5.      $��10,1.8,10.4,0.6q�6%   $��1��6>   6K   &   System.Windows.Controls.DataGrid  5/   
   -   5        	  Name$	 listDataBiding_client��5/      $��2��62   $��9��6?   $��6��6P   
   
IsReadOnly
 .    SelectionMode$ Single=�6�      AutoGenerateColumns .  $��0,3.4,-5,-0.4q�6�    K� ZIndex 6d   �� *Zindex+��6�   �� *	clients+   Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$	 Nom��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *Nom+  52      $ Prénom��6%   $ 1* 69    6D   �� *Prenom+  53      $ n° de téléphone fixe��6%   $ 1* 6F    6Q   �� *Telfix+  54      $ n° de téléphone port��6%   $ 1* 6H    6S   �� *	Telport+  55      $ Email��6%   $ 2* 69    6D   �� *Email+  56      $ Service��6%   $ 1* 68    6C   �� *	Service+  57      $ Ville��6%   $ 1* 66    6A   �� *Ville+  58      $
 Pays��6%   $ 1* 65    6@   �� *Pays+5:      5;      5<      