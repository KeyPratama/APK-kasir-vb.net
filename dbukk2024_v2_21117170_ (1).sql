-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 26, 2024 at 04:26 AM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbukk2024.v2(21117170)`
--

-- --------------------------------------------------------

--
-- Table structure for table `barang`
--

CREATE TABLE `barang` (
  `ID_BARANG` int(11) NOT NULL,
  `NAMA_BARANG` varchar(250) DEFAULT NULL,
  `KATEGORI` varchar(100) DEFAULT NULL,
  `SATUAN` varchar(100) DEFAULT NULL,
  `HARGA_BELI` double DEFAULT NULL,
  `HARGA_JUAL` double DEFAULT NULL,
  `STOK` double DEFAULT NULL,
  `KETERANGAN` varchar(250) DEFAULT NULL,
  `BARCODE` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `barang`
--

INSERT INTO `barang` (`ID_BARANG`, `NAMA_BARANG`, `KATEGORI`, `SATUAN`, `HARGA_BELI`, `HARGA_JUAL`, `STOK`, `KETERANGAN`, `BARCODE`) VALUES
(1, 'Lee Mineral', 'Air Mineral', 'Botol', 5500, 6000, 360, '-', '-'),
(3, 'Buku', 'Alat Tulis', 'Pcs', 2000, 3000, 10, '-', '1827364'),
(4, 'AIR', 'Air Mineral', 'Botol', 1, 2, 0, 'AIR BOTOLAN', '977654');

-- --------------------------------------------------------

--
-- Table structure for table `pelanggan`
--

CREATE TABLE `pelanggan` (
  `ID_PELANGGAN` int(11) NOT NULL,
  `NAMA_PELANGGAN` varchar(50) DEFAULT NULL,
  `ALAMAT` varchar(250) DEFAULT NULL,
  `NOMOR_TELEPON` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `pelanggan`
--

INSERT INTO `pelanggan` (`ID_PELANGGAN`, `NAMA_PELANGGAN`, `ALAMAT`, `NOMOR_TELEPON`) VALUES
(2, 'customer', '-', '-'),
(4, 'Daffa', '-', '-'),
(5, 'sukma', '=', '085933265374');

-- --------------------------------------------------------

--
-- Table structure for table `pemasok`
--

CREATE TABLE `pemasok` (
  `ID_PEMASOK` int(11) NOT NULL,
  `NAMA_PEMASOK` varchar(50) DEFAULT NULL,
  `ALAMAT` varchar(250) DEFAULT NULL,
  `NOMOR_TELEPON` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `pemasok`
--

INSERT INTO `pemasok` (`ID_PEMASOK`, `NAMA_PEMASOK`, `ALAMAT`, `NOMOR_TELEPON`) VALUES
(2, 'PT.INDOFOOD', '-', '-'),
(3, 'PT.Mele', '-', '-'),
(4, 'NARMADA', '_', '_');

-- --------------------------------------------------------

--
-- Table structure for table `pembelian`
--

CREATE TABLE `pembelian` (
  `ID_PEMBELIAN` int(11) NOT NULL,
  `TANGGAL` datetime DEFAULT NULL,
  `ID_PEMASOK` int(11) DEFAULT NULL,
  `TOTAL_PEMBELIAN` double DEFAULT NULL,
  `POTONGAN` double DEFAULT NULL,
  `METODE_PEMBAYARAN` varchar(250) DEFAULT NULL,
  `KETERANGAN` varchar(250) DEFAULT NULL,
  `ID_PENGGUNA` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `pembelian`
--

INSERT INTO `pembelian` (`ID_PEMBELIAN`, `TANGGAL`, `ID_PEMASOK`, `TOTAL_PEMBELIAN`, `POTONGAN`, `METODE_PEMBAYARAN`, `KETERANGAN`, `ID_PENGGUNA`) VALUES
(1, '2024-04-23 00:00:00', 2, 11000, 0, 'CASH', '-', 1),
(2, '2024-04-23 00:00:00', 2, 165000, 0, 'CASH', '-', 1),
(3, '2024-04-23 00:00:00', 2, 165000, 0, 'CASH', '-', 1),
(4, '2024-04-24 00:00:00', 2, 100000, 0, 'CASH', '-', 4),
(5, '2024-04-24 00:00:00', 2, 20000, 0, 'CASH', '', 5),
(6, '2024-04-24 00:00:00', 4, 1, -31, 'CASH', 'AIR BOTOLAN', 6);

-- --------------------------------------------------------

--
-- Table structure for table `pembelian_detil`
--

CREATE TABLE `pembelian_detil` (
  `ID_BARANG` int(11) DEFAULT NULL,
  `HARGA_SATUAN` double DEFAULT NULL,
  `JUMLAH` double DEFAULT NULL,
  `TOTAL_HARGA` double DEFAULT NULL,
  `ID_PEMBELIAN` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `pembelian_detil`
--

INSERT INTO `pembelian_detil` (`ID_BARANG`, `HARGA_SATUAN`, `JUMLAH`, `TOTAL_HARGA`, `ID_PEMBELIAN`) VALUES
(1, 5500, 2, 11000, 1),
(1, 5500, 30, 165000, 2),
(1, 5500, 30, 165000, 3),
(3, 2000, 50, 100000, 4),
(1, 2000, 300, 600000, 1),
(3, 2000, 10, 20000, 5),
(4, 1, 1, 1, 6);

--
-- Triggers `pembelian_detil`
--
DELIMITER $$
CREATE TRIGGER `trTambahStok` AFTER INSERT ON `pembelian_detil` FOR EACH ROW BEGIN
    DECLARE StokBaru Double;

    -- Mengecek apakah data barang sudah ada di tabel barang
    IF NOT EXISTS (SELECT 1 FROM barang WHERE ID_BARANG = NEW.ID_BARANG) THEN
        -- Jika tidak ada, tambahkan data barang baru
        INSERT INTO barang (ID_BARANG, NAMA_BARANG, STOK) VALUES (NEW.ID_BARANG, 'Nama Barang Baru', NEW.JUMLAH);
    ELSE
        -- Jika sudah ada, tambahkan jumlah stok
        SELECT STOK + NEW.JUMLAH INTO StokBaru FROM barang WHERE ID_BARANG = NEW.ID_BARANG;
        UPDATE barang SET STOK = StokBaru WHERE ID_BARANG = NEW.ID_BARANG;
    END IF;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `pengguna`
--

CREATE TABLE `pengguna` (
  `ID_PENGGUNA` int(11) NOT NULL,
  `NAMA_PENGGUNA` varchar(50) NOT NULL,
  `ALAMAT` varchar(250) NOT NULL,
  `NOMOR_TELEPON` varchar(50) NOT NULL,
  `USERNAME` varchar(100) NOT NULL,
  `PASSWORD` varchar(100) NOT NULL,
  `HAK_AKSES` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `pengguna`
--

INSERT INTO `pengguna` (`ID_PENGGUNA`, `NAMA_PENGGUNA`, `ALAMAT`, `NOMOR_TELEPON`, `USERNAME`, `PASSWORD`, `HAK_AKSES`) VALUES
(1, 'raya', '-', '-', 'raya1', 'raya05', 'ADMIN'),
(3, 'daffa', '-', '-', 'daffa1', 'daffa1', 'KASIR'),
(4, 'Raya', '-', '-', 'Raya1', 'Raya1', 'ADMIN'),
(5, 'ARI', '-', '00897129197197', 'ARI', '123', 'ADMIN'),
(6, 'sukma', '=', '085933265374', 'sukma', '1234', 'ADMIN');

-- --------------------------------------------------------

--
-- Table structure for table `penjualan`
--

CREATE TABLE `penjualan` (
  `ID_PENJUALAN` int(11) NOT NULL,
  `TANGGAL` datetime DEFAULT NULL,
  `ID_PELANGGAN` int(11) DEFAULT NULL,
  `TOTAL_PENJUALAN` double DEFAULT NULL,
  `POTONGAN` double DEFAULT NULL,
  `METODE_PEMBAYARAN` varchar(50) DEFAULT NULL,
  `KETERANGAN` varchar(250) DEFAULT NULL,
  `ID_PENGGUNA` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `penjualan`
--

INSERT INTO `penjualan` (`ID_PENJUALAN`, `TANGGAL`, `ID_PELANGGAN`, `TOTAL_PENJUALAN`, `POTONGAN`, `METODE_PEMBAYARAN`, `KETERANGAN`, `ID_PENGGUNA`) VALUES
(1, '2024-04-23 00:00:00', 2, 11000, 0, 'CASH', '-', 1),
(2, '2024-04-24 00:00:00', 2, 80000, 0, 'CASH', '-', 4),
(3, '2024-04-24 00:00:00', 2, 20000, 0, 'CASH', '', 5),
(4, '2024-04-24 00:00:00', 5, 1, 0, 'CASH', 'AIR BOTOLAN', 6);

-- --------------------------------------------------------

--
-- Table structure for table `penjualan_detil`
--

CREATE TABLE `penjualan_detil` (
  `ID_BARANG` int(11) DEFAULT NULL,
  `HARGA_SATUAN` double DEFAULT NULL,
  `JUMLAH` double DEFAULT NULL,
  `TOTAL_HARGA` double DEFAULT NULL,
  `ID_PENJUALAN` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `penjualan_detil`
--

INSERT INTO `penjualan_detil` (`ID_BARANG`, `HARGA_SATUAN`, `JUMLAH`, `TOTAL_HARGA`, `ID_PENJUALAN`) VALUES
(1, 5500, 2, 11000, 1),
(3, 2000, 40, 80000, 2),
(3, 2000, 10, 20000, 3),
(4, 1, 1, 1, 4);

--
-- Triggers `penjualan_detil`
--
DELIMITER $$
CREATE TRIGGER `trKurangStock` AFTER INSERT ON `penjualan_detil` FOR EACH ROW BEGIN
    DECLARE StokBaru Double;

    -- Mengecek apakah data barang sudah ada di tabel barang
    IF NOT EXISTS (SELECT 1 FROM barang WHERE ID_BARANG = NEW.ID_BARANG) THEN
        -- Jika tidak ada, tambahkan data barang baru
        INSERT INTO barang (ID_BARANG, NAMA_BARANG, STOK) VALUES (NEW.ID_BARANG, 'Nama Barang Baru', NEW.JUMLAH);
    ELSE
        -- Jika sudah ada, kurangkan jumlah stok
        SELECT STOK - NEW.JUMLAH INTO StokBaru FROM barang WHERE ID_BARANG = NEW.ID_BARANG;
        UPDATE barang SET STOK = StokBaru WHERE ID_BARANG = NEW.ID_BARANG;
    END IF;
END
$$
DELIMITER ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `barang`
--
ALTER TABLE `barang`
  ADD PRIMARY KEY (`ID_BARANG`);

--
-- Indexes for table `pelanggan`
--
ALTER TABLE `pelanggan`
  ADD PRIMARY KEY (`ID_PELANGGAN`);

--
-- Indexes for table `pemasok`
--
ALTER TABLE `pemasok`
  ADD PRIMARY KEY (`ID_PEMASOK`);

--
-- Indexes for table `pembelian`
--
ALTER TABLE `pembelian`
  ADD PRIMARY KEY (`ID_PEMBELIAN`),
  ADD KEY `ID_PEMASOK` (`ID_PEMASOK`,`ID_PENGGUNA`),
  ADD KEY `ID_PENGGUNA` (`ID_PENGGUNA`),
  ADD KEY `ID_PEMASOK_2` (`ID_PEMASOK`,`ID_PENGGUNA`);

--
-- Indexes for table `pembelian_detil`
--
ALTER TABLE `pembelian_detil`
  ADD KEY `ID_BARANG` (`ID_BARANG`,`ID_PEMBELIAN`),
  ADD KEY `ID_PEMBELIAN` (`ID_PEMBELIAN`);

--
-- Indexes for table `pengguna`
--
ALTER TABLE `pengguna`
  ADD PRIMARY KEY (`ID_PENGGUNA`);

--
-- Indexes for table `penjualan`
--
ALTER TABLE `penjualan`
  ADD PRIMARY KEY (`ID_PENJUALAN`),
  ADD KEY `ID_PELANGGAN` (`ID_PELANGGAN`,`ID_PENGGUNA`),
  ADD KEY `ID_PENGGUNA` (`ID_PENGGUNA`);

--
-- Indexes for table `penjualan_detil`
--
ALTER TABLE `penjualan_detil`
  ADD KEY `ID_BARANG` (`ID_BARANG`,`ID_PENJUALAN`),
  ADD KEY `ID_PENJUALAN` (`ID_PENJUALAN`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `barang`
--
ALTER TABLE `barang`
  MODIFY `ID_BARANG` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `pelanggan`
--
ALTER TABLE `pelanggan`
  MODIFY `ID_PELANGGAN` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `pemasok`
--
ALTER TABLE `pemasok`
  MODIFY `ID_PEMASOK` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `pengguna`
--
ALTER TABLE `pengguna`
  MODIFY `ID_PENGGUNA` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `penjualan`
--
ALTER TABLE `penjualan`
  MODIFY `ID_PENJUALAN` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `pembelian`
--
ALTER TABLE `pembelian`
  ADD CONSTRAINT `pembelian_ibfk_1` FOREIGN KEY (`ID_PEMASOK`) REFERENCES `pemasok` (`ID_PEMASOK`),
  ADD CONSTRAINT `pembelian_ibfk_2` FOREIGN KEY (`ID_PENGGUNA`) REFERENCES `pengguna` (`ID_PENGGUNA`);

--
-- Constraints for table `pembelian_detil`
--
ALTER TABLE `pembelian_detil`
  ADD CONSTRAINT `pembelian_detil_ibfk_1` FOREIGN KEY (`ID_BARANG`) REFERENCES `barang` (`ID_BARANG`),
  ADD CONSTRAINT `pembelian_detil_ibfk_2` FOREIGN KEY (`ID_PEMBELIAN`) REFERENCES `pembelian` (`ID_PEMBELIAN`);

--
-- Constraints for table `penjualan`
--
ALTER TABLE `penjualan`
  ADD CONSTRAINT `penjualan_ibfk_1` FOREIGN KEY (`ID_PELANGGAN`) REFERENCES `pelanggan` (`ID_PELANGGAN`),
  ADD CONSTRAINT `penjualan_ibfk_2` FOREIGN KEY (`ID_PENGGUNA`) REFERENCES `pengguna` (`ID_PENGGUNA`);

--
-- Constraints for table `penjualan_detil`
--
ALTER TABLE `penjualan_detil`
  ADD CONSTRAINT `penjualan_detil_ibfk_1` FOREIGN KEY (`ID_BARANG`) REFERENCES `barang` (`ID_BARANG`),
  ADD CONSTRAINT `penjualan_detil_ibfk_2` FOREIGN KEY (`ID_PENJUALAN`) REFERENCES `penjualan` (`ID_PENJUALAN`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
