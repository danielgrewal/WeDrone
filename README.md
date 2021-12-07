# "WeDrone" - Drone Delivery System Application

## Course Project for SOFE3650 and SOFE3700

**SOFE3650 Course Group 30 and SOFE3700 Final Project Group 24 Members**

Usman Mahmood 100349839</br>
Karanvir Bhogal 100748973</br>
Daniel Grewal 100768376 *(Team Lead)*</br>
Mohammed Adnan Hashmi 100753115</br>

## Link to SOFE3650 FINAL REPORT Document
https://github.com/danielgrewal/WeDrone/blob/main/SOFE3650_FINAL_REPORT.pdf

## Installation Instructions

**Set up ASP.NET Core**
1.	Navigate to https://dotnet.microsoft.com/download. 
2.	Download .NET SDK x64.
3.	Install the downloaded executable file.
**Set up Microsoft SQL Server**
1.	Navigate to https://www.microsoft.com/en-us/sql-server/sql-server-downloads.
2.	Download the SQL Server 2019 Developer Edition by clicking on the Download Now button under “Developer”.
3.	Run the downloaded executable file and follow the instructions to perform a Basic Installation.
**Set up Visual Studio (Note: this is a different product than Visual Studio Code)**
1.	Navigate to https://visualstudio.microsoft.com/ and download Visual Studio Community 2022.
2.	Run the downloaded executable file and follow the instructions; please ensure you minimally select the select the ASP.NET and web development workload.
**Clone Repository and Open the Project**
1.	Using git command-line tools, clone the https://github.com/danielgrewal/WeDrone.git repository. The repository can also be found on https://github.com/danielgrewal/WeDrone if the git command-line tools are not available. 
2.	Open the project folder and run WeDrone.sln under the src sub-folder. This will open Visual Studio. This window can be minimized for now to set up the database.
**Set up Database and API Connection**
1.	Open Microsoft SQL Server Management Studio and run WeDrone.sql in a new query window to create the initial database. This file can be found in the root directory of the repository.
2.	Once the database is created, open up the minimized Visual Studio window and under the WeDrone.Web project, open the appsettings.json file. 
3.	Add the database connection string between the double quotes on the line that says "WeDroneContext": "" to point to the database.
4.	For the application to function a Google API key will need to be provided on the line that says "Key": "InsertYourAPIKeyHere" by replacing InsertYourAPIKeyHere with the actual key. The application will not function if the correct connection string or an API key are not provided. 
**Run Application**
1.	At the top of the Visual Studio IDE, press the play button and a browser window will launch with the application running. Use the username “usman” and the password “password” for testing purposes.


## Link to SOFE3650 Project Progress Report Document (Deliverable 2)
https://github.com/danielgrewal/WeDrone/blob/main/SOFE3650_Project_Progress_Report.pdf

## Link to SOFE3650 Proposal Document (Deliverable 1)
https://github.com/danielgrewal/WeDrone/blob/main/SOFE3650_Project_Proposal_Requirements.pdf

## Link to SOFE3700 Database Design Document (Phase 2)
https://github.com/danielgrewal/WeDrone/blob/main/SOFE3700_Project_Database_Design.pdf

## Link to SOFE3700 Proposal Document (Phase 1)
https://github.com/danielgrewal/WeDrone/blob/main/SOFE3700_Project_Proposal.pdf

## Introduction

The WeDrone Delivery System is a future facing drone delivery service helping consumers with their
delivery needs. The applications for this type of service are endless, including; parcels and packages,
peer-to-peer delivery, food delivery, medical/emergency supply, business-to-business delivery, etc. As the
technology matures, automated drone technologies of the future will strive to be energy efficient and cost
effective. This will empower the WeDrone service to inherently become more affordable and accessible to
all users. This project will enable users to fulfil their automated delivery needs via a web-based
application. The application and associated database will provide a means to track the progress of drone
deliveries. This project will serve as a proof-of-concept, and will not involve the use of real
drones/deliveries. Additionally, the scope of the delivery service will be limited geographically, focusing
on the Greater Toronto Area.

## Problem Our Project Will Address

The WeDrone Delivery System will have several advantages over current delivery services:</br>

● Automation allows for more economical and efficient delivery solutions</br>
● Fast, safe, eco-friendly and reliable 24/7 point to point delivery capability</br>
● Very convenient, self-managed and user friendly delivery service for consumers and businesses</br>

## Goals and Motivations

Our goal is to build a web application and database that will serve as the platform for creating, managing,
tracking, recording and invoicing deliveries using the WeDrone delivery service as a complete end-to-end
solution for WeDrone. Although we are not using real drones, deliveries, customers and transactions, our
application will provide a means to simulate and demonstrate the process for typical use case scenarios.
The motivation behind this project was to actualize a real-world application that would overall benefit
consumers and businesses of various scales. We all use and rely on delivery services one way or another
in our day to day lives. Enhancing this experience whilst making it more convenient and economical for
all parties involved will overall be beneficial for society. Another main motivation for WeDrone was to
provide an eco-friendly and environmentally sound solution to the fast growing trade and commerce
needs of our growing cities and communities. Although this project will target the Greater Toronto Area,
the WeDrone system could potentially be established and executed anywhere in the world.

## Related Work and How Existing Work differs from our Project

Although there are some smaller scale private automated delivery systems (e.g. military, hospitals etc.) or
experimental drone delivery projects being used by large e-commerce organizations (e.g. Amazon,
Alibaba, etc.), there is yet to be a solution for any user or business to ship their items using an on-demand
fully automated drone delivery system. To fulfil these needs currently, you would need to use a courier
service or rideshare, which employs a driver and requires a vehicle likely running on fossil fuels today, to
pick up and drop off your items. How WeDrone differs is that you can get this service without the hassle
and inefficiencies between. Imagine a scenario where you wanted to send a parcel to a friend in your area
right from your home, or where your favourite restaurant or retail store can send an order directly to you
without any dissatisfaction or delay caused by a driver and vehicle subject to traffic and congestion in a
large city. WeDrone will satisfy these needs whilst saving the users’ time and money.

## Methodology and Plan For Our Project

To build the WeDrone user platform application, we have decided to use ASP.NET Core for our backend,
Microsoft SQL Server for our database management system and Tailwind CSS framework for the front
end. Our goal is to publish the application on a live web server for demonstration, although at the very
least it will run locally. An internet connection will be required to use the Google Maps/Places API that
will be embedded into our system to obtain real-world delivery location geocode data. All of our project
progress and planning will be tracked using the KanBan Project board on github.

### Project Board can be found here: https://github.com/users/danielgrewal/projects/2
