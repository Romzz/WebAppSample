# WebAppSample
PLAYnGo Test Application

This Web Application used the following:
-- ASP.Net 5
-- MVC 6
-- EF 7


This app is to be passed as an Application Requirement

How to Run:

After opening the Solution, Open a Command Prompt in the project directory:
I.E. (WebAppSample/src/WebAppSample). *Make sure to be in the directory inside /src

cd C:\Projects\WebAppSample\src\WebAppSample

Then run the following Command:

dnu restore

dnx ef migrations add Initial

dnx ef database update
