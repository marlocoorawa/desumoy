   M S B A M L   `   `   `  ����(  $Aplikasi Pendataan Perlombaan Renang;    5Aplikasi_Pendataan_Perlombaan_Renang.KelolaHasilLomba   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	      	withStyle#��[  5   	     � Title$  Lihat Hasil Lomba��5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5
   
   �� 5      $	��100 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   �� $��0��6   ��5      �� 5        palleteBlue1 �� Color# [ 6"   5      �� 5   
     headerStyle#��[ 6   Kelola Hasil Lomba5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��	10,10,0,0q�6;   .+�5      �� $��80��6   .��6   
Perlombaan6+   �� 5      -   5        $��listPerlombaanCB��5      $	��400��6/   6c   5      �� 5   
   $ 
Horizontal=�6   $��2��6.   $��	10,10,0,0q�6;   .+�5      �� $��80��6   .��6   
Kode Acara6+   �� 5       -   5        $��listAcaraCB��5       $	��400��6*   6Y   5!      �� 5"   
   $ 
Horizontal=�6   $��3��6.   $��	10,6,10,0q�6;   .+�5#      �� $��14(�6   $
��Bold"�6"   .��64   Nama Perlombaan6E   �� 5$      $��14(�6   $
��Bold"�6"   .��64   -67   �� 5%      $��14(�6   $
��Bold"�6"   .��64   Gaya Renang6A   5&      �� 5'   
   -   5        $��listViewHasilLomba��5'      $��4��6-   $��1��6:   $��10q�6J    �� View 5(      �� 5)      .P�5*      �� $��Nama Peserta��6%    �� Width$	 220��6h    �� DisplayMemberBinding 6;   �� *NamaPeserta+6v   �� 5+      $��Nama Sekolah��6%   $	 220��6h    6;   �� *NamaSekolah+6v   �� 5,      $��Waktu Daftar��6%   $	 110��6h    6;   �� *WaktuDaftar+6v   �� 5-      $��Waktu Lomba��6%   $	 110��6f    6:   �� *
WaktuLomba+6t   5/      51      �� 52   
   $��5��6   $
��Left=�6   $	��150��69   $��25��6E   $��	15,0,0,10q�6Q   .��6d   Kembali Ke Menu Utama6{   54      55      