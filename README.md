# ShareHubMIU

## Description

- Problem:
  ![alt text](https://github.com/HieuMIU/ShareHubMIU/blob/main/Documents/ProblemStatement.jpg)
- Solution Idea:
  ![alt text](https://github.com/HieuMIU/ShareHubMIU/blob/main/Documents/ProblemStatement2.jpg)
ShareHub MIU is a dedicated platform for students and staff at Maharishi International University to easily share, exchange, and rent items within the MIU community. From rooms and cars to furniture and electronics, ShareHub MIU fosters a sustainable and convenient way to connect and support one another. Users can list items for free or for a fee, making it simple to find what they need or pass along what they no longer use.

The platform offers unique features for four user roles—Admin, Provider, and User—each with specific permissions and functionalities to ensure a smooth and secure experience.

- **Admin**: The Admin oversees the entire system, managing all users (Mods, Providers, and regular Users) with full control over account actions, including banning, unbanning, and deleting users. 
Admin aslo manage all requested or approved item on the marketplace.

- **Moderator(Mod)**: Mod will support Admin in marketplace management, Mod review and approve item listing request submitted by Providers. 
If items are approved, they will be displayed on the marketplace, where they become available for Users.

- **User**: Users browse the marketplace to find items they need and can request transactions with Providers. They follow items or Providers and complete transactions by making payments when required. Users also have the ability to rate and review both items and Providers, fostering trust within the community. Additionally, they can report Providers if issues arise, notifying the Admin.
The Users also manage their request, transaction history and can cancel In-Process transaction.

Throughout each transaction and interaction, the system sends automated email notifications to relevant users, keeping them informed of changes and progress. This collaborative process between roles ensures a safe, engaging, and efficient environment for sharing and exchanging resources across the MIU community.

## Tech Stack

- **.NET Core MVC (.NET 9)**: Framework for building web applications.
- **Entity Framework Core**: ORM for database interactions.
- **ASP.NET Core Identity**: Authentication and authorization framework.
- **SQL Server**: Database management system.
- **Bootstrap**: Frontend framework for responsive design.

## Application Structure

- **Azure Cloud**: The application will be hosted on Azure, providing resources for deployment, security, and data storage.
- **Clean Architecture**: Architectural pattern for organizing code.

## Overview Structure
![alt text](https://github.com/HieuMIU/ShareHubMIU/blob/main/Documents/Solution-Architecture-Diagram.jpg)

## Class Diagram
![alt text](https://github.com/HieuMIU/ShareHubMIU/blob/main/Documents/Project-Class-Diagram.jpg)

## ER Diagram
![alt text](https://github.com/HieuMIU/ShareHubMIU/blob/main/Documents/Project-ER-Diagram.jpg)

## Installation instructions
- Prerequisite:
  +Visual Studio 2022 or later.
  +Docker
  +Azure Account
- Clone this repository:
  ```
    git clone https://github.com/HieuMIU/ShareHubMIU.git
  ```
- Create a Azure SQL Server instance: https://learn.microsoft.com/en-us/azure/azure-sql/database/single-database-create-quickstart?view=azuresql&tabs=azure-portal
- Open Project by Visual Studio, then open file appsettings.json in ShareHubMIU.Web project and replace ConnectionStrings.DefaultConnection with connection string of your SQL Server
- In Visual Studio, Choose Tool/Nuget Package Manager/Package Manager Console, then the Package Manager Console appears:
  + Choose Default project is ShareHubMIU.Infrastructure, and run this commmand:
    ```
      update-database
    ```
    This project is Code-First, then it will build all migrations to the database
- Pack Release build by Docker: In Visual Studio, left-click on ShareHubMIU.Web and choose Add/Docker support..., and we  have default Dockerfile
    +Result:
  ![alt text](https://github.com/HieuMIU/ShareHubMIU/blob/main/Documents/create-dockerfile.jpg)
  ![alt text](https://github.com/HieuMIU/ShareHubMIU/blob/main/Documents/dockerfile.jpg)
- Run Container(Dockerfile) to create Docker Image and Docker Container
- ![alt text](https://github.com/HieuMIU/ShareHubMIU/blob/main/Documents/build-and-create-image-container.jpg)
- Go to https://hub.docker.com/ and create new repository for new Image
- Push your Image to DockerHub:
    + Open CMD and run below commands:
    + Check your local Image:
      ```
        docker images
      ```
    + Add tag to your Images:
      ```
        docker tag sharehubmiuweb {DOCKER_USERNAME}/{NEW_IMAGE}:latest
      ```
    + Push your image to DockerHub:
      ```
        docker push {DOCKER_USERNAME}/{NEW_IMAGE}
      ```
- Publish to Azure: In Visual Studio, left-click on ShareHubMIU.Web and choose Publish
  ![alt text](https://github.com/HieuMIU/ShareHubMIU/blob/main/Documents/open-publish-popup.jpg)
  + Follow instructions to add Specific target, Container App and Registry
  ![alt text](https://github.com/HieuMIU/ShareHubMIU/blob/main/Documents/open-publish-popup_2.jpg)
  + Choose Container build is Docker Desktop
  ![alt text](https://github.com/HieuMIU/ShareHubMIU/blob/main/Documents/open-publish-popup_3.jpg)
  + Choose Deployment type in your need
  + Wait a few minutes after configuration completed, press Publish to completely Publish into Azure Container App
 
- Enjoy!
