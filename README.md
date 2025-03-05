# RSGym Management System

## Project Summary
A comprehensive C# console application for gym management featuring user authentication with multiple role types (Admin, PowerUser, SimpleUser), service-oriented architecture, repository pattern implementation, and clean code practices. The system follows SOLID principles with a focus on separation of concerns and maintainable, extensible code.

## Key Technical Highlights

### Architecture & Design
- Layered architecture (Presentation, Service, Repository, Model)
- Interface-based programming
- Dependency injection pattern
- Repository pattern implementation
- Service layer abstraction
- Clean code practices

### Object-Oriented Features
- Inheritance
  - Base User class with derived role classes (AdminUser, PowerUser, SimpleUser)
  - Polymorphic behavior across user types
- Encapsulation
  - Private fields with public properties
  - Expression-bodied members
  - Data validation within models
- Polymorphism
  - Interface implementations
  - Method overriding for specific behaviors
  - Virtual properties
- Abstraction
  - Interface-based design
  - Service abstraction
  - Repository abstraction

### C# Implementation Features
- Property Features
  - Auto-implemented properties
  - Expression-bodied properties
  - Virtual properties
- Method Features
  - Extension methods
  - Method overloading
  - Input validation
- Modern C# Syntax
  - String interpolation
  - LINQ for data querying
  - Pattern matching
  - Static utilities

### User Management System
- Role-based authentication
  - Admin users
  - Power users
  - Simple users
- Security features
  - Password encryption
  - Input validation
  - Login verification
- User profile management
  - User creation
  - Profile validation
  - User listing and searching

### System Features
- Console-based UI
- Multi-layered authentication
- Input validation
- Error handling
- User-friendly interfaces
- Data persistence
- Scalable architecture

## Class Diagram
```mermaid
classDiagram
    class IUser {
        <<interface>>
        +int Id
        +string Name
        +string LastName
        +string NIF
        +string Email
        +string Username
        +string Password
        +EnumUserProfile UserProfile
    }
    
    class User {
        +static int NextId
        +int Id
        +string Name
        +string LastName
        +string NIF
        +string Email
        +string Username
        +string Password
        +virtual EnumUserProfile UserProfile
        #string FullName
        #string FullUser
        +User()
        +User(string, string, string, string, string, string, EnumUserProfile)
    }
    
    class IAdminUser {
        <<interface>>
    }
    
    class IPowerUser {
        <<interface>>
    }
    
    class ISimpleUser {
        <<interface>>
    }
    
    class AdminUser {
        +override EnumUserProfile UserProfile
        +AdminUser()
        +AdminUser(string, string, string, string, string, string, EnumUserProfile)
    }
    
    class PowerUser {
        +override EnumUserProfile UserProfile
        +PowerUser()
        +PowerUser(string, string, string, string, string, string, EnumUserProfile)
    }
    
    class SimpleUser {
        +override EnumUserProfile UserProfile
        +SimpleUser()
        +SimpleUser(string, string, string, string, string, string, EnumUserProfile)
    }
    
    class IUserService {
        <<interface>>
        +User LogInUser()
        +User CreateUser(User)
        +List~User~ CreateDefaultUsers()
        +string AskUserName()
        +string AskUserPassword()
        +User ValidateUser(string, string)
    }
    
    class IAdminService {
        <<interface>>
        +User CreateUser()
        +void DefineUserType(User)
        +void ListAllUsers()
        +void ListUserById(int)
        +void ListUsersByName(string)
    }
    
    class IUserRepository {
        <<interface>>
        +bool CheckUserName(string)
        +void ListUser(string)
        +List~User~ GetAllUsers()
    }
    
    class IAdminRepository {
        <<interface>>
        +void AddUser(User)
        +User GetUserById(int)
        +IEnumerable~User~ GetUsersByName(string)
        +void UpdateUser(User)
        +List~User~ GetAllUsers()
    }
    
    class ILoginService {
        <<interface>>
    }
    
    class IAppService {
        <<interface>>
        +void RunMainMenu()
        +void RunLoginMenu()
        +int GetUserChoice(string, string)
        +void ShowMenu(string, string)
        +Dictionary ShowMainMenu(string)
        +string ValidateLoginMenu(Dictionary, int)
        +void ShowLogo(string, string)
        +Dictionary ShowLoginMenu()
        +void ShowLogoMessage(string, string)
        +void RunRSGymProgram()
    }
    
    IUser <|.. User
    IAdminUser <|.. AdminUser
    IPowerUser <|.. PowerUser
    ISimpleUser <|.. SimpleUser
    User <|-- AdminUser
    User <|-- PowerUser
    User <|-- SimpleUser
    IUser <|-- IAdminUser
    IUser <|-- IPowerUser
    IUser <|-- ISimpleUser
```

## Service Architecture
```mermaid
flowchart TD
    A[Program] --> B[AppService]
    B --> C[LoginService]
    B --> D[UserService]
    B --> E[AdminService]
    B --> F[PowerUserService]
    B --> G[SimpleUserService]
    C --> H[UserRepository]
    D --> H
    D --> I[AdminRepository]
    D --> J[EncryptPassword]
    E --> I
    F --> I
    G --> I
    H --> I
```

## Technical Requirements
- .NET 6.0 or higher
- C# 10.0 or higher
- Console Application
- Visual Studio 2022

## Project Structure
```
RSGym/
├── Program.cs
├── Enums/
│   └── EnumUserProfile.cs
├── Interfaces/
│   ├── IModels/
│   │   ├── IUser.cs
│   │   ├── IAdminUser.cs
│   │   ├── IPowerUser.cs
│   │   └── ISimpleUser.cs
│   ├── IServices/
│   │   ├── IAppService.cs
│   │   ├── ILoginService.cs
│   │   ├── IUserService.cs
│   │   ├── IAdminService.cs
│   │   ├── IPowerUserService.cs
│   │   └── ISimpleUserService.cs
│   ├── IRepositories/
│   │   ├── IUserRepository.cs
│   │   └── IAdminRepository.cs
│   └── IMethods/
│       └── IEncryptPassword.cs
├── Models/
│   ├── User.cs
│   ├── AdminUser.cs
│   ├── PowerUser.cs
│   └── SimpleUser.cs
├── Services/
│   ├── AppService.cs
│   ├── LoginService.cs
│   ├── UserService.cs
│   ├── AdminService.cs
│   ├── PowerUserService.cs
│   └── SimpleUserService.cs
├── Repositories/
│   ├── UserRepository.cs
│   └── AdminRepository.cs
├── Methods/
│   └── EncryptPassword.cs
└── Utility/
    └── RSGymUtility.cs
```

## User Credentials
The system comes with the following pre-configured users:
- Admin: Username: `melmag`, Password: `123456`
- Power User: Username: `paumag`, Password: `123456`
- Simple User: Username: `clasou`, Password: `123456`

## Installation Steps
1. Clone the repository
   ```bash
   git clone https://github.com/yourusername/rsgym-management-system.git
   ```
2. Navigate to project directory
   ```bash
   cd rsgym-management-system
   ```
3. Open solution in Visual Studio
4. Build the solution
5. Run the application

## Usage
1. Start the application
2. At the login screen, enter your credentials
3. Navigate through the menu system using numeric options
4. Perform operations according to your user role permissions

## Features by User Role

### Admin User
- Create, update, and delete users
- Manage all system aspects
- View all system reports
- Configure system settings

### Power User
- Create and manage gym members
- Manage training sessions
- Generate reports
- Limited administrative capabilities

### Simple User
- View personal information
- Basic system interactions
- Limited view-only access

## License
Copyright (c) 2024 Claudia Souza
All rights reserved.

## Contact
Claudia Souza
Project Link: [https://github.com/yourusername/rsgym-management-system](https://github.com/yourusername/rsgym-management-system)
