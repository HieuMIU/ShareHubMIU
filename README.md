# ShareHubMIU

## Description

ShareHub MIU is a dedicated platform for students and staff at Maharishi International University to easily share, exchange, and rent items within the MIU community. From rooms and cars to furniture and electronics, ShareHub MIU fosters a sustainable and convenient way to connect and support one another. Users can list items for free or for a fee, making it simple to find what they need or pass along what they no longer use.

The platform offers unique features for four user roles—Admin, Moderator, Provider, and User—each with specific permissions and functionalities to ensure a smooth and secure experience.

- **Admin**: The Admin oversees the entire system, managing all users (Mods, Providers, and regular Users) with full control over account actions, including banning, unbanning, and deleting users. 
Admin aslo manage all requested or approved item on the marketplace.

- **Moderator(Mod)**: Mod will support Admin in marketplace management, Mod review and approve item listing request submitted by Providers. 
If items are approved, they will be displayed on the marketplace, where they become available for Users.

- **Provider**: Any users who have items to share, exchange or rent in MIU community can register as Provider. They can request for items to list in the marketplace.
They can accept or decline transaction request from interest User and set transaction terms, including the option for online payment. Providers are notified by email about requests and updates and can interact with Users to finalize transaction.

- **User**: Users browse the marketplace to find items they need and can request transactions with Providers. They follow items or Providers and complete transactions by making payments when required. Users also have the ability to rate and review both items and Providers, fostering trust within the community. Additionally, they can report Providers if issues arise, notifying the Admin.
The Users also manage their request, transaction history and can cancel In-Process transaction.

Throughout each transaction and interaction, the system sends automated email notifications to relevant users, keeping them informed of changes and progress. This collaborative process between roles ensures a safe, engaging, and efficient environment for sharing and exchanging resources across the MIU community.

## Tech Stack

- **.NET Core MVC (.NET 8)**: Framework for building web applications.
- **Entity Framework Core**: ORM for database interactions.
- **ASP.NET Core Identity**: Authentication and authorization framework.
- **Cosmos DB**: Database management system.
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

