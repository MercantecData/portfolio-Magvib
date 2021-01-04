-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Vært: localhost
-- Genereringstid: 27. 11 2019 kl. 09:10:41
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
-- Database: `Mercantec`
--

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `address`
--

CREATE TABLE `address` (
  `aid` int(11) NOT NULL,
  `adress` varchar(200) COLLATE utf8mb4_general_ci NOT NULL,
  `zip` int(11) NOT NULL,
  `city` varchar(200) COLLATE utf8mb4_general_ci NOT NULL,
  `country` varchar(200) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Data dump for tabellen `address`
--

INSERT INTO `address` (`aid`, `adress`, `zip`, `city`, `country`) VALUES
(1, 'Plejlen 26', 8800, 'Viborg', 'Danmark'),
(2, 'Viborgvej 155', 8800, 'Viborg', 'Danmark'),
(3, 'Hersnapvej 42', 1093, 'København K', 'Danmark'),
(4, 'Hjortholmvænget 33', 8380, 'Trige', 'Danmark'),
(5, 'Gasværksvej 12', 4550, 'Asnæs', 'Danmark'),
(6, 'Stenløsegyden 20', 1025, 'København K', 'Danmark'),
(7, 'Christianslundsvej 82', 3250, 'Gilleleje', 'Danmark'),
(8, 'Nørrebrovænget 50', 1107, 'København K', 'Danmark'),
(9, 'Slotsgade 25', 4895, 'Errindlev', 'Danmark'),
(10, 'Møllevænget 55', 6580, 'Vamdrup', 'Danmark');

-- --------------------------------------------------------

--
-- Stand-in-struktur for visning `doot19878095`
-- (Se nedenfor for det aktuelle view)
--
CREATE TABLE `doot19878095` (
`username` varchar(200)
,`full_name` varchar(200)
,`email` varchar(255)
,`pname` varchar(200)
,`adress` varchar(200)
,`zip` int(11)
,`city` varchar(200)
,`country` varchar(200)
);

-- --------------------------------------------------------

--
-- Stand-in-struktur for visning `hoggins`
-- (Se nedenfor for det aktuelle view)
--
CREATE TABLE `hoggins` (
`username` varchar(200)
,`full_name` varchar(200)
,`email` varchar(255)
,`pname` varchar(200)
,`adress` varchar(200)
,`zip` int(11)
,`city` varchar(200)
,`country` varchar(200)
);

-- --------------------------------------------------------

--
-- Stand-in-struktur for visning `humband8117`
-- (Se nedenfor for det aktuelle view)
--
CREATE TABLE `humband8117` (
`username` varchar(200)
,`full_name` varchar(200)
,`email` varchar(255)
,`pname` varchar(200)
,`adress` varchar(200)
,`zip` int(11)
,`city` varchar(200)
,`country` varchar(200)
);

-- --------------------------------------------------------

--
-- Stand-in-struktur for visning `magvib`
-- (Se nedenfor for det aktuelle view)
--
CREATE TABLE `magvib` (
`username` varchar(200)
,`full_name` varchar(200)
,`email` varchar(255)
,`pname` varchar(200)
,`adress` varchar(200)
,`zip` int(11)
,`city` varchar(200)
,`country` varchar(200)
);

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `orders`
--

CREATE TABLE `orders` (
  `oid` int(11) NOT NULL,
  `pid` int(11) NOT NULL,
  `uid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Data dump for tabellen `orders`
--

INSERT INTO `orders` (`oid`, `pid`, `uid`) VALUES
(18, 1, 11),
(19, 3, 11),
(20, 2, 12),
(21, 1, 12),
(22, 8, 13),
(23, 1, 19),
(24, 6, 18),
(25, 9, 17),
(26, 3, 14),
(27, 2, 16),
(28, 7, 20),
(29, 4, 15),
(30, 10, 13),
(31, 5, 19),
(32, 8, 13),
(33, 9, 19),
(34, 7, 18),
(35, 5, 17),
(36, 6, 14),
(37, 1, 16),
(38, 9, 20),
(39, 6, 15),
(40, 5, 11);

-- --------------------------------------------------------

--
-- Stand-in-struktur for visning `ovent19796654`
-- (Se nedenfor for det aktuelle view)
--
CREATE TABLE `ovent19796654` (
`username` varchar(200)
,`full_name` varchar(200)
,`email` varchar(255)
,`pname` varchar(200)
,`adress` varchar(200)
,`zip` int(11)
,`city` varchar(200)
,`country` varchar(200)
);

-- --------------------------------------------------------

--
-- Stand-in-struktur for visning `plinted5841`
-- (Se nedenfor for det aktuelle view)
--
CREATE TABLE `plinted5841` (
`username` varchar(200)
,`full_name` varchar(200)
,`email` varchar(255)
,`pname` varchar(200)
,`adress` varchar(200)
,`zip` int(11)
,`city` varchar(200)
,`country` varchar(200)
);

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `products`
--

CREATE TABLE `products` (
  `pid` int(11) NOT NULL,
  `pname` varchar(200) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Data dump for tabellen `products`
--

INSERT INTO `products` (`pid`, `pname`) VALUES
(1, 'Coca Cola'),
(2, 'Macbook Pro'),
(3, 'Macbook Air'),
(4, 'Taske'),
(5, 'Telefon'),
(6, 'Computer'),
(7, 'Monster'),
(8, 'Airpods'),
(9, 'Hoodie'),
(10, 'Tastatur');

-- --------------------------------------------------------

--
-- Stand-in-struktur for visning `sesider5617`
-- (Se nedenfor for det aktuelle view)
--
CREATE TABLE `sesider5617` (
`username` varchar(200)
,`full_name` varchar(200)
,`email` varchar(255)
,`pname` varchar(200)
,`adress` varchar(200)
,`zip` int(11)
,`city` varchar(200)
,`country` varchar(200)
);

-- --------------------------------------------------------

--
-- Stand-in-struktur for visning `suittled9259`
-- (Se nedenfor for det aktuelle view)
--
CREATE TABLE `suittled9259` (
`username` varchar(200)
,`full_name` varchar(200)
,`email` varchar(255)
,`pname` varchar(200)
,`adress` varchar(200)
,`zip` int(11)
,`city` varchar(200)
,`country` varchar(200)
);

-- --------------------------------------------------------

--
-- Stand-in-struktur for visning `tindst1371`
-- (Se nedenfor for det aktuelle view)
--
CREATE TABLE `tindst1371` (
`username` varchar(200)
,`full_name` varchar(200)
,`email` varchar(255)
,`pname` varchar(200)
,`adress` varchar(200)
,`zip` int(11)
,`city` varchar(200)
,`country` varchar(200)
);

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `users`
--

CREATE TABLE `users` (
  `uid` int(11) NOT NULL,
  `username` varchar(200) COLLATE utf8mb4_general_ci NOT NULL,
  `full_name` varchar(200) COLLATE utf8mb4_general_ci NOT NULL,
  `email` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `aid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Data dump for tabellen `users`
--

INSERT INTO `users` (`uid`, `username`, `full_name`, `email`, `aid`) VALUES
(11, 'Magvib', 'Magnus Bjørn Nielsen', 'Magnus@p13.dk', 1),
(12, 'Nikolaj', 'Nikolaj Nielsen', 'Niko@gmail.com', 2),
(13, 'Doot19878095', 'Jonathan J Lind', 'dwlznryvq5@classesmail.com', 7),
(14, 'Sesider5617', 'Anne-Lise O Jespersen', 'uydfaymwutm@groupbuff.com', 5),
(15, 'Whespers1681', 'Isabella J Bach', 'evbwf0ubtld@powerencry.com', 3),
(16, 'Suittled9259', 'Magnus N Poulsen', '7nwq1qqfpgl@classesmail.com', 4),
(17, 'Plinted5841', 'Malou C Laursen', 'b1pee7ngvgs@powerencry.com', 10),
(18, 'Ovent19796654', 'Johanne M Andresen', 'b80jyv8ix7j@meantinc.com', 8),
(19, 'Humband8117', 'Alma A Olsen', 'i8k7gcky1mr@groupbuff.com', 9),
(20, 'Tindst1371', 'Benjamin R Mortensen', 'omunqh612wi@powerencry.com', 6);

-- --------------------------------------------------------

--
-- Stand-in-struktur for visning `whespers1681`
-- (Se nedenfor for det aktuelle view)
--
CREATE TABLE `whespers1681` (
`username` varchar(200)
,`full_name` varchar(200)
,`email` varchar(255)
,`pname` varchar(200)
,`adress` varchar(200)
,`zip` int(11)
,`city` varchar(200)
,`country` varchar(200)
);

-- --------------------------------------------------------

--
-- Struktur for visning `doot19878095`
--
DROP TABLE IF EXISTS `doot19878095`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `doot19878095`  AS  select `u`.`username` AS `username`,`u`.`full_name` AS `full_name`,`u`.`email` AS `email`,`p`.`pname` AS `pname`,`a`.`adress` AS `adress`,`a`.`zip` AS `zip`,`a`.`city` AS `city`,`a`.`country` AS `country` from (((`orders` join `users` `u` on((`u`.`uid` = `orders`.`uid`))) join `products` `p` on((`p`.`pid` = `orders`.`pid`))) join `address` `a` on((`u`.`aid` = `a`.`aid`))) where (`orders`.`uid` = 13) ;

-- --------------------------------------------------------

--
-- Struktur for visning `hoggins`
--
DROP TABLE IF EXISTS `hoggins`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `hoggins`  AS  select `u`.`username` AS `username`,`u`.`full_name` AS `full_name`,`u`.`email` AS `email`,`p`.`pname` AS `pname`,`a`.`adress` AS `adress`,`a`.`zip` AS `zip`,`a`.`city` AS `city`,`a`.`country` AS `country` from (((`orders` join `users` `u` on((`u`.`uid` = `orders`.`uid`))) join `products` `p` on((`p`.`pid` = `orders`.`pid`))) join `address` `a` on((`u`.`aid` = `a`.`aid`))) where (`orders`.`uid` = 12) ;

-- --------------------------------------------------------

--
-- Struktur for visning `humband8117`
--
DROP TABLE IF EXISTS `humband8117`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `humband8117`  AS  select `u`.`username` AS `username`,`u`.`full_name` AS `full_name`,`u`.`email` AS `email`,`p`.`pname` AS `pname`,`a`.`adress` AS `adress`,`a`.`zip` AS `zip`,`a`.`city` AS `city`,`a`.`country` AS `country` from (((`orders` join `users` `u` on((`u`.`uid` = `orders`.`uid`))) join `products` `p` on((`p`.`pid` = `orders`.`pid`))) join `address` `a` on((`u`.`aid` = `a`.`aid`))) where (`orders`.`uid` = 19) ;

-- --------------------------------------------------------

--
-- Struktur for visning `magvib`
--
DROP TABLE IF EXISTS `magvib`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `magvib`  AS  select `u`.`username` AS `username`,`u`.`full_name` AS `full_name`,`u`.`email` AS `email`,`p`.`pname` AS `pname`,`a`.`adress` AS `adress`,`a`.`zip` AS `zip`,`a`.`city` AS `city`,`a`.`country` AS `country` from (((`orders` join `users` `u` on((`u`.`uid` = `orders`.`uid`))) join `products` `p` on((`p`.`pid` = `orders`.`pid`))) join `address` `a` on((`u`.`aid` = `a`.`aid`))) where (`orders`.`uid` = 11) ;

-- --------------------------------------------------------

--
-- Struktur for visning `ovent19796654`
--
DROP TABLE IF EXISTS `ovent19796654`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ovent19796654`  AS  select `u`.`username` AS `username`,`u`.`full_name` AS `full_name`,`u`.`email` AS `email`,`p`.`pname` AS `pname`,`a`.`adress` AS `adress`,`a`.`zip` AS `zip`,`a`.`city` AS `city`,`a`.`country` AS `country` from (((`orders` join `users` `u` on((`u`.`uid` = `orders`.`uid`))) join `products` `p` on((`p`.`pid` = `orders`.`pid`))) join `address` `a` on((`u`.`aid` = `a`.`aid`))) where (`orders`.`uid` = 18) ;

-- --------------------------------------------------------

--
-- Struktur for visning `plinted5841`
--
DROP TABLE IF EXISTS `plinted5841`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `plinted5841`  AS  select `u`.`username` AS `username`,`u`.`full_name` AS `full_name`,`u`.`email` AS `email`,`p`.`pname` AS `pname`,`a`.`adress` AS `adress`,`a`.`zip` AS `zip`,`a`.`city` AS `city`,`a`.`country` AS `country` from (((`orders` join `users` `u` on((`u`.`uid` = `orders`.`uid`))) join `products` `p` on((`p`.`pid` = `orders`.`pid`))) join `address` `a` on((`u`.`aid` = `a`.`aid`))) where (`orders`.`uid` = 17) ;

-- --------------------------------------------------------

--
-- Struktur for visning `sesider5617`
--
DROP TABLE IF EXISTS `sesider5617`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `sesider5617`  AS  select `u`.`username` AS `username`,`u`.`full_name` AS `full_name`,`u`.`email` AS `email`,`p`.`pname` AS `pname`,`a`.`adress` AS `adress`,`a`.`zip` AS `zip`,`a`.`city` AS `city`,`a`.`country` AS `country` from (((`orders` join `users` `u` on((`u`.`uid` = `orders`.`uid`))) join `products` `p` on((`p`.`pid` = `orders`.`pid`))) join `address` `a` on((`u`.`aid` = `a`.`aid`))) where (`orders`.`uid` = 14) ;

-- --------------------------------------------------------

--
-- Struktur for visning `suittled9259`
--
DROP TABLE IF EXISTS `suittled9259`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `suittled9259`  AS  select `u`.`username` AS `username`,`u`.`full_name` AS `full_name`,`u`.`email` AS `email`,`p`.`pname` AS `pname`,`a`.`adress` AS `adress`,`a`.`zip` AS `zip`,`a`.`city` AS `city`,`a`.`country` AS `country` from (((`orders` join `users` `u` on((`u`.`uid` = `orders`.`uid`))) join `products` `p` on((`p`.`pid` = `orders`.`pid`))) join `address` `a` on((`u`.`aid` = `a`.`aid`))) where (`orders`.`uid` = 16) ;

-- --------------------------------------------------------

--
-- Struktur for visning `tindst1371`
--
DROP TABLE IF EXISTS `tindst1371`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `tindst1371`  AS  select `u`.`username` AS `username`,`u`.`full_name` AS `full_name`,`u`.`email` AS `email`,`p`.`pname` AS `pname`,`a`.`adress` AS `adress`,`a`.`zip` AS `zip`,`a`.`city` AS `city`,`a`.`country` AS `country` from (((`orders` join `users` `u` on((`u`.`uid` = `orders`.`uid`))) join `products` `p` on((`p`.`pid` = `orders`.`pid`))) join `address` `a` on((`u`.`aid` = `a`.`aid`))) where (`orders`.`uid` = 20) ;

-- --------------------------------------------------------

--
-- Struktur for visning `whespers1681`
--
DROP TABLE IF EXISTS `whespers1681`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `whespers1681`  AS  select `u`.`username` AS `username`,`u`.`full_name` AS `full_name`,`u`.`email` AS `email`,`p`.`pname` AS `pname`,`a`.`adress` AS `adress`,`a`.`zip` AS `zip`,`a`.`city` AS `city`,`a`.`country` AS `country` from (((`orders` join `users` `u` on((`u`.`uid` = `orders`.`uid`))) join `products` `p` on((`p`.`pid` = `orders`.`pid`))) join `address` `a` on((`u`.`aid` = `a`.`aid`))) where (`orders`.`uid` = 15) ;

--
-- Begrænsninger for dumpede tabeller
--

--
-- Indeks for tabel `address`
--
ALTER TABLE `address`
  ADD PRIMARY KEY (`aid`);

--
-- Indeks for tabel `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`oid`),
  ADD KEY `username` (`uid`),
  ADD KEY `pid` (`pid`);

--
-- Indeks for tabel `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`pid`);

--
-- Indeks for tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`uid`),
  ADD KEY `aid` (`aid`);

--
-- Brug ikke AUTO_INCREMENT for slettede tabeller
--

--
-- Tilføj AUTO_INCREMENT i tabel `address`
--
ALTER TABLE `address`
  MODIFY `aid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- Tilføj AUTO_INCREMENT i tabel `orders`
--
ALTER TABLE `orders`
  MODIFY `oid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- Tilføj AUTO_INCREMENT i tabel `products`
--
ALTER TABLE `products`
  MODIFY `pid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Tilføj AUTO_INCREMENT i tabel `users`
--
ALTER TABLE `users`
  MODIFY `uid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- Begrænsninger for dumpede tabeller
--

--
-- Begrænsninger for tabel `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`uid`) REFERENCES `users` (`uid`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  ADD CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`pid`) REFERENCES `products` (`pid`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Begrænsninger for tabel `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `users_ibfk_1` FOREIGN KEY (`aid`) REFERENCES `address` (`aid`) ON DELETE RESTRICT ON UPDATE RESTRICT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
