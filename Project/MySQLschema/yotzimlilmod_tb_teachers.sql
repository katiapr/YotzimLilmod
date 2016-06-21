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
-- Table structure for table `tb_teachers`
--

DROP TABLE IF EXISTS `tb_teachers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tb_teachers` (
  `TeacherID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `TeacherIDNumber` int(11) DEFAULT NULL,
  `TeacherName` varchar(45) DEFAULT NULL,
  `TeacherLastName` varchar(45) DEFAULT NULL,
  `CourseID` int(11) NOT NULL DEFAULT '0',
  `StudentID` int(11) DEFAULT '0',
  PRIMARY KEY (`TeacherID`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_teachers`
--

LOCK TABLES `tb_teachers` WRITE;
/*!40000 ALTER TABLE `tb_teachers` DISABLE KEYS */;
INSERT INTO `tb_teachers` VALUES (1,0,NULL,'ויקטוריה','סטרחוב',0,0),(2,0,NULL,'שולמית','וייס',0,0),(3,0,NULL,'איתי ','סטראוס',0,0),(4,0,NULL,'שי ','סידלניק',0,0),(5,0,NULL,'שירה','פטרק',0,0),(6,0,NULL,'יעל','וויטמן',0,0),(7,0,NULL,'רבקה','בן אדיבה',0,0),(8,0,NULL,'רוז','אינגלבי',0,0),(9,0,NULL,'ניקולאי','בוטיני',0,0),(10,0,NULL,'בר','ברטל',0,0),(11,1,NULL,'קטיה','פריגון',0,1),(12,1,NULL,'קטיה','פריגון',0,2),(13,6,NULL,'מעיין','אליהו',0,0),(14,7,NULL,'מעיין','אליהו',0,0),(15,8,NULL,'א','ב',0,0),(16,9,NULL,'שם פרטי','משפחה',0,0),(17,6,NULL,'אלעד','סעדיה',0,0),(18,8,NULL,'א','א',0,0),(19,9,NULL,'א','א',0,0),(20,10,NULL,'א','T',0,0);
/*!40000 ALTER TABLE `tb_teachers` ENABLE KEYS */;
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
