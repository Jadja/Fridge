CREATE DATABASE  IF NOT EXISTS `fifo db` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `fifo db`;
-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: fifo db
-- ------------------------------------------------------
-- Server version	5.7.10-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `category` (
  `Name` varchar(45) NOT NULL,
  `General_exp_date` int(11) DEFAULT NULL,
  PRIMARY KEY (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES ('Broodbeleg',NULL),('Drinken',NULL),('Eieren',NULL),('Gevogelte',NULL),('Groente',NULL),('Kant-en-klaar',NULL),('Overige',NULL),('Rood vlees',NULL),('Vega',NULL),('Vis',NULL),('Zuivel',NULL);
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `food`
--

DROP TABLE IF EXISTS `food`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `food` (
  `ID` int(10) NOT NULL,
  `Add_date` date NOT NULL,
  `Product` varchar(15) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `product_id_idx` (`Product`),
  CONSTRAINT `food` FOREIGN KEY (`Product`) REFERENCES `product` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `food`
--

LOCK TABLES `food` WRITE;
/*!40000 ALTER TABLE `food` DISABLE KEYS */;
INSERT INTO `food` VALUES (1006,'2016-12-12','051469122401'),(1007,'2016-12-12','051469122401'),(1008,'2016-12-12','051469122401'),(1009,'2016-12-12','051469122401'),(1010,'2016-12-12','051469122401'),(1011,'2016-12-12','051469122401'),(1012,'2016-12-12','051469122401'),(1013,'2016-12-12','051469122401'),(1014,'2016-12-12','051469122401'),(1015,'2016-12-12','051469122401'),(1016,'2016-12-12','051469122401'),(1017,'2016-12-12','051469122401'),(1018,'2016-12-12','051469122401'),(1019,'2016-12-12','051469122401'),(1020,'2016-12-12','051469122401'),(1021,'2016-12-12','051469122401'),(1022,'2016-12-12','051469122401'),(1023,'2016-12-12','051469122401'),(1024,'2016-12-12','051469122401'),(1025,'2016-12-12','222222222222'),(1026,'2016-12-12','222222222222'),(1027,'2016-12-12','222222222222'),(1028,'2016-12-12','111111111111'),(1030,'2016-12-12','111111111111');
/*!40000 ALTER TABLE `food` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product` (
  `ID` varchar(15) NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Expiration_time` int(11) DEFAULT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `Category` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `category_FK_idx` (`Category`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES ('051469122401','Juicy Water',20,'Water met een smaakje.','Drinken'),('111111111111','test',50,'uytyug','Groente'),('222222222222','test2',65,'jgyuguygog','Groente'),('876869868677','Poopy Bread',40,'Brown-ish Green-ish Bread-ish','Overige');
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-01-10 13:30:36
