-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Vært: localhost
-- Genereringstid: 29. 11 2019 kl. 07:52:01
-- Serverversion: 8.0.16
-- PHP-version: 7.3.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `Business`
--

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `department`
--

CREATE TABLE `department` (
  `department_id` int(11) NOT NULL,
  `dep_manager_id` int(11) NOT NULL,
  `department_name` varchar(200) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Data dump for tabellen `department`
--

INSERT INTO `department` (`department_id`, `dep_manager_id`, `department_name`) VALUES
(1, 1, 'Viborg');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `dep_employee`
--

CREATE TABLE `dep_employee` (
  `dep_employee_id` int(11) NOT NULL,
  `department_id` int(11) NOT NULL,
  `employee_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Data dump for tabellen `dep_employee`
--

INSERT INTO `dep_employee` (`dep_employee_id`, `department_id`, `employee_id`) VALUES
(1, 1, 1),
(2, 1, 2);

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `dep_manager`
--

CREATE TABLE `dep_manager` (
  `dep_manager_id` int(11) NOT NULL,
  `employee_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Data dump for tabellen `dep_manager`
--

INSERT INTO `dep_manager` (`dep_manager_id`, `employee_id`) VALUES
(1, 3);

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `employee`
--

CREATE TABLE `employee` (
  `employee_id` int(11) NOT NULL,
  `title_id` int(11) NOT NULL,
  `employee_name` varchar(200) COLLATE utf8mb4_general_ci NOT NULL,
  `employee_email` varchar(200) COLLATE utf8mb4_general_ci NOT NULL,
  `employee_username` varchar(200) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Data dump for tabellen `employee`
--

INSERT INTO `employee` (`employee_id`, `title_id`, `employee_name`, `employee_email`, `employee_username`) VALUES
(1, 1, 'Philip L. Christoffersen', 'PhilipLChristoffersen@rhyta.com', 'Waget1949'),
(2, 1, 'Philip S. Hermansen', 'PhilipSHermansen@teleworm.us', 'Leguiry42'),
(3, 2, 'Joachim C. Hansen', 'JoachimCHansen@teleworm.us', 'Priblefulth'),
(4, 3, 'Selam M. Carlsen', 'SelamMCarlsen@jourrapide.com', 'Comens');

-- --------------------------------------------------------

--
-- Stand-in-struktur for visning `employees`
-- (Se nedenfor for det aktuelle view)
--
CREATE TABLE `employees` (
`employee_name` varchar(200)
,`employee_email` varchar(200)
,`employee_username` varchar(200)
,`title_name` varchar(200)
,`amount` int(11)
,`department_name` varchar(200)
,`dep_manager` varchar(200)
);

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `salary`
--

CREATE TABLE `salary` (
  `salary_id` int(11) NOT NULL,
  `amount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Data dump for tabellen `salary`
--

INSERT INTO `salary` (`salary_id`, `amount`) VALUES
(1, 10000),
(2, 50000),
(3, 25000);

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `title`
--

CREATE TABLE `title` (
  `title_id` int(11) NOT NULL,
  `salary_id` int(11) NOT NULL,
  `title_name` varchar(200) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Data dump for tabellen `title`
--

INSERT INTO `title` (`title_id`, `salary_id`, `title_name`) VALUES
(1, 1, 'Student'),
(2, 2, 'Owner'),
(3, 3, 'Manager');

-- --------------------------------------------------------

--
-- Struktur for visning `employees`
--
DROP TABLE IF EXISTS `employees`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `employees`  AS  select `employee`.`employee_name` AS `employee_name`,`employee`.`employee_email` AS `employee_email`,`employee`.`employee_username` AS `employee_username`,`title`.`title_name` AS `title_name`,`salary`.`amount` AS `amount`,`department`.`department_name` AS `department_name`,(select `employee`.`employee_name` from `employee` where (`dep_manager`.`employee_id` = `employee`.`employee_id`)) AS `dep_manager` from (((((`department` join `dep_employee` on((`dep_employee`.`department_id` = `department`.`department_id`))) join `employee` on((`employee`.`employee_id` = `dep_employee`.`dep_employee_id`))) join `title` on((`title`.`title_id` = `employee`.`title_id`))) join `salary` on((`salary`.`salary_id` = `title`.`title_id`))) join `dep_manager` on((`dep_manager`.`dep_manager_id` = `department`.`department_id`))) ;

--
-- Begrænsninger for dumpede tabeller
--

--
-- Indeks for tabel `department`
--
ALTER TABLE `department`
  ADD PRIMARY KEY (`department_id`),
  ADD KEY `dep_manager_id` (`dep_manager_id`);

--
-- Indeks for tabel `dep_employee`
--
ALTER TABLE `dep_employee`
  ADD PRIMARY KEY (`dep_employee_id`),
  ADD KEY `department_id` (`department_id`),
  ADD KEY `employee_id` (`employee_id`);

--
-- Indeks for tabel `dep_manager`
--
ALTER TABLE `dep_manager`
  ADD PRIMARY KEY (`dep_manager_id`),
  ADD KEY `employee_id` (`employee_id`);

--
-- Indeks for tabel `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`employee_id`),
  ADD KEY `tid` (`title_id`);

--
-- Indeks for tabel `salary`
--
ALTER TABLE `salary`
  ADD PRIMARY KEY (`salary_id`);

--
-- Indeks for tabel `title`
--
ALTER TABLE `title`
  ADD PRIMARY KEY (`title_id`),
  ADD KEY `sid` (`salary_id`);

--
-- Brug ikke AUTO_INCREMENT for slettede tabeller
--

--
-- Tilføj AUTO_INCREMENT i tabel `department`
--
ALTER TABLE `department`
  MODIFY `department_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tilføj AUTO_INCREMENT i tabel `dep_employee`
--
ALTER TABLE `dep_employee`
  MODIFY `dep_employee_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tilføj AUTO_INCREMENT i tabel `dep_manager`
--
ALTER TABLE `dep_manager`
  MODIFY `dep_manager_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tilføj AUTO_INCREMENT i tabel `employee`
--
ALTER TABLE `employee`
  MODIFY `employee_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Tilføj AUTO_INCREMENT i tabel `salary`
--
ALTER TABLE `salary`
  MODIFY `salary_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Tilføj AUTO_INCREMENT i tabel `title`
--
ALTER TABLE `title`
  MODIFY `title_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Begrænsninger for dumpede tabeller
--

--
-- Begrænsninger for tabel `department`
--
ALTER TABLE `department`
  ADD CONSTRAINT `department_ibfk_1` FOREIGN KEY (`dep_manager_id`) REFERENCES `dep_manager` (`dep_manager_id`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Begrænsninger for tabel `dep_employee`
--
ALTER TABLE `dep_employee`
  ADD CONSTRAINT `dep_employee_ibfk_1` FOREIGN KEY (`department_id`) REFERENCES `department` (`department_id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  ADD CONSTRAINT `dep_employee_ibfk_2` FOREIGN KEY (`employee_id`) REFERENCES `employee` (`employee_id`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Begrænsninger for tabel `dep_manager`
--
ALTER TABLE `dep_manager`
  ADD CONSTRAINT `dep_manager_ibfk_1` FOREIGN KEY (`employee_id`) REFERENCES `employee` (`employee_id`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Begrænsninger for tabel `employee`
--
ALTER TABLE `employee`
  ADD CONSTRAINT `employee_ibfk_1` FOREIGN KEY (`title_id`) REFERENCES `title` (`title_id`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Begrænsninger for tabel `title`
--
ALTER TABLE `title`
  ADD CONSTRAINT `title_ibfk_1` FOREIGN KEY (`salary_id`) REFERENCES `salary` (`salary_id`) ON DELETE RESTRICT ON UPDATE RESTRICT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
