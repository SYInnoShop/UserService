# Overview

The microservice provides users with CRUD operations and soft delete mechanisms. It also provides user authentication and authorization with email confirmation.

### Features
- User registration and login functionality
- Password hashing and verification 
- Email notifications for registration and password reset
- JWT-based authentication for secure API access
- Integration with Product Service 

### Architecture, infrastructure, technology
- Clean architecture
- SQRC
- Azure App Service
- Azure SQL
- Azure Key Vault
- Azure AD B2C
- GitHub actions
- .Net 9
- EF


### APIs

#### Access Levels
- Public: Anyone can access the endpoint
- User: The user who owns the resource can access the endpoint
- Admin: Only administrators can access the endpoint

#### Auth 


#### User

