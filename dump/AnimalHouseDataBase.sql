-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: localhost    Database: ah4c
-- ------------------------------------------------------
-- Server version	8.0.33

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `animalbreeds`
--

DROP TABLE IF EXISTS `animalbreeds`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `animalbreeds` (
  `animalbreed_id` int NOT NULL,
  `animal_typeid` int DEFAULT NULL,
  `animalbreed_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`animalbreed_id`),
  KEY `typeid_idx` (`animal_typeid`),
  CONSTRAINT `typeid` FOREIGN KEY (`animal_typeid`) REFERENCES `animaltypes` (`animaltype_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `animalbreeds`
--

LOCK TABLES `animalbreeds` WRITE;
/*!40000 ALTER TABLE `animalbreeds` DISABLE KEYS */;
INSERT INTO `animalbreeds` VALUES (1,1,'Британская короткошерстная'),(2,1,'Сиамская'),(3,2,'Лабрадор ретривер'),(4,2,'Немецкая овчарка'),(5,2,'Бультерьер'),(6,1,'Персидская'),(7,2,'Далматин'),(8,1,'Мейн-кун'),(9,2,'Пудель'),(10,1,'Сфинкс'),(11,2,'Чихуахуа'),(12,1,'Бенгальская');
/*!40000 ALTER TABLE `animalbreeds` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `animals`
--

DROP TABLE IF EXISTS `animals`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `animals` (
  `animal_id` int NOT NULL,
  `animal_name` varchar(45) DEFAULT NULL,
  `animal_clientid` int DEFAULT NULL,
  `animal_gen` char(1) DEFAULT NULL,
  `animal_breedid` int DEFAULT NULL,
  `animal_height` double DEFAULT NULL,
  `animal_weight` double DEFAULT NULL,
  `animal_old` int DEFAULT NULL,
  PRIMARY KEY (`animal_id`),
  KEY `clientid_idx` (`animal_clientid`),
  KEY `breedid_idx` (`animal_breedid`),
  CONSTRAINT `breedid` FOREIGN KEY (`animal_breedid`) REFERENCES `animalbreeds` (`animalbreed_id`),
  CONSTRAINT `clientid` FOREIGN KEY (`animal_clientid`) REFERENCES `clients` (`client_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `animals`
--

LOCK TABLES `animals` WRITE;
/*!40000 ALTER TABLE `animals` DISABLE KEYS */;
INSERT INTO `animals` VALUES (1,'Барон',1,'М',2,60,30,5),(2,'Тайсон',2,'М',3,50,25,3),(3,'Луна',3,'Ж',1,25,5,2),(4,'Марго',4,'Ж',4,55,20,4),(5,'Феликс',5,'М',1,30,8,1),(6,'Симба',6,'М',2,45,15,7),(7,'Рокки',7,'М',5,35,10,6),(8,'Люси',8,'Ж',6,44,7,4),(9,'Багира',9,'М',12,52,9,6),(10,'Герда',10,'Ж',10,42,7,8);
/*!40000 ALTER TABLE `animals` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `animaltypes`
--

DROP TABLE IF EXISTS `animaltypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `animaltypes` (
  `animaltype_id` int NOT NULL,
  `animaltype_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`animaltype_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `animaltypes`
--

LOCK TABLES `animaltypes` WRITE;
/*!40000 ALTER TABLE `animaltypes` DISABLE KEYS */;
INSERT INTO `animaltypes` VALUES (1,'Котики'),(2,'Собаки');
/*!40000 ALTER TABLE `animaltypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clients` (
  `client_id` int NOT NULL,
  `client_name` varchar(45) NOT NULL,
  `client_login` varchar(45) NOT NULL,
  `client_password` varchar(45) NOT NULL,
  `client_phone` decimal(11,0) NOT NULL,
  `client_email` varchar(45) DEFAULT NULL,
  `client_image` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`client_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` VALUES (1,'Григорьев И.М.','Григорьев16','dsfk234ml;',79271112123,'grigorev1268@yandex.ru',''),(2,'Козлова Е.В.','Козлова997','x7vY1*8y',79271123456,'kozlova997@mail.com',''),(3,'Иванов А.Н.','Иванов574','3W^j7vd#rF27S&',79271134123,'ivanov574@mail.com',''),(4,'Петров Б.А.','Петров842','fG5g$Ru+',79271145678,'petrov842@gmail.com',''),(5,'Сергеева М.Д.','Сергеева404','2eK&m8s#',79271156789,'sergeeva404@yandex.ru',''),(6,'Новиков В.Г.','Новиков977','6hj#Q9@1wL',79271167890,'novikov977@yandex.ru',''),(7,'Данилов Е.В.','Данилов812','%3P7^Bm#',79271178901,'danilov812@mail.com',''),(8,'Жукова А.В.','Жукова455','Ys&T8G2P',79271189012,'zhukova455@yandex.ru',''),(9,'Крылова И.В.','Крылова309','B4gf@j^4#',79271325843,'krylova309@mail.ru',''),(10,'Матвеев А.Н.','Матвеев347','R5$v6Vg6R',79271320919,'matveev347@gmail.com',''),(13,'test1','test1','test1',12345678911,'test1@gmail.com',NULL),(14,'dslkjflkjdfs','dslkjflkjdfs','dslkjflkjdfs',12312,'dslkjflkjdfs@gmail.com',NULL),(15,'ghkjjkjhd','uoyujhfg','hjsfds',8776856345,'cdsfdsf@gmail.com',NULL),(16,'asdsa','adsfsf','fsdfdsf',7869078546,'dsaflkd@gmail.com',NULL),(17,'oluytuu','tyutyikuy','jkjhhkj',8678768567,'hjkhjkhj@gmail.com',NULL),(18,'123443543','5462343','2346546546',54776867345,'345435@gmail.com',NULL),(19,'test','test','test',24353454,'test@gmail.com',NULL),(20,'test','test','test',8776856345,'test',NULL),(21,'456546','Григорь54654654ев16','dsfk234ml;4564',4564564564,'cdsfdsf@gmail.com',NULL),(123,'Соловьев А. И','Solovyov1337','nepridymal',79993211231,'solovyovaleksey@gmail.com',NULL),(1234,'test','test','test',78345436543,'test@gmail.com',NULL);
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_status`
--

DROP TABLE IF EXISTS `order_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_status` (
  `orderstatus_id` int NOT NULL,
  `orderstatus_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`orderstatus_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_status`
--

LOCK TABLES `order_status` WRITE;
/*!40000 ALTER TABLE `order_status` DISABLE KEYS */;
INSERT INTO `order_status` VALUES (1,'Создана'),(2,'Ожидает оплаты'),(3,'Принята');
/*!40000 ALTER TABLE `order_status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `order_noteid` int NOT NULL,
  `order_id` int NOT NULL,
  `client_id` int DEFAULT NULL,
  `animal_id` int DEFAULT NULL,
  `room_id` int DEFAULT NULL,
  `issue_date` date DEFAULT NULL,
  `admission_date` date DEFAULT NULL,
  `worker_id` int DEFAULT NULL,
  `order_statusid` int DEFAULT NULL,
  PRIMARY KEY (`order_noteid`),
  UNIQUE KEY `order_noteid_UNIQUE` (`order_noteid`),
  KEY `client_id_idx` (`client_id`),
  KEY `worker_id_idx` (`worker_id`),
  KEY `room_id_idx` (`room_id`),
  KEY `animal_id_idx` (`animal_id`),
  KEY `orderstatus_id_idx` (`order_statusid`),
  CONSTRAINT `animal_id` FOREIGN KEY (`animal_id`) REFERENCES `animals` (`animal_id`),
  CONSTRAINT `client_id` FOREIGN KEY (`client_id`) REFERENCES `clients` (`client_id`),
  CONSTRAINT `orderstatus_id` FOREIGN KEY (`order_statusid`) REFERENCES `order_status` (`orderstatus_id`),
  CONSTRAINT `room_id` FOREIGN KEY (`room_id`) REFERENCES `rooms` (`room_id`),
  CONSTRAINT `worker_id` FOREIGN KEY (`worker_id`) REFERENCES `workers` (`worker_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (1,1,1,1,1,'2023-10-01','2023-10-12',1,1),(2,2,2,4,2,'2023-10-20','2023-10-27',2,3),(3,3,3,3,2,'2022-01-01','2022-01-12',6,2),(4,4,4,1,1,'2023-10-13','2023-10-28',6,1),(5,5,2,2,2,'2023-10-20','2023-10-27',2,2),(6,6,2,5,2,'2023-10-05','2023-10-21',2,1);
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rooms`
--

DROP TABLE IF EXISTS `rooms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rooms` (
  `room_id` int NOT NULL,
  `room_number` int DEFAULT NULL,
  `room_typeid` int DEFAULT NULL,
  `room_image` text,
  `room_description` varchar(200) DEFAULT NULL,
  `room_statusid` int DEFAULT NULL,
  PRIMARY KEY (`room_id`),
  KEY `roomtypeid_idx` (`room_typeid`),
  KEY `roomstatusid_idx` (`room_statusid`),
  CONSTRAINT `roomstatusid` FOREIGN KEY (`room_statusid`) REFERENCES `roomstatuses` (`roomstatus_id`),
  CONSTRAINT `roomtypeid` FOREIGN KEY (`room_typeid`) REFERENCES `roomtypes` (`roomtype_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rooms`
--

LOCK TABLES `rooms` WRITE;
/*!40000 ALTER TABLE `rooms` DISABLE KEYS */;
INSERT INTO `rooms` VALUES (1,11,3,NULL,'Загулшка',1),(2,12,1,NULL,'Загулшка',1),(3,13,2,NULL,'Загулшка',1),(4,21,1,NULL,'Загулшка',1),(5,22,2,NULL,'Загулшка',1),(6,23,3,NULL,'Загулшка',1),(7,31,2,NULL,'Загулшка',1),(8,32,2,NULL,'Загулшка',1),(9,33,3,NULL,'Загулшка',1),(10,41,1,NULL,'Загулшка',1);
/*!40000 ALTER TABLE `rooms` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roomstatuses`
--

DROP TABLE IF EXISTS `roomstatuses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roomstatuses` (
  `roomstatus_id` int NOT NULL,
  `roomstatus_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`roomstatus_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roomstatuses`
--

LOCK TABLES `roomstatuses` WRITE;
/*!40000 ALTER TABLE `roomstatuses` DISABLE KEYS */;
INSERT INTO `roomstatuses` VALUES (1,'Свободна'),(2,'Забронирована'),(3,'Занята');
/*!40000 ALTER TABLE `roomstatuses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roomtypes`
--

DROP TABLE IF EXISTS `roomtypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roomtypes` (
  `roomtype_id` int NOT NULL,
  `roomtype_name` varchar(45) DEFAULT NULL,
  `roomtype_description` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`roomtype_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roomtypes`
--

LOCK TABLES `roomtypes` WRITE;
/*!40000 ALTER TABLE `roomtypes` DISABLE KEYS */;
INSERT INTO `roomtypes` VALUES (1,'Номер для одного питомца','Номер для одного питомца среднего размера'),(2,'Номер для двух питомцев','Номер для двух питомца среднего размера'),(3,'Номер для трёх питомцев','Номер для трех питомцев среднего размера, или одного крупного'),(4,'Номер для птиц','Номер для любимого летающего друга'),(5,'Номер для грызунов','Номер для маленьких и милых домашних питомцев');
/*!40000 ALTER TABLE `roomtypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `servicecategories`
--

DROP TABLE IF EXISTS `servicecategories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `servicecategories` (
  `servicecategory_id` int NOT NULL,
  `servicecategory_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`servicecategory_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `servicecategories`
--

LOCK TABLES `servicecategories` WRITE;
/*!40000 ALTER TABLE `servicecategories` DISABLE KEYS */;
INSERT INTO `servicecategories` VALUES (1,'Проживание'),(2,'Вет услуги'),(3,'Фотоотчет');
/*!40000 ALTER TABLE `servicecategories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `services`
--

DROP TABLE IF EXISTS `services`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `services` (
  `service_id` int NOT NULL,
  `service_categid` int DEFAULT NULL,
  `service_name` varchar(45) DEFAULT NULL,
  `service_description` varchar(200) DEFAULT NULL,
  `service_price` double DEFAULT NULL,
  PRIMARY KEY (`service_id`),
  KEY `categid_idx` (`service_categid`),
  CONSTRAINT `categid` FOREIGN KEY (`service_categid`) REFERENCES `servicecategories` (`servicecategory_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `services`
--

LOCK TABLES `services` WRITE;
/*!40000 ALTER TABLE `services` DISABLE KEYS */;
INSERT INTO `services` VALUES (1,1,'Проживание','Проживание в номере гостиницы без оказания доп услуг',200),(2,1,'Проживание+','Проживание в номере гостиницы с выгуливанием питомца',350),(3,2,'Лечение и уход','За вашим питомцем будет наблюдать один из сотрудников, следить за его поведением, измерять температуру, давать необходимые лекарства',150),(4,3,'Фотосессия','Сделаем и отправим Вам фотографиивидео с вашим любимым питомцем',500);
/*!40000 ALTER TABLE `services` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `workerposts`
--

DROP TABLE IF EXISTS `workerposts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `workerposts` (
  `workerpost_id` int NOT NULL,
  `workerpost_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`workerpost_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workerposts`
--

LOCK TABLES `workerposts` WRITE;
/*!40000 ALTER TABLE `workerposts` DISABLE KEYS */;
INSERT INTO `workerposts` VALUES (1,'Работник'),(2,'Администратор');
/*!40000 ALTER TABLE `workerposts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `workers`
--

DROP TABLE IF EXISTS `workers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `workers` (
  `worker_id` int NOT NULL,
  `worker_name` varchar(45) DEFAULT NULL,
  `worker_postid` int DEFAULT NULL,
  `worker_login` varchar(45) DEFAULT NULL,
  `worker_password` varchar(45) DEFAULT NULL,
  `worker_phone` decimal(11,0) DEFAULT NULL,
  `worker_email` varchar(45) DEFAULT NULL,
  `worker_image` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`worker_id`),
  KEY `postid_idx` (`worker_postid`),
  CONSTRAINT `postid` FOREIGN KEY (`worker_postid`) REFERENCES `workerposts` (`workerpost_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workers`
--

LOCK TABLES `workers` WRITE;
/*!40000 ALTER TABLE `workers` DISABLE KEYS */;
INSERT INTO `workers` VALUES (1,'Волков К.С.',1,'volkov121','123789',79854563245,'volkov326@mail.ru',''),(2,'Козлова И.Ю.',2,'kozlova785','654321',79667235049,'kozlova785@mail.ru',''),(3,'Васильева Г.С.',1,'vasileva126','pass2022',79667235437,'vasileva529@yandex.ru',''),(4,'Кузьмина О.В.',1,'kuzmina951','qwertypass',79098643872,'kuzmina951@gmail.com',''),(5,'Николаева А.Д.',1,'nikolaeva758','pass1234',79512489674,'nikolaeva758@mail.ru',''),(6,'Зайцева Н.А.',2,'zaytseva872','zxcvb123',79251873296,'zaytseva872@yandex.com',''),(7,'Мельникова М.С.',1,'melnikova451','1234qwerasdf',79769748372,'melnikova451@gmail.com',''),(8,'Соловьева О.В.',1,'solovieva259','1q2w3e4r',79096548271,'solovieva259@yandex.ru',''),(9,'Калинина Е.А.',1,'kalinina896','asdfgh',79464738159,'kalinina896@yandex.ru',''),(10,'Григорьева Т.П.',2,'grigoreva548','1a2b3c4d',79013467592,'grigoreva548@gmail.com','');
/*!40000 ALTER TABLE `workers` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-10-23 16:29:47
