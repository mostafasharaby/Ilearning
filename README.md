# iLearning - Full Stack Course Management System with Admin Dashboard

The **iLearning** project is a dynamic **Course Management System** designed for educational institutions to manage courses, students, and instructors. Built with **ASP.NET Core 8** for the backend and **MVC architecture**, it allows administrators to manage courses, assign instructors, and track students' progress. The application also supports user authentication, course enrollment, and more.

## Table of Contents
- [Technologies Used](#technologies-used)
- [Features](#features)
- [Security](#security)
- [Getting Started](#getting-started)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Technologies Used
- **Backend**: ASP.NET Core 8 (MVC Architecture)
- **Frontend**: Razor Pages for MVC Views
- **Database**: SQL Server
- **Authentication & Authorization**: ASP.NET Core Identity (Role-based access)
- **API Communication**: RESTful APIs
- **UI Framework**: Bootstrap 5 for responsive and modern UI

## Features

### User-Facing Features
- **User Authentication**: Secure user registration, login, and password recovery.
  - **Role-Based Access**: Differentiated access levels for students, instructors, and administrators.
- **Course Management**:
  - **Course Listings**: Users can view a list of available courses with detailed descriptions.
  - **Course Enrollment**: Students can enroll in available courses, track progress, and view grades.
  - **Instructor Dashboard**: Instructors can view and manage enrolled students, assign grades, and update course content.
- **Student Dashboard**:
  - **Progress Tracking**: Students can monitor their progress through enrolled courses.
  - **Assignments and Grading**: Students can submit assignments and view grades.
- **Admin Dashboard**:
  - **User Management**: Admins can manage users (students and instructors), including role assignment.
  - **Course Management**: Admins can add, edit, and delete courses and assign instructors.
  - **Reporting & Analytics**: Visualize course statistics, student enrollments, and instructor performance.

### Admin Features
- **Role-Based Permissions**: Admins have complete control over the system, with differentiated permissions for students and instructors.
- **Analytics Dashboard**: Real-time graphs and statistics on course registrations, student progress, and instructor performance.
- **Course and Instructor Assignment**: Admins can assign courses to instructors and view detailed reports on course engagement.
  
## Security
- **Data Protection**: The system ensures secure handling of sensitive data such as student information and course materials.
- **Role-Based Authentication**: The use of **ASP.NET Core Identity** ensures that users only have access to authorized areas based on their roles (Admin, Instructor, Student).
- **Password Policies**: Strong password policies are enforced to ensure secure authentication.

## Getting Started

### Prerequisites
To run this project locally, ensure the following tools are installed:
- **.NET SDK 8** (for backend development with ASP.NET Core MVC)
- **SQL Server** (for database management)
- **Visual Studio 2022** (or any compatible IDE) for running and debugging the project

### Installation

#### Clone the Repository
```bash
git clone https://github.com/mostafasharaby/iLearning.git
cd iLearning
