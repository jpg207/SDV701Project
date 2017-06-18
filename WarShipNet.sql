-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 18, 2017 at 07:31 AM
-- Server version: 10.1.21-MariaDB
-- PHP Version: 7.1.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `warshipsnet`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddOrder` (IN `UserName` VARCHAR(70), IN `Email` VARCHAR(255), IN `ItemQuantity` MEDIUMINT(9), IN `inShipID` MEDIUMINT(8))  BEGIN 
SET @Date = (SELECT CURDATE());
SET @Cost = (SELECT Price FROM ship WHERE ShipID = inShipID) * ItemQuantity;
SET @Stock = (SELECT StockQuanitiy FROM Ship WHERE ShipID = inShipID) - ItemQuantity;
UPDATE ship SET StockQuanitiy=@Stock WHERE ShipID = inShipID;
INSERT INTO `order`(`DateOfOrder`, `Quantity`, `Price`, `CustomerEmail`, `Name`, `ShipID`) VALUES (@Date, ItemQuantity, @Cost, Email, UserName, inShipID);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `AddShip` (IN `ShipClassType` VARCHAR(50), IN `ShipName` VARCHAR(50), IN `ShipPrice` DECIMAL, IN `ShipStock` MEDIUMINT(9), IN `ShipTorpBulge` MEDIUMINT(9), IN `ShipHeal` MEDIUMINT(9), IN `ShipPlane` VARCHAR(50), IN `ShipTorps` VARCHAR(9), IN `ShipNation` MEDIUMINT(8))  BEGIN 
SET @Date = (SELECT CURDATE());
INSERT INTO `ship`(`$type`, `Name`, `Price`, `DateOfModification`, `StockQuanitiy`, `TorpedoBulge`, `HealAmount`, `PlaneType`, `TorpedoTubeCount`, `NationID`) VALUES (ShipClassType, ShipName, ShipPrice, @Date, ShipStock, ShipTorpBulge, ShipHeal, ShipPlane, ShipTorps, ShipNation);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteOrder` (IN `OrderKey` VARCHAR(255))  BEGIN
DELETE FROM `order` WHERE `OrderID` = OrderKey;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteShip` (IN `ShipKey` VARCHAR(255))  BEGIN 
DELETE FROM `ship` WHERE `ShipID` = ShipKey;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllNations` ()  BEGIN 
SELECT * FROM nation;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectAllOrders` ()  BEGIN
  SELECT * FROM `order`;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SelectShips` (IN `ID` VARCHAR(255))  BEGIN 
SET @NationID = ID;
SELECT * FROM ship WHERE NationID = @NationID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateShip` (IN `ID` MEDIUMINT, IN `ShipName` VARCHAR(50), IN `ShipPrice` DECIMAL, IN `ShipStock` MEDIUMINT(9), IN `ShipTorpBulge` MEDIUMINT(9), IN `ShipHeal` MEDIUMINT(9), IN `ShipPlane` VARCHAR(50), IN `ShipTorps` VARCHAR(9))  BEGIN 
SET @Date = (SELECT CURDATE());
UPDATE `ship` SET `Name` = ShipName, `Price` = ShipPrice, `DateOfModification` = @Date, `StockQuanitiy` = ShipStock, `TorpedoBulge` = ShipTorpBulge, `HealAmount` = ShipHeal, `PlaneType` = ShipPlane, `TorpedoTubeCount` = ShipTorps WHERE `ShipID` = ID;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `nation`
--

CREATE TABLE `nation` (
  `NationID` mediumint(8) UNSIGNED NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `BuildingCapacity` mediumint(9) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `nation`
--

INSERT INTO `nation` (`NationID`, `Name`, `BuildingCapacity`) VALUES
(1, 'USA', 2500),
(2, 'Japan', 100);

-- --------------------------------------------------------

--
-- Table structure for table `order`
--

CREATE TABLE `order` (
  `OrderID` mediumint(8) UNSIGNED NOT NULL,
  `DateOfOrder` varchar(10) DEFAULT NULL,
  `Quantity` mediumint(9) DEFAULT NULL,
  `Price` decimal(4,0) DEFAULT NULL,
  `CustomerEmail` varchar(255) DEFAULT NULL,
  `Name` varchar(70) DEFAULT NULL,
  `ShipID` mediumint(8) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `order`
--

INSERT INTO `order` (`OrderID`, `DateOfOrder`, `Quantity`, `Price`, `CustomerEmail`, `Name`, `ShipID`) VALUES
(21, '2017-06-04', 2, '300', 'a@a', 'aa', 2),
(22, '2017-06-04', 2, '300', 'a@a', 'aa', 2),
(23, '2017-06-04', 3, '450', 'jpg207@gmail.com', 'Jonathan', 2),
(24, '2017-06-05', 3, '300', 'HJHHIUI@adad', 'David', 4),
(25, '2017-06-05', 5, '500', 'a@a', 'Amber', 4),
(26, '2017-06-05', 5, '1000', 'a@a', 'ddsdssd', 1),
(27, '2017-06-07', 10, '9999', 'A@B.com', 'Alex', 1);

-- --------------------------------------------------------

--
-- Table structure for table `ship`
--

CREATE TABLE `ship` (
  `$type` varchar(50) NOT NULL,
  `ShipID` mediumint(8) UNSIGNED NOT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `Price` decimal(4,0) DEFAULT NULL,
  `DateOfModification` date DEFAULT NULL,
  `StockQuanitiy` mediumint(9) DEFAULT NULL,
  `TorpedoBulge` mediumint(9) DEFAULT NULL,
  `HealAmount` mediumint(9) DEFAULT NULL,
  `PlaneType` varchar(50) DEFAULT NULL,
  `TorpedoTubeCount` varchar(9) DEFAULT NULL,
  `NationID` mediumint(8) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ship`
--

INSERT INTO `ship` (`$type`, `ShipID`, `Name`, `Price`, `DateOfModification`, `StockQuanitiy`, `TorpedoBulge`, `HealAmount`, `PlaneType`, `TorpedoTubeCount`, `NationID`) VALUES
('AdminApp.clsBattleShip, AdminApp', 1, 'New Mexico', '2001', '2017-06-06', 10, 25, 2000, NULL, NULL, 1),
('AdminApp.clsBattleShip, AdminApp', 2, 'Fuso', '150', '0000-00-00', 15, 30, 1000, NULL, NULL, 2),
('AdminApp.clsCruiser, AdminApp', 4, 'Fiji', '1001', '2017-06-06', 15, NULL, NULL, 'Fighter', '2', 1),
('AdminApp.clsBattleShip, AdminApp', 5, 'Colorado', '200', '2017-06-07', 0, 20, 2000, NULL, NULL, 1),
('AdminApp.clsCruiser, AdminApp', 10, 'DASasd', '1111', '2017-06-14', 0, NULL, NULL, '', '', 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `nation`
--
ALTER TABLE `nation`
  ADD PRIMARY KEY (`NationID`);

--
-- Indexes for table `order`
--
ALTER TABLE `order`
  ADD PRIMARY KEY (`OrderID`),
  ADD KEY `ShipID` (`ShipID`);

--
-- Indexes for table `ship`
--
ALTER TABLE `ship`
  ADD PRIMARY KEY (`ShipID`),
  ADD KEY `Nationid` (`NationID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `nation`
--
ALTER TABLE `nation`
  MODIFY `NationID` mediumint(8) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `order`
--
ALTER TABLE `order`
  MODIFY `OrderID` mediumint(8) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;
--
-- AUTO_INCREMENT for table `ship`
--
ALTER TABLE `ship`
  MODIFY `ShipID` mediumint(8) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `order`
--
ALTER TABLE `order`
  ADD CONSTRAINT `order_ibfk_1` FOREIGN KEY (`ShipID`) REFERENCES `ship` (`Shipid`);

--
-- Constraints for table `ship`
--
ALTER TABLE `ship`
  ADD CONSTRAINT `ship_ibfk_1` FOREIGN KEY (`Nationid`) REFERENCES `nation` (`nationid`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
