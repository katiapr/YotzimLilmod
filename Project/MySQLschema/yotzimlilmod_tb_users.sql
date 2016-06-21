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
-- Table structure for table `tb_users`
--

DROP TABLE IF EXISTS `tb_users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_users` (
  `UserID` int(11) NOT NULL AUTO_INCREMENT,
  `UserIDNumber` int(11) DEFAULT NULL,
  `UserName` varchar(45) NOT NULL,
  `UserFirstName` varchar(45) NOT NULL,
  `UserLastName` varchar(45) NOT NULL,
  `UserPassword` varchar(45) NOT NULL,
  `UserPhoneNumber` varchar(45) NOT NULL,
  `UserEmail` varchar(45) NOT NULL,
  `UserCity` varchar(45) NOT NULL,
  `Access` int(11) NOT NULL,
  `UserLastUpdate` datetime NOT NULL DEFAULT '2001-01-01 00:00:00',
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_users`
--

LOCK TABLES `tb_users` WRITE;
/*!40000 ALTER TABLE `tb_users` DISABLE KEYS */;
INSERT INTO `tb_users` VALUES (2,888888,'tomerye','תומר','ימיני','123456','tyemini@gmail.com','ירושלים','123456',2,'2001-01-01 00:00:00'),(5,123456,'leeka@gmail.com','לי','ביטון','9e2ba3bf','0511111111','leeka@gmail.com','ירושלים',2,'2001-01-01 00:00:00'),(6,1,'email@email.com','אלעד','סעדיה','107b28b1','email@email.com','ירושלים','2222',3,'2001-01-01 00:00:00'),(7,12345,'katiapr','קטיה','פריגון','123456','9999999','katiapr89@gmail.com','ירושלים',1,'2016-06-21 09:55:16');
/*!40000 ALTER TABLE `tb_users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-06-21 13:25:33
