![ECommerce Logo](https://cdn.discordapp.com/attachments/961351822092681276/962798017512087552/ECommerce_Logo.png)
# CSCE361 E-Commerce Online Store Application
Final Project for CSCE 361

## Group Members:
Eric Le, Harry Endrulat, Nathan Liew, Kyle Auman, Erica Fenn

## Table of Contents
- [Project Setup](#project-setup)
- [Folders within the Project](#folders-within-the-project)
- [Resources Utilized](#resources-utilized)

## Project Setup:
- First, download the "onlineStoreDB.sql" file located in the "BackEnd/MySQL" folder, and run it in MySQL Workbench on a Local Server with your own local Database
- Second, find "appsettings.json" located in the ECommerce project, and follow the template provided:

`"ConnectionStrings": {
        "Default": "server=localhost;user=root;password=yourpassword;database=yourdatabaseName"
    }`
- With that, the project should be set up and able to run.

## Folders within the Project

### BackEnd/MySQL
This folder contains the sql file consisting of tables and queries necessary to populate the local database.

### FrontEnd
This folder can be ignored. The folder was generally used to store our static webpages (HTML & CSS) in the intial stages of working on the E-Commerce Online Store Application. All of our FrontEnd entities can be found in the "View" folder in the ECommerce project.

### ECommerce
This folder contains the main project where it has:
- ECommerce: The actual project itself containing the entirety of our Model-View-Controller architecture, assets, and connection to the Database. Overall the bulk of the whole project.
- ECommerceUnitTests: This contains the Unit Tests for our controllers utilized in our project.

## Resources Utilized
For the majority, YouTube was our main source of information to learn about how to design and implement our MVC Architecture in regards to creating the Models, Views, Controllers, and how to connect everything together such as utilizing a connection string.

One of the main videos which we used to learn MVC is:
- https://www.youtube.com/watch?v=hZ1DASYd9rk

We also referenced Stack Overflow posts for troubleshooting technical errors which we came across when running our project.
