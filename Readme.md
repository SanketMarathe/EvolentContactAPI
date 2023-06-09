# Evolent Contact API

## Information

- This repository contains the Contact Information Web API. 
- This API deals with database for contact information CRUD operations. 
- API project is based on repository pattern.
- It restricts us to work directly with the data in the application and creates new layers for database operations, business logic, and the application's UI.
- Project contains In-Memory caching mechanism to retrieve data fastly for rest of the calls.

## Organization of Application

A typical abstract directory layout of the project solution.

```bash
|--EvolentContact.API
   |--Controller
      |--ContactsController.cs
   |--Migration
   |--appsetting.json
   |--Program.cs

|--EvolentContact.Common
   |--Constants
      |--MessageConstant.cs
   |--Models
      |--ContactRequestModel.cs
	  |--ContactResponseModel.cs
   |--Enum
      |--ContactStatus.cs
   |--BaseResponse.cs

|--EvolentContact.Data
   |--Entities
      |--Contact.cs
      |--BaseEntity.cs
   |--Mappers
      |--ContactMapper.cs
   |--Pagination
      |--PaginationExtension.cs
      |--PagedResult.cs
      |--PagedResultBase.cs
   |--EvolentDBContext.cs

|--EvolentContact.Services
   |--Engines
      |--ContactValidationEngine.cs
   |--Services
      |--Implementations
         |--ContactService.cs
         |--LogService.cs
      |--Interfaces
         |--IContactService.cs
	 |--ILogService.cs
   |--Repositories
      |--Implementations
         |--ContactRepository.cs
      |--Interfaces
         |--IContactRepository.cs
	
```

## Prerequisites

```bash
1. Should have .NET 6 installed on your system
2. Should have SQL Server installed on you system configured with database engine.
3. Should have Visual Studio 2019 or above installed to run this project
```

## Steps to run the application

```bash
1. Clome the project repository
2. Run "Update-Database" command from package manager console.
3. Set API project as startup project.
4. Run the API project from Visual Studio.
5. You are all good with project setup. 
6. Play with the API's.
```

## Versioning
This is v1 version of conatct api.

## Author
Sanket Marathe

## Licence
MIT
