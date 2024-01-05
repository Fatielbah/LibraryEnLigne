-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : ven. 05 jan. 2024 à 22:19
-- Version du serveur : 8.0.31
-- Version de PHP : 8.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `library`
--

-- --------------------------------------------------------

--
-- Structure de la table `auteur`
--

DROP TABLE IF EXISTS `auteur`;
CREATE TABLE IF NOT EXISTS `auteur` (
  `AuteurID` int NOT NULL AUTO_INCREMENT,
  `AuteurName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Resume` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`AuteurID`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `auteur`
--

INSERT INTO `auteur` (`AuteurID`, `AuteurName`, `Resume`) VALUES
(6, 'Oliver Sacks', '(1933-2015) était un neurologue britannique et écrivain qui a exploré les aspects fascinants et souvent mystérieux du cerveau humain'),
(2, 'Cesare Beccaria', 'Il était un juriste et un philosophe italien du XVIIIe siècle. Son œuvre la plus célèbre est \"Des délits et des peines\", dans laquelle il a développé des idées sur la justice pénale et l\'utilité de la peine. Il a également écrit sur le droit de punir'),
(3, 'Gérard Cornu', 'Il était un professeur de droit à l\'université de Paris Panthéon-Assas et doyen de la Faculté de droit de Poitiers. Il est connu pour son \"Vocabulaire juridique\", une référence incontournable dans le domaine juridique'),
(4, 'Honoré de Balzac', 'Bien qu\'il ne soit pas un auteur de droit, certaines de ses œuvres, comme \"Le Colonel Chabert\" et \"Petites misères de la vie conjugale\", abordent des thèmes juridiques et sont étudiées dans le cadre du droit et de la littérature'),
(5, 'Stephen Hawking', '(1942-2018) était un physicien théoricien britannique renommé, célèbre pour ses contributions à la cosmologie et à la physique théorique.');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
