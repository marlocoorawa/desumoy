   M S B A M L   `   `   `  ����(  $Aplikasi Pendataan Perlombaan Renang;    5Aplikasi_Pendataan_Perlombaan_Renang.KelolaPerlombaan   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	      	withStyle#��[  5   	     � Title$  Kelola Perlombaan��5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5
   
   �� 5      $	��100 �6   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   �� $��0��6   ��5      �� 5        palleteBlue1 �� Color# [ 6"   5      �� 5   
     headerStyle#��[ 6   Kelola Perlombaan5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��	10,10,0,0q�6;   .+�5      �� .��6   
Perlombaan6    �� 5      -   5        $��listPerlombaanCB��5      $	��400��6/   6c   5      �� 5   
   $��2��6   $��10q�6"   .@�5      �� ��5      �� 5      $
��Bold"�6   .��6.   Data Sekolah6<   .��5!      �� -   5        $��listViewSekolah��5!       �� View 5"      �� 5#      .P�5$      �� $��Nama Sekolah��6-    �� Width$	 150��6p    �� DisplayMemberBinding 6C   �� *NamaSekolah+6~   �� 5%      $��Alamat Sekolah��6-   $	 150��6t    6E   �� *AlamatSekolah+6�   �� 5&      $��Email Sekolah��6-   $	 150��6r    6D   �� *EmailSekolah+6�   �� 5'      $��
No Contact��6-   $	 140��6l    6A   �� *	NoContact+6z   �� 5(      $��Nama Pendaftar��6-   $	 140��6t    6E   �� *NamaPendaftar+6�   5)      5+      5,      �� 5-      ��5.      �� 5/      $
��Bold"�6   .��6.   Data Peserta6<   .��51      �� -   5        $��listViewPeserta��51       52      �� 53      .P�54      �� $��Nama Peserta��6-   $
 Auto��6p    6C   �� *NamaPeserta+6   �� 55      $��Jenis Kelamin��6-   $	 100��6D    �� CellTemplate 56   "   �� 57   &   .R�58   *   �� .+�59   .   �� ��5:   2   �� 5;   6   	 �� 
TargetType"	 ��6<   .�5<   :   �� 
 �� Property
 � �� �� Value$ 	Perempuan��6T    �� Triggers 5=   :   �� 5>   >    �� Binding 6J   �� *JenisKelamin+ �� Value True6k   .a�5?   B   �� 
 � ��$ Laki - Laki��6\   5@   ?   5B   7   5D   /   5E   +   5F   '   5H      �� 5I      $��Tanggal Lahir��6-   $	 100��6x    6D   �� *TanggalLahirString+6�   �� 5J      $��Kelompok��6-   $	 100��6v    6?   �� *Kelompok.NamaKelompok+6�   �� 5K      $��	Bebas 25m��6-   $ 80��6j    6@   �� *
Bebas25m+6w   �� 5L      $��	Bebas 50m��6-   $ 80��6j    6@   �� *
Bebas50m+6w   �� 5M      $��Dada 25m��6-   $ 80��6h    6?   �� *	Dada25m+6u   �� 5N      $��Dada 50m��6-   $ 80��6h    6?   �� *	Dada50m+6u   �� 5O      $��Kupu - kupu 50m��6-   $	 110��6p    6F   �� *
KupuKupu+6~   �� 5P      $��Punggung 50m��6-   $	 100��6m    6C   �� *
Punggung+6{   �� 5Q      $��Estafet 4x25m��6-   $	 100��6m    6D   �� *	Estafet+6{   5R      5T      5U      5V      �� 5W   
   -   5        $��3��5W      $
��Left=�6   $	��150��69   $��25��6E   $��	15,0,0,10q�6Q   .��6�   Kembali Ke Menu Utama6�   �� 5X   
   -   5        $��3��5X      $��Right=�6   $��80��6:   $��25��6E   $��	0,0,15,10q�6Q   .��6v   
Buat Acara6�   5Y      5Z      