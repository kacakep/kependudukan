-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 09, 2023 at 07:01 AM
-- Server version: 10.4.25-MariaDB
-- PHP Version: 7.4.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `penduduk`
--

-- --------------------------------------------------------

--
-- Table structure for table `data_penduduk`
--

CREATE TABLE `data_penduduk` (
  `nik` varchar(16) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `no_kk` varchar(16) NOT NULL,
  `jk` enum('Laki laki','Perempuan') NOT NULL,
  `tgl_lahir` date NOT NULL,
  `pekerjaan` varchar(20) NOT NULL,
  `alamat` varchar(100) NOT NULL,
  `rt` varchar(4) NOT NULL,
  `rw` varchar(4) NOT NULL,
  `agama` varchar(25) NOT NULL,
  `pendidikan` varchar(25) NOT NULL,
  `username` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `kk`
--

CREATE TABLE `kk` (
  `no_kk` varchar(16) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `nik` varchar(16) NOT NULL,
  `jk` varchar(25) NOT NULL,
  `tmpt_lhr` varchar(20) NOT NULL,
  `tgl_lahir` date NOT NULL,
  `agama` enum('ISLAM','KRISTEN','KHATOLIK','HINDU','BUDHA','KONG HU CU') NOT NULL,
  `pendidikan` enum('SD','SMP','SMA','D3','D4','S1') NOT NULL,
  `pekerjaan` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `ktp`
--

CREATE TABLE `ktp` (
  `nik` varchar(16) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `tgl_lahir` date NOT NULL,
  `jk` varchar(25) NOT NULL,
  `alamat` varchar(100) NOT NULL,
  `rt` varchar(4) NOT NULL,
  `rw` varchar(4) NOT NULL,
  `agama` enum('ISLAM','KRISTEN','KHATOLIK','BUDDHA','HINDU','KONG HU CU') NOT NULL,
  `stat_kawin` enum('BELUM KAWIN','KAWIN') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `ktp`
--

INSERT INTO `ktp` (`nik`, `nama`, `tgl_lahir`, `jk`, `alamat`, `rt`, `rw`, `agama`, `stat_kawin`) VALUES
('3275032910000030', 'Irfannudin Naufal Andriansyah', '2013-02-21', 'Cowo', 'dfdsfsdfds', '11', '12', 'ISLAM', 'BELUM KAWIN');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `username` varchar(20) NOT NULL,
  `password` varchar(15) NOT NULL,
  `jabatan` enum('admin','pegawai') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`username`, `password`, `jabatan`) VALUES
('Anwar', '2', 'pegawai'),
('Naufal', '1', 'admin');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `data_penduduk`
--
ALTER TABLE `data_penduduk`
  ADD KEY `nik` (`nik`,`no_kk`),
  ADD KEY `no_kk` (`no_kk`),
  ADD KEY `username` (`username`);

--
-- Indexes for table `kk`
--
ALTER TABLE `kk`
  ADD PRIMARY KEY (`no_kk`);

--
-- Indexes for table `ktp`
--
ALTER TABLE `ktp`
  ADD PRIMARY KEY (`nik`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`username`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `data_penduduk`
--
ALTER TABLE `data_penduduk`
  ADD CONSTRAINT `data_penduduk_ibfk_1` FOREIGN KEY (`no_kk`) REFERENCES `kk` (`no_kk`),
  ADD CONSTRAINT `data_penduduk_ibfk_2` FOREIGN KEY (`nik`) REFERENCES `ktp` (`nik`),
  ADD CONSTRAINT `data_penduduk_ibfk_3` FOREIGN KEY (`username`) REFERENCES `user` (`username`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
