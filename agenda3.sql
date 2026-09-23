-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 10-09-2026 a las 22:15:51
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `agenda3`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuentacte`
--

CREATE TABLE `cuentacte` (
  `Id` int(11) NOT NULL,
  `Id_Agenda` int(11) NOT NULL,
  `FechaApertura` date NOT NULL,
  `LimiteCredito` decimal(10,2) NOT NULL,
  `EstadoCredito` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `personas`
--

CREATE TABLE `personas` (
  `DNI` int(11) NOT NULL,
  `APELLIDO` varchar(100) NOT NULL,
  `NOMBRES` varchar(100) NOT NULL,
  `CALLE` varchar(150) NOT NULL,
  `DEPTO` varchar(20) DEFAULT NULL,
  `PISO` int(11) DEFAULT NULL,
  `CIUDAD` varchar(100) DEFAULT NULL,
  `TELEFONO` varchar(50) DEFAULT NULL,
  `EMAIL` varchar(150) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `personas`
--

INSERT INTO `personas` (`DNI`, `APELLIDO`, `NOMBRES`, `CALLE`, `DEPTO`, `PISO`, `CIUDAD`, `TELEFONO`, `EMAIL`) VALUES
(12345678, 'Perez', 'Juan', 'Av. Siempre Viva', 'A', 3, 'Buenos Aires', '1122334455', 'juan@gmail.com');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `cuentacte`
--
ALTER TABLE `cuentacte`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Id_Agenda` (`Id_Agenda`);

--
-- Indices de la tabla `personas`
--
ALTER TABLE `personas`
  ADD PRIMARY KEY (`DNI`);

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `cuentacte`
--
ALTER TABLE `cuentacte`
  ADD CONSTRAINT `cuentacte_ibfk_1` FOREIGN KEY (`Id_Agenda`) REFERENCES `personas` (`DNI`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
