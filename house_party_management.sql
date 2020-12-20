-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Dec 20, 2020 at 10:32 AM
-- Server version: 8.0.18
-- PHP Version: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `house_party_management`
--

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `Id` varchar(767) COLLATE utf8mb4_general_ci NOT NULL,
  `UserName` varchar(256) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `Name` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `BirthDate` date NOT NULL,
  `Gender` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `NormalizedUserName` varchar(256) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `Email` varchar(256) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `NormalizedEmail` varchar(256) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` text COLLATE utf8mb4_general_ci,
  `SecurityStamp` text COLLATE utf8mb4_general_ci,
  `ConcurrencyStamp` text COLLATE utf8mb4_general_ci,
  `PhoneNumber` text COLLATE utf8mb4_general_ci,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`Id`, `UserName`, `Name`, `BirthDate`, `Gender`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) VALUES
('9839595e-9ef4-49ec-9fe3-8ef5e22b22ed', 'ppeter', 'Próba Péter', '2020-12-20', 'férfi', 'PPETER', 'ppeter@gmail.com', 'PPETER@GMAIL.COM', 1, 'AQAAAAEAACcQAAAAEMGqPFcO8vAL8ip6vIGjJWWhrWr0M8DK1nqlyK/nGdpr4gf1Keu8z9g7dC0j+4I2Rw==', '5YZDP2VQYXSQSQLNHQSG55MVYXTQ3HXG', '4a032540-ab92-48e5-8320-a5096656722c', NULL, 0, 0, NULL, 1, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
