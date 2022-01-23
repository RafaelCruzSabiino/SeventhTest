CREATE DATABASE  IF NOT EXISTS `seventh_dguard`;

USE `seventh_dguard`;

DROP TABLE IF EXISTS `sdg_0001`;

CREATE TABLE `sdg_0001` (
  `ID` varchar(45) NOT NULL,
  `NAME` varchar(150) NOT NULL,
  `IP` varchar(45) NOT NULL,
  `PORT` int(11) NOT NULL,
  `DATE_ALTER` datetime NOT NULL,
  `DATE_INSERT` datetime NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='TABELA DE SERVIDOR'
