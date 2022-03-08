/*
SQLyog Community Edition- MySQL GUI v8.12 
MySQL - 5.7.36 : Database - louisbvbdminicha
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

CREATE DATABASE /*!32312 IF NOT EXISTS*/`louisbvbdminicha` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `louisbvbdminicha`;

/*Table structure for table `t_salarie` */

DROP TABLE IF EXISTS `t_salarie`;

CREATE TABLE `t_salarie` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` char(255) NOT NULL,
  `prenom` char(255) NOT NULL,
  `tel_fix` int(10) DEFAULT NULL,
  `tel_portable` int(11) NOT NULL,
  `email` char(255) NOT NULL,
  `service_id` int(255) NOT NULL,
  `site_id` int(255) NOT NULL,
  `password` char(255) NOT NULL,
  `role` enum('VISITEUR','ADMINISTRATEUR') NOT NULL,
  `connection_admin` int(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=107 DEFAULT CHARSET=utf8;

/*Data for the table `t_salarie` */

insert  into `t_salarie`(`id`,`nom`,`prenom`,`tel_fix`,`tel_portable`,`email`,`service_id`,`site_id`,`password`,`role`,`connection_admin`) values (1,'Sylla','David',235598222,624685730,'David.Sylla@gmail.com',1,1,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(2,'Gicquel','Valentin',235598223,624685731,'Valentin.Gicquel@gmail.com',2,2,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(3,'Gontier','Margaux',235598224,624685732,'Margaux.Gontier@gmail.com',3,3,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(4,'Thery','Romain',235598225,624685733,'Romain.Thery@gmail.com',4,4,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(5,'Arnal','Julie',235598226,624685734,'Julie.Arnal@gmail.com',5,5,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(6,'Ragot','Eden',235598227,624685735,'Eden.Ragot@gmail.com',6,6,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(7,'Leonard','Valentine',235598228,624685736,'Valentine.Leonard@gmail.com',1,7,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(8,'Mohammad','Oscar',235598229,624685737,'Oscar.Mohammad@gmail.com',2,8,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(9,'Lefort','Alexandre',235598230,624685738,'Alexandre.Lefort@gmail.com',3,9,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(10,'Baudry','Léo',235598231,624685739,'Léo.Baudry@gmail.com',4,1,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(11,'Perraud','Dylan',235598232,624685740,'Dylan.Perraud@gmail.com',5,2,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(12,'Soulard','Maëlys',235598233,624685741,'Maëlys.Soulard@gmail.com',6,3,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(13,'Pierson','David',235598234,624685742,'David.Pierson@gmail.com',1,4,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(14,'Vernay','Léna',235598235,624685743,'Léna.Vernay@gmail.com',2,5,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(15,'Bouchard','Kylian',235598236,624685744,'Kylian.Bouchard@gmail.com',3,6,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(16,'Derrien','Robin',235598237,624685745,'Robin.Derrien@gmail.com',4,7,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(17,'Guillon','Julie',235598238,624685746,'Julie.Guillon@gmail.com',5,8,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(19,'Bidault','Samuel',235598240,624685748,'Samuel.Bidault@gmail.com',1,1,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(20,'Rigal','Charles',235598241,624685749,'Charles.Rigal@gmail.com',2,2,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(21,'Dumortier','Lou',235598242,624685750,'Lou.Dumortier@gmail.com',3,3,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(22,'Christophe','Agathe',235598243,624685751,'Agathe.Christophe@gmail.com',4,4,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(23,'Monteiro','Anaïs',235598244,624685752,'Anaïs.Monteiro@gmail.com',5,5,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(24,'Langlois','Thaïs',235598245,624685753,'Thaïs.Langlois@gmail.com',6,6,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(25,'Six','Lucas',235598246,624685754,'Lucas.Six@gmail.com',1,7,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(26,'Moisan','Eloïse',235598247,624685755,'Eloïse.Moisan@gmail.com',2,8,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(27,'Marie','Victoire',235598248,624685756,'Victoire.Marie@gmail.com',3,9,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(28,'Duquesne','Nina',235598249,624685757,'Nina.Duquesne@gmail.com',4,1,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(29,'Grasset','Gabin',235598250,624685758,'Gabin.Grasset@gmail.com',5,2,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(30,'Brisset','Ayoub',235598251,624685759,'Ayoub.Brisset@gmail.com',6,3,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(31,'Taieb','Elsa',235598252,624685760,'Elsa.Taieb@gmail.com',1,4,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(32,'Fouquet','Maëlle',235598253,624685761,'Maëlle.Fouquet@gmail.com',2,5,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(33,'Fischer','Ali',235598254,624685762,'Ali.Fischer@gmail.com',3,6,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(34,'Hoareau','Kenzo',235598255,624685763,'Kenzo.Hoareau@gmail.com',4,7,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(35,'Marchal','Alexis',235598256,624685764,'Alexis.Marchal@gmail.com',5,8,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(36,'Oliveira','Lucie',235598257,624685765,'Lucie.Oliveira@gmail.com',6,9,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(37,'Jung','Emy',235598258,624685766,'Emy.Jung@gmail.com',1,1,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(38,'Nativel','Imran',235598259,624685767,'Imran.Nativel@gmail.com',2,2,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(39,'Demay','Marceau',235598260,624685768,'Marceau.Demay@gmail.com',3,3,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(40,'Charron','Capucine',235598261,624685769,'Capucine.Charron@gmail.com',4,4,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(41,'Castro','Ruben',235598262,624685770,'Ruben.Castro@gmail.com',5,5,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(42,'Maire','Thaïs',235598263,624685771,'Thaïs.Maire@gmail.com',6,6,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(43,'Rolland','Agathe',235598264,624685772,'Agathe.Rolland@gmail.com',1,7,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(44,'Leloup','Milo',235598265,624685773,'Milo.Leloup@gmail.com',2,8,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(45,'Mounier','Amir',235598266,624685774,'Amir.Mounier@gmail.com',3,9,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(46,'Monnier','Kenzo',235598267,624685775,'Kenzo.Monnier@gmail.com',4,1,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(47,'Michaud','Théo',235598268,624685776,'Théo.Michaud@gmail.com',5,2,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(48,'Prat','Charlie',235598269,624685777,'Charlie.Prat@gmail.com',6,3,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(49,'Navarro','Eden',235598270,624685778,'Eden.Navarro@gmail.com',1,4,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(50,'Bizet','Owen',235598271,624685779,'Owen.Bizet@gmail.com',2,5,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(51,'Imbert','Titouan',235598272,624685780,'Titouan.Imbert@gmail.com',3,6,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(52,'Grenier','Lya',235598273,624685781,'Lya.Grenier@gmail.com',4,7,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(53,'Bouchet','Titouan',235598274,624685782,'Titouan.Bouchet@gmail.com',5,8,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(54,'Cuvelier','Enzo',235598275,624685783,'Enzo.Cuvelier@gmail.com',6,9,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(55,'Dupre','Gabrielle',235598276,624685784,'Gabrielle.Dupre@gmail.com',1,1,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(56,'Cottin','Valentine',235598277,624685785,'Valentine.Cottin@gmail.com',2,2,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(57,'Godard','Owen',235598278,624685786,'Owen.Godard@gmail.com',3,3,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(58,'Tissot','Julie',235598279,624685787,'Julie.Tissot@gmail.com',4,4,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(59,'Charlot','Lorenzo',235598280,624685788,'Lorenzo.Charlot@gmail.com',5,5,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(60,'Vigier','Elena',235598281,624685789,'Elena.Vigier@gmail.com',6,6,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(61,'Sarrazin','Ayoub',235598282,624685790,'Ayoub.Sarrazin@gmail.com',1,7,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(62,'Chapelle','Louis',235598283,624685791,'Louis.Chapelle@gmail.com',2,8,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(63,'Lelong','Thaïs',235598284,624685792,'Thaïs.Lelong@gmail.com',3,9,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(64,'Vautier','William',235598285,624685793,'William.Vautier@gmail.com',4,1,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(65,'Hamdi','Charly',235598286,624685794,'Charly.Hamdi@gmail.com',5,2,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(66,'Delcourt','Léo',235598287,624685795,'Léo.Delcourt@gmail.com',6,3,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(67,'Slimani','Raphael',235598288,624685796,'Rafael.Slimani@gmail.com',1,9,'c2480f37b829a0f25092d4e0bbd35187','VISITEUR',0),(68,'Roussel','Lou',235598289,624685797,'Lou.Roussel@gmail.com',2,5,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(69,'Lopez','Mathis',235598290,624685798,'Mathis.Lopez@gmail.com',3,6,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(70,'Mignon','Elisa',235598291,624685799,'Elisa.Mignon@gmail.com',4,7,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(71,'Merle','Mathys',235598292,624685800,'Mathys.Merle@gmail.com',5,8,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(72,'Costa','Mila',235598293,624685801,'Mila.Costa@gmail.com',6,9,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(73,'Prigent','Léane',235598294,624685802,'Léane.Prigent@gmail.com',1,1,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(74,'Demange','Louka',235598295,624685803,'Louka.Demange@gmail.com',2,2,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(75,'Calvez','Margot',235598296,624685804,'Margot.Calvez@gmail.com',3,3,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(76,'Lallement','Paul',235598297,624685805,'Paul.Lallement@gmail.com',4,4,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(77,'Pelletier','Loan',235598298,624685806,'Loan.Pelletier@gmail.com',5,5,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(78,'Noel','Charles',235598299,624685807,'Charles.Noel@gmail.com',6,6,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(79,'Hebert','Marceau',235598300,624685808,'Marceau.Hebert@gmail.com',1,7,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(80,'Neveu','Anaïs',235598301,624685809,'Anaïs.Neveu@gmail.com',2,8,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(81,'Ahmed','Ibrahim',235598302,624685810,'Ibrahim.Ahmed@gmail.com',3,9,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(82,'Prat','Anna',235598303,624685811,'Anna.Prat@gmail.com',4,1,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(83,'Guillaume','Benjamin',235598304,624685812,'Benjamin.Guillaume@gmail.com',5,2,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(84,'Dupouy','Antonin',235598305,624685813,'Antonin.Dupouy@gmail.com',6,3,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(85,'Imbert','Victoria',235598306,624685814,'Victoria.Imbert@gmail.com',1,4,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(86,'Dahan','Axel',235598307,624685815,'Axel.Dahan@gmail.com',2,5,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(87,'Le Moal','Noam',235598308,624685816,'Noam.Le Moal@gmail.com',3,6,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(88,'Camus','Maxime',235598309,624685817,'Maxime.Camus@gmail.com',4,7,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(89,'Jacques','Théo',235598310,624685818,'Théo.Jacques@gmail.com',5,8,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(90,'Leborgne','Lily',235598311,624685819,'Lily.Leborgne@gmail.com',6,9,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(91,'Afonso','Mael',235598312,624685820,'Mael.Afonso@gmail.com',1,1,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(92,'Huet','Rayan',235598313,624685821,'Rayan.Huet@gmail.com',2,2,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(93,'Herault','Younes',235598314,624685822,'Younes.Herault@gmail.com',3,3,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(94,'Thevenet','Mia',235598315,624685823,'Mia.Thevenet@gmail.com',4,4,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(95,'Toussaint','Gabrielle',235598316,624685824,'Gabrielle.Toussaint@gmail.com',5,5,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(96,'Montagne','Lyam',235598317,624685825,'Lyam.Montagne@gmail.com',6,6,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(97,'Delacroix','Isaac',235598318,624685826,'Isaac.Delacroix@gmail.com',1,7,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(98,'Gueye','Iris',235598319,624685827,'Iris.Gueye@gmail.com',2,8,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(99,'Basset','Noham',235598320,624685828,'Noham.Basset@gmail.com',3,9,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(100,'Fofana','Iris',235598321,624685829,'Iris.Fofana@gmail.com',4,1,'280a50e191d7e8304adf7b40ef50530f','VISITEUR',0),(101,'Berthelot','Louis',235598221,624685729,'louis.berthelot@viacesi.fr',3,1,'807164460de09fc5f8ebdd925651e978','VISITEUR',NULL),(106,'Bertrand','bertrand',123456789,624685729,'Bert@bert.fr',1,1,'c2480f37b829a0f25092d4e0bbd35187','VISITEUR',NULL);

/*Table structure for table `t_service` */

DROP TABLE IF EXISTS `t_service`;

CREATE TABLE `t_service` (
  `id_service` int(11) NOT NULL AUTO_INCREMENT,
  `libelle_service` char(255) DEFAULT NULL,
  PRIMARY KEY (`id_service`)
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

/*Data for the table `t_service` */

insert  into `t_service`(`id_service`,`libelle_service`) values (1,'Production'),(2,'Accueil'),(3,'Informatique'),(4,'Direction'),(5,'Comptabilité'),(6,'Commercial');

/*Table structure for table `t_site` */

DROP TABLE IF EXISTS `t_site`;

CREATE TABLE `t_site` (
  `id_site` int(11) NOT NULL AUTO_INCREMENT,
  `ville` char(255) NOT NULL,
  `pays` char(255) NOT NULL,
  PRIMARY KEY (`id_site`)
) ENGINE=MyISAM AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;

/*Data for the table `t_site` */

insert  into `t_site`(`id_site`,`ville`,`pays`) values (1,'Rouen','France'),(2,'Paris','France'),(3,'Londres','Grande-Bretagne'),(4,'Berlin','Allemagne'),(5,'Nantes','France'),(6,'Toulouse','France'),(7,'Nice','France'),(8,'Lille','France'),(9,'Supprimé (anciennement: Rome)','Supprimé (anciennement: Italie)');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;