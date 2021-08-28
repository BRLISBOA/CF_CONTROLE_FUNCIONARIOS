-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 28/08/2021 às 02:14
-- Versão do servidor: 10.4.19-MariaDB
-- Versão do PHP: 8.0.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `funcionarios`
--
CREATE DATABASE IF NOT EXISTS `funcionarios` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `funcionarios`;

-- --------------------------------------------------------

--
-- Estrutura para tabela `funcionarios`
--

CREATE TABLE `funcionarios` (
  `idfuncionarios` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `sexo` varchar(45) NOT NULL,
  `idade` varchar(45) NOT NULL,
  `cargo` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Despejando dados para a tabela `funcionarios`
--

INSERT INTO `funcionarios` (`idfuncionarios`, `nome`, `sexo`, `idade`, `cargo`) VALUES
(1, 'Raimundo', 'MASCULINO', '42', 'Despachante'),
(2, 'Diego Lobato', 'MASCULINO', '42', 'Despachante'),
(3, 'Mauricio Monteiro', 'MASCULINO', '42', 'Encarregado de Obras'),
(4, 'Marcia Elis', 'FEMININO', '42', 'Gerente de Recursos Humanos'),
(5, 'Mateus Brebal', 'MASCULINO', '38', 'professor');

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `funcionarios`
--
ALTER TABLE `funcionarios`
  ADD PRIMARY KEY (`idfuncionarios`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `funcionarios`
--
ALTER TABLE `funcionarios`
  MODIFY `idfuncionarios` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
