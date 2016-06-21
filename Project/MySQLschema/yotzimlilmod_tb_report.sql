-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: yotzimlilmod
-- ------------------------------------------------------
-- Server version	5.7.12-log

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
-- Table structure for table `tb_report`
--

DROP TABLE IF EXISTS `tb_report`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_report` (
  `ReportID` int(11) NOT NULL AUTO_INCREMENT,
  `TeacherID` int(11) NOT NULL DEFAULT '0',
  `ProgramName` varchar(45) DEFAULT NULL,
  `January` decimal(18,2) NOT NULL DEFAULT '0.00',
  `February` decimal(18,2) NOT NULL DEFAULT '0.00',
  `March` decimal(18,2) NOT NULL DEFAULT '0.00',
  `April` decimal(18,2) NOT NULL DEFAULT '0.00',
  `May` decimal(18,2) NOT NULL DEFAULT '0.00',
  `June` decimal(18,2) NOT NULL DEFAULT '0.00',
  `September` decimal(18,2) NOT NULL DEFAULT '0.00',
  `October` decimal(18,2) NOT NULL DEFAULT '0.00',
  `November` decimal(18,2) NOT NULL DEFAULT '0.00',
  `December` decimal(18,2) NOT NULL DEFAULT '0.00',
  `Total` decimal(18,2) NOT NULL DEFAULT '0.00',
  `IsDelay` bit(1) DEFAULT b'0',
  `IsInstruction` bit(1) DEFAULT b'0',
  `Note` varchar(512) DEFAULT NULL,
  PRIMARY KEY (`ReportID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_report`
--

LOCK TABLES `tb_report` WRITE;
/*!40000 ALTER TABLE `tb_report` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_report` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-06-21 13:25:32
