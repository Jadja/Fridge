-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jan 08, 2017 at 06:10 PM
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
  `General_exp_time` int(11) DEFAULT NULL,
  `ID` int(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`Name`, `General_exp_time`, `ID`) VALUES
('Rood vlees', NULL, 1),
('Vleeswaren', NULL, 2),
('Zuivel', NULL, 3),
('Vis', NULL, 4),
('Groente', NULL, 5),
('Gevogelte', NULL, 6),
('Vega', NULL, 7),
('Kant-en-klaar', NULL, 8),
('Eieren', NULL, 9),
('Overige', NULL, 10),
('Drinken', NULL, 11),
('Walvisdeeltjes', 20170111, 12);

-- --------------------------------------------------------

--
-- Table structure for table `fridge`
--

CREATE TABLE `fridge` (
  `ID` int(15) NOT NULL,
  `Add_date` date NOT NULL,
  `Product` char(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `fridge`
--

INSERT INTO `fridge` (`ID`, `Add_date`, `Product`) VALUES
(1, '2017-01-01', '1'),
(2, '2017-01-05', '2'),
(3, '2016-12-25', '3'),
(4, '2016-01-25', '3'),
(5, '2016-01-11', '4');

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `ID` char(15) NOT NULL,
  `Name` varchar(45) DEFAULT NULL,
  `Expiration_time` int(11) DEFAULT NULL,
  `Description` varchar(45) DEFAULT NULL,
  `Category` int(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`ID`, `Name`, `Expiration_time`, `Description`, `Category`) VALUES
('1', 'Test_Product_1', 30, 'Test product that falls within category 1', 1),
('2', 'Test_Product_2', 10, 'Test product that falls within category 2', 2),
('3', 'Test_Product_3', 16, 'Test product that falls within category 2', 2),
('4', 'Test_Product_4', 500, 'Test product that falls within category 6', 6);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `fridge`
--
ALTER TABLE `fridge`
  ADD PRIMARY KEY (`ID`,`Add_date`,`Product`),
  ADD KEY `product_id_idx` (`Product`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `fk_Category_idx` (`Category`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `fridge`
--
ALTER TABLE `fridge`
  ADD CONSTRAINT `product_id` FOREIGN KEY (`Product`) REFERENCES `product` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `product`
--
ALTER TABLE `product`
  ADD CONSTRAINT `fk_Category` FOREIGN KEY (`Category`) REFERENCES `category` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
