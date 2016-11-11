-- phpMyAdmin SQL Dump
-- version 4.5.0.2
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Nov 09, 2016 at 09:39 PM
-- Server version: 10.0.17-MariaDB
-- PHP Version: 5.6.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `perlombaan_renang`
--
CREATE DATABASE IF NOT EXISTS `perlombaan_renang` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `perlombaan_renang`;

-- --------------------------------------------------------

--
-- Table structure for table `hasil_lomba`
--

CREATE TABLE `hasil_lomba` (
  `kode_perlombaan` char(10) NOT NULL,
  `kode_acara` char(3) NOT NULL,
  `kode_sekolah` char(3) NOT NULL,
  `kode_peserta` char(3) NOT NULL,
  `seri` int(11) NOT NULL,
  `waktu` time(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `kelompok`
--

CREATE TABLE `kelompok` (
  `kode_perlombaan` char(10) NOT NULL,
  `kode_kelompok` varchar(12) NOT NULL,
  `nama_kelompok` varchar(256) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `perlombaan`
--

CREATE TABLE `perlombaan` (
  `kode_perlombaan` char(10) NOT NULL,
  `nama_perlombaan` varchar(256) NOT NULL,
  `tanggal_perlombaan` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `peserta`
--

CREATE TABLE `peserta` (
  `kode_perlombaan` char(10) NOT NULL,
  `kode_sekolah` char(3) NOT NULL,
  `kode_peserta` char(3) NOT NULL,
  `kode_kelompok` varchar(12) NOT NULL,
  `nama_peserta` varchar(256) NOT NULL,
  `tanggal_lahir` date NOT NULL,
  `jenis_kelamin` tinyint(1) NOT NULL,
  `bebas_25m` time(3) NOT NULL,
  `bebas_50m` time(3) NOT NULL,
  `dada_25m` time(3) NOT NULL,
  `dada_50m` time(3) NOT NULL,
  `kupu_kupu_50m` time(3) NOT NULL,
  `punggung_50m` time(3) NOT NULL,
  `estafet_4x25m` time(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sekolah`
--

CREATE TABLE `sekolah` (
  `kode_perlombaan` char(10) NOT NULL,
  `kode_sekolah` char(3) NOT NULL,
  `nama_sekolah` varchar(256) NOT NULL,
  `alamat` varchar(512) NOT NULL,
  `no_contact` varchar(14) NOT NULL,
  `email` varchar(128) NOT NULL,
  `nama_pendaftar` varchar(256) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `hasil_lomba`
--
ALTER TABLE `hasil_lomba`
  ADD PRIMARY KEY (`kode_perlombaan`,`kode_sekolah`,`kode_peserta`),
  ADD KEY `kode_perlombaan` (`kode_perlombaan`),
  ADD KEY `kode_sekolah` (`kode_sekolah`),
  ADD KEY `kode_peserta` (`kode_peserta`);

--
-- Indexes for table `kelompok`
--
ALTER TABLE `kelompok`
  ADD PRIMARY KEY (`kode_kelompok`,`kode_perlombaan`),
  ADD KEY `kelompok_kode_perlombaan_relationship` (`kode_perlombaan`);

--
-- Indexes for table `perlombaan`
--
ALTER TABLE `perlombaan`
  ADD PRIMARY KEY (`kode_perlombaan`);

--
-- Indexes for table `peserta`
--
ALTER TABLE `peserta`
  ADD PRIMARY KEY (`kode_perlombaan`,`kode_sekolah`,`kode_peserta`),
  ADD KEY `kode_perlombaan` (`kode_perlombaan`),
  ADD KEY `kode_sekolah` (`kode_sekolah`),
  ADD KEY `kode_kelompok` (`kode_kelompok`),
  ADD KEY `peserta_kode_kelompok_relationship` (`kode_perlombaan`,`kode_kelompok`);

--
-- Indexes for table `sekolah`
--
ALTER TABLE `sekolah`
  ADD PRIMARY KEY (`kode_perlombaan`,`kode_sekolah`),
  ADD KEY `kode_perlombaan` (`kode_perlombaan`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `hasil_lomba`
--
ALTER TABLE `hasil_lomba`
  ADD CONSTRAINT `hasil_lomba_kode_peserta_relationship` FOREIGN KEY (`kode_perlombaan`,`kode_sekolah`,`kode_peserta`) REFERENCES `peserta` (`kode_perlombaan`, `kode_sekolah`, `kode_peserta`);

--
-- Constraints for table `kelompok`
--
ALTER TABLE `kelompok`
  ADD CONSTRAINT `kelompok_kode_perlombaan_relationship` FOREIGN KEY (`kode_perlombaan`) REFERENCES `perlombaan` (`kode_perlombaan`);

--
-- Constraints for table `peserta`
--
ALTER TABLE `peserta`
  ADD CONSTRAINT `peserta_kode_kelompok_relationship` FOREIGN KEY (`kode_perlombaan`,`kode_kelompok`) REFERENCES `kelompok` (`kode_perlombaan`, `kode_kelompok`),
  ADD CONSTRAINT `peserta_kode_sekolah_relationship` FOREIGN KEY (`kode_perlombaan`,`kode_sekolah`) REFERENCES `sekolah` (`kode_perlombaan`, `kode_sekolah`);

--
-- Constraints for table `sekolah`
--
ALTER TABLE `sekolah`
  ADD CONSTRAINT `sekolah_kode_perlombaan_relationship` FOREIGN KEY (`kode_perlombaan`) REFERENCES `perlombaan` (`kode_perlombaan`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
