# QR Based Attendance System for DreamSpace



## Introduction

Attendance Management keeps track of your employee or students present/absent details. It is the system to document the time your employees/students work and the time they take off.

This is a computer vision based attendance system prototype that was developed for the DreamSpace Academy to manage the students attendances in a proper way.

This system is using the QR technology as an identity to index the employees/students. Every students or employees will have an identity card that was printed with a QR code. When they scan the QR code, it takes attendance of the particular student or employee.

This computerized system is using a camera as the QR code reader, because it is based on computer vision technology.

This system has two parts in it. The first one is the QR code scanner script that was written in Python, the second part is the management panel that is used to maintain and record attendance details (Written in C#).


## Features
- This system has two main parts: Identity Card Scanner | Management Panel.
- Identity cards could be scanned with the camera module.
- It has a management panel to maintain and record attendance details.
- It gives a welcome/greeting quotes when employees/students scans the QR code.
- Wrong QR code detection.
- This system has a female voice outputs.  
- Students/employees could be registered thorough the management panel.


## Technologies & Frameworks

#### Identity Card Scanner in Python
  - Python - Main programming language
  - Pyzbar - a module for QR code functions
  - PYTTSX3 - a module for voice outputs
  - Playsound - a module for playing external sounds


#### Management Panel in CSharp

  - C# - Main programming language
  - MySQL - Database.


## Configuration and Setup
