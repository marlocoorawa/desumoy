   M S B A M L   `   `   `  ����%  !Aplikasi Client Perlombaan Renang2    ,Aplikasi_Client_Perlombaan_Renang.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	      	withStyle#��[  5   	     � Title$'  !Aplikasi Client Perlombaan Renang��5   	   .��5      �  � ColumnDefinitions 5   
   �� 5	      $��* �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��10 �6   �� 5      $��30 �6   �� 5      $��5 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   ��5      �� 5        palleteBlue1 �� Color# [ 6"   5      �� 5   
     headerStyle#��[ 6   #!Aplikasi Client Perlombaan Renang5      �� 5   
   $��2��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� $��0,0,10,0q�6   .��6&   
Perlombaan62   �� 5       -   5        $��listPerlombaanCB��5       $	��210��6/   6c   �� 5!      $��20,0,0,0q�6   .��6&   Acara6-   �� 5"      -   5        $��listAcaraCB��5"      $��50��6*   6X   5#      �� 5$   
   $��4��6   $ 
Horizontal=�6"   .+�5%      �� .��6   Nama Peserta6"   �� 5&      -   5        $��listPesertaCB��5&      $	��210��6,   6:   5'      �� 5(   
   $��5��6   $��Center=�6   $��0,5,0,0q�6:   $��14(�6K   $
��Bold"�6Y   .��6k   Waktu Lomba6x   �� 5)   
   -   5        $��
waktuLomba��5)      $��6��6   $��	10,4,10,4q�61   6F   �� 5*   
   -   5        $��7��5*      $	��200��6   $��30��6*   .��6K   Submit6S   5+      5,      