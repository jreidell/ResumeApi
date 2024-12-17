*** THIS IS DEPRECATED -- A NEWER VERSION EXISTS AND HAS ALREADY REPLACED THIS CODE IN AZURE ***
** THAT VERSION IS NOT PUBLICLY AVAIABLE ***

# ResumeApi - from Reidell.net
** NOTE: THIS IS A WORK IN PROGRESS AND SHOULD NOT BE CONSIDERED A COMPLETE SOLUTION! MULTIPLE UPDATES ARE BEING WORKED ON VIA LOCAL BRANCHES. THOSE BRANCHES WILL BE INCORPORATED INTO THE MASTER AS THEY ARE FULLY REALIZED OR AT LEAST DEEMED TO BE STABLE ENOUGH FOR PUBLIC REVIEW **

A demo application of an async repository pattern, aspnet core, RESTful web api that provides access to a MSSQL database schema representation of a Resume. The User Interface applications used to view this data view the RESTful web api are implemented using 
angular, react, android, iPhone and UWP. All of these UIs can be used to view the data via different "resume viewers". These are 
represented as a series of pages, components, fragments, modules, models, services and markup languages in various applications frameworks.

This is a Web API implementation of an entity based resume model. This is based on my personal resume and is not intended to be a 
standard be-all/end-all implementation of a resume, just a playground to demostrate my capabilities and an opportunity to use real 
world data in a real world scenario.

Solution Files:

1. RdlNet2018DB - This is a folder that contains a simple table creation script and an ER Diagram image to show what the db 
                  schema should look like upon creation. The files in this folder are included as a solution folder named 
                  DBFiles.                  

2. RdlAngUI - ANGULAR 6 JS APP - This is a basic web UI that hosts a description of the application components with various links 
               to demonstrated technologies and disaplys the Resume data formatted in a readable format that can be distributed and 
               viewed on multiple platforms (web/mobile/etc.). This is a more stable and structured project and application.

3. RdlDocSvc - Docker Container implementation of the Resume Web API that provides a RESTful web interface to access the database.

4. RdlMobUI - This is a Xamarin Forms library that is shared between the Android and iOS projects.

5. RdlMvcUI - This Application is both a Resume Viewer UI and a Resume Web API Service wrapped into one. This application has replaced 
              the Resume Web API Service hosted in Azure. Now both the service endpoints and the UIs can be viewed and interacted with.

6. RdlMobUI.Android - This is an Android application that displays the resume data on the Android platform.

7. RdlMobUI.iOS - This is an iPhone/iOS application that displays the resume data on the iOS platform

8. RdlNet2018 - This is the Resume Web API that provides a RESTful web interface to access the database. This API provides Resume 
                data in JSON format for consumption by the Web and Mobile applications contained within this solution.

9. RdlNet2018.Common - This project contains Resume Model Entities (POCO) that are shared between the entire solution as well as the 
                       the Interface Contracts, Database Context Objects and Repository Implementation Objects (Contract/Concrete).

10. RdlNetReact - REACT JS APP - This is a basic web UI that hosts a description of the application components with various links
                 to demonstrated technologies and disaplys the Resume data formatted in a readable format that can be distributed 
                 and viewed on multiple platforms (web/mobile/etc.)
                 
11. RdlNetSvc - This is a Microservice Implementation of the Resume Web API that provides a RESTful web interface to access the 
               database. This API provides Resume data in JSON format for consumption by the Web and Mobile applications contained 
               within this solution. This Reliable Service will run in an Azure Service Fabric/Clustered Environment.

12. RdlNetSvcApp - This is a Microservice Configuration of the Resume Web API served by RdlNetSvc.

13. RdlWebUI - ANGULAR 5 JS APP - This is a basic web UI that hosts a description of the application components with various links 
               to demonstrated technologies and disaplys the Resume data formatted in a readable format that can be distributed and 
               viewed on multiple platforms (web/mobile/etc.).


