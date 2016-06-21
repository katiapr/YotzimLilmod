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
-- Table structure for table `tb_students`
--

DROP TABLE IF EXISTS `tb_students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_students` (
  `StudentID` int(11) NOT NULL AUTO_INCREMENT,
  `StudentIDNumber` int(11) NOT NULL DEFAULT '0',
  `StudentName` varchar(45) DEFAULT ' ',
  `StudentLastName` varchar(45) DEFAULT NULL,
  `StudentPhoneNumber` varchar(45) DEFAULT NULL,
  `StudentEmail` varchar(45) DEFAULT NULL,
  `StudentCity` varchar(45) DEFAULT NULL,
  `Course` varchar(45) DEFAULT NULL,
  `Note` varchar(512) DEFAULT NULL,
  `TeacherID` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`StudentID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_students`
--

LOCK TABLES `tb_students` WRITE;
/*!40000 ALTER TABLE `tb_students` DISABLE KEYS */;
INSERT INTO `tb_students` VALUES (1,1,'חיים','שטרן','1111111','hayim680@gmail.com','ראשון לציון','מתמטיקה','שגד',1),(2,2222222,'צבי','מנדלסון','0','mandy32355@gmail.com','רמת גן',NULL,'משפטים',0),(3,3333333,'יהודה','ולנדמן','050-2857582','7721939@gmail.com','רמת גן',NULL,'מתחיל מכינה והשלמת בגרויות במכללת לוינסקי',0),(7,1,'א','א','א','א','א','א','א',0);
/*!40000 ALTER TABLE `tb_students` ENABLE KEYS */;
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
