# BlogEngine
Project to expose endpoints for a Blog Engine.

This is a REST API that provides authentication (users and passwords harcoded) and authorization (by JWT). Provides three roles: Public, Writer and Editor.
The status of the posts that a writer writes can be: IN PROGRESS, PENDING APPROVAL, APPROVED or REJECTED.

It can be tested with the postman files attached to the main mail. None front side was implemented.

Stack used:
ASP.NET
SQL Database with EF Core (Code First)
DI provided by .Net Core 6

Repository in: https://github.com/willpinilla/BlogEngine

Prereq:
SQL Server Database with Windows Authentication

Steps to run app:
Clone repo
Run API project (should create db, populate with some seed data)
Import postman files, replace variables and execute requests
