-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 07, 2021 at 08:04 AM
-- Server version: 10.4.17-MariaDB
-- PHP Version: 8.0.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dsa_attendance_system`
--

-- --------------------------------------------------------

--
-- Table structure for table `attendance_data`
--

CREATE TABLE `attendance_data` (
  `auto_id` int(11) NOT NULL,
  `student_id` varchar(100) NOT NULL,
  `_date` varchar(100) NOT NULL,
  `in_time` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `student_data`
--

CREATE TABLE `student_data` (
  `auto_id` int(11) NOT NULL,
  `student_id` varchar(200) NOT NULL,
  `firstname` varchar(100) NOT NULL,
  `lastname` varchar(100) NOT NULL,
  `dob` varchar(100) NOT NULL,
  `gender` varchar(50) NOT NULL,
  `email` varchar(200) NOT NULL,
  `phone_no` varchar(30) NOT NULL,
  `department` varchar(150) NOT NULL,
  `batch_no` varchar(100) NOT NULL,
  `remarks` varchar(2000) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `student_data`
--

INSERT INTO `student_data` (`auto_id`, `student_id`, `firstname`, `lastname`, `dob`, `gender`, `email`, `phone_no`, `department`, `batch_no`, `remarks`) VALUES
(7, 'stu', 'Guna', 'Rakulan', '01-01-2010', 'Female', 'gunarakulan@gmail.com', '0740001141', 'Software Lab', '1', 'Good person');

-- --------------------------------------------------------

--
-- Table structure for table `user_account`
--

CREATE TABLE `user_account` (
  `auto_id` int(11) NOT NULL,
  `username` varchar(600) NOT NULL,
  `password` varchar(600) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user_account`
--

INSERT INTO `user_account` (`auto_id`, `username`, `password`) VALUES
(7, 'dreamspace-admin', 'dreamspace@123');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `attendance_data`
--
ALTER TABLE `attendance_data`
  ADD PRIMARY KEY (`auto_id`);

--
-- Indexes for table `student_data`
--
ALTER TABLE `student_data`
  ADD PRIMARY KEY (`auto_id`);

--
-- Indexes for table `user_account`
--
ALTER TABLE `user_account`
  ADD PRIMARY KEY (`auto_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `attendance_data`
--
ALTER TABLE `attendance_data`
  MODIFY `auto_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `student_data`
--
ALTER TABLE `student_data`
  MODIFY `auto_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `user_account`
--
ALTER TABLE `user_account`
  MODIFY `auto_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
