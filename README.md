# ResumeApi - from Reidell.net
A demo application of an async repository pattern, aspnet core, web api, angular resume viewer and database schema

This project is an example of some technologies and development/design patterns that I have used as part of  my particular skill set. 

This is a Web API implementation of an entity based resume model. This is based on my personal resume and is not intended to be a 
standard be-all/end-all implementation of a resume, just a playground to demostrate my capabilities and an opportunity to use real 
world data in a real world scenario.

Project Files:

1. DBFiles - This is a folder that contains a simple table creation script and an ER Diagram image to show what the db schema should 
             look like upon creation.

2. RdlMobUI - This is a Xamarin Forms library that is shared between the Android and iOS projects.

3. RdlMobUI.Android - This is an Android application that displays the resume data on the Android platform.

4. RdlMobUI.iOS - This is an iPhone/iOS application that displays the resume data on the iOS platform

5. RdlNet2018 - This is the Resume Web API that provides a RESTful web interface to access the database. This API provides Resume 
                data in JSON format for consumption by the Web and Mobile applications contained within this solution.

6. RdlNet2018.Common - This project contains Resume Model Entities (POCO) that are shared between the entire solution as well as the 
                       the Interface Contracts, Database Contaxt Objects and Repository Implementation Objects (Contract/Concrete).

7. RdlNetReact - REACT JS APP - This is a basic web UI that hosts a description of the application components with various links
                 to demonstrated technologies and disaplys the Resume data formatted in a readable format that can be distributed 
                 and viewed on multiple platforms (web/mobile/etc.)

8. RdlWebUI - ANGULAR 5 JS APP - This is a basic web UI that hosts a description of the application components with various links 
              to demonstrated technologies and disaplys the Resume data formatted in a readable format that can be distributed and 
              viewed on multiple platforms (web/mobile/etc.). WRITTEN USING ANGULAR JS


