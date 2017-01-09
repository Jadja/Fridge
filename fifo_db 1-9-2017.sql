-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jan 09, 2017 at 03:12 PM
-- Server version: 5.7.7-rc-log
-- PHP Version: 7.0.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `fifo db`
--

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `Name` varchar(45) NOT NULL,
  `General_exp_date` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`Name`, `General_exp_date`) VALUES
('Broodbeleg', NULL),
('Drinken', NULL),
('Eieren', NULL),
('Gevogelte', NULL),
('Groente', NULL),
('Kant-en-klaar', NULL),
('Overige', NULL),
('Rood vlees', NULL),
('Vega', NULL),
('Vis', NULL),
('Zuivel', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `food`
--

CREATE TABLE `food` (
  `Add_date` date NOT NULL,
  `Product` varchar(15) NOT NULL,
  `ID` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `food`
--

INSERT INTO `food` (`Add_date`, `Product`, `ID`) VALUES
('2016-12-11', '051469122401', 1006),
('2016-12-12', '051469122401', 1007),
('2016-12-13', '051469122401', 1008),
('2016-12-14', '051469122401', 1009),
('2016-12-15', '051469122401', 1010),
('2016-12-16', '051469122401', 1011),
('2016-12-17', '051469122401', 1012),
('2016-12-18', '051469122401', 1013),
('2016-12-19', '051469122401', 1014),
('2016-12-20', '051469122401', 1015),
('2016-12-21', '051469122401', 1016),
('2016-12-22', '051469122401', 1017),
('2016-12-23', '051469122401', 1018),
('2016-12-24', '051469122401', 1019),
('2016-12-25', '051469122401', 1020),
('2016-12-26', '051469122401', 1021),
('2016-12-27', '051469122401', 1022),
('2016-12-28', '051469122401', 1023),
('2016-12-29', '051469122401', 1024),
('2016-12-30', '222222222222', 1025),
('2016-12-31', '222222222222', 1026),
('2017-01-01', '222222222222', 1027),
('2017-01-02', '111111111111', 1028),
('2017-01-03', '111111111111', 1030),
('2017-01-04', '051469122401', 1031),
('2017-01-08', '051469122401', 1032);

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `ID` varchar(15) NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Expiration_time` int(11) DEFAULT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `Category` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`ID`, `Name`, `Expiration_time`, `Description`, `Category`) VALUES
('051469122401', 'Juicy Water', 20, 'Water met een smaakje.', 'Drinken'),
('111111111111', 'test', 50, 'uytyug', 'Groente'),
('222222222222', 'test2', 65, 'jgyuguygog', 'Groente'),
('876869868677', 'Poopy Bread', 40, 'Brown-ish Green-ish Bread-ish', 'Overige');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`Name`);

--
-- Indexes for table `food`
--
ALTER TABLE `food`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `product_id_idx` (`Product`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `category_FK_idx` (`Category`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `food`
--
ALTER TABLE `food`
  MODIFY `ID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1055;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `food`
--
ALTER TABLE `food`
  ADD CONSTRAINT `food` FOREIGN KEY (`Product`) REFERENCES `product` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
