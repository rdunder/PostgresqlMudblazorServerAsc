# Asp.Net Blazor Server Webapp

### The requirements for this project
* Simple and clean design
* Login function for members
* Admin is the the one who register users
* There can be more than one admin
* Members has to be able to remove or change their account
* Schedule for activities, that anyone who is admin can add to or edit

### Project Summary
The project is build with Asp.Net core Blazor server template and it uses Mudblazor components for look and feel, currently it uses a PostgreSQL database to store users and activities and entity framework to manage the database. Asp.net Identity is used for Authentication. Identity is customized to meet the needs of requirements, admin can register users who is then sent a link that resets the password so that the user can choose a password for the site. 
