## UltraPlay CinemaAPI Task
##### Content
1. Project Task
2. Results
3. [Project Planning](https://github.com/VeselinovStf/UP_CinamaSystem/projects/1 "Details Here")
4. [ Task Notes  ](https://github.com/VeselinovStf/UP_CinamaSystem/projects/2 "( Detail Here )")
5. Used Literature and Videos

### 1. Project Task 
	
> You are given a .NET Web Api project. It uses Entity Framework to communicate with MSSQL Server. Its purpose is to manage cinemas and their projections of movies. Currently there are several controllers implemented which expose endpoints to create cinemas, rooms in these cinemas, movies and projections of these movies in cinemas. There is no front-end, therefore when testing you have to call the endpoints through Postman (https://www.getpostman.com) or other HTTP clients. - https://bitbucket.org/ikarimanov_ultraplay/cinemapi/src   - Project source code Instructions 
> 

>  The goal is to finish the entire assessment. Incomplete answers will be marked as incorrect.

> 
> Each section has different instructions and different expectations. Make sure you read the directions in each section.

### 2. Result

During the implementation of the assignment, I decided to use the presented model of work from the base source code. Although I have more experience with the use of server lever ( who exchange information between repositories and controllers), I decided to continue using the presented project concept to solve the tasks.

### 3. Tasks
#### Section 1. Extend Projection database table with information for available seats count.	

> Using Entity Framework code first add new column called “AvailableSeatsCount” into Projection table. The column can not accept negative values. This means you can not insert new projection with “AvailableSeatsCount” value less than 
#### Section 2. 
	
#### GET - /api/projection/{projectionId}/availibleSeatsCount 

> Expose endpoint which will return available seats count for a not started projection. The endpoint should receive a projection id and return available seats count. Note: Return relevant http status code and descriptive message when user try to request finished or started projection. 
#### Section 3.

#### POST - /api/reservation/create/{projectionId}/{row}/{col}

>  Expose endpoint for reserving seats for given projection. The endpoint should receive the projection id, row and column which user wants to reserve. Users cannot reserve: - Seats for finished projections or projections starting in less than 10 minutes - Already reserved seats - Seats not existing in a room
> When a reservation is done, return a reservation ticket object and decrease projection available seats count. The reservation ticket object should contain the following information. - Unique key of a reservation - Projection start date - Movie name - Cinema name - Room number - Row
> - Column
#### Section 4. 

> Expose functionality which cancel a reservation. All reservations should be canceled 10 minutes before projection starts. Increase projection available seats count with canceled seats. 
#### Section 5. 
	
> Expose two endpoints for buying tickets for a given projection. 
#### Section 5.1.

#### POST - /api/ticket/buy/{reservationKey}

> Buying ticket without reservation. The endpoint should receive projection id, row and column which user wants to take. The user cannot buy ticket for:  - Finished or started projections.  - Reserved or bought seats.
#### Section 5.2. 

#### POST - /api/ticket/buy/{projectionId}/{row}/{col}

> Buying ticket with reservation The endpoint should receive the reservation unique key. The user cannot buy a ticket:   - With reservation 10 minutes before the projection starts.    - For canceled reservation   - more than once with same reservation key Note: All reservations should be canceled 10 minutes before projection starts. This mean all reserved seats should be available for buying a ticket. Both endpoints should return object with following information: Ticket unique key - Projection start date - Movie name - Cinema name - Room number - Row - Column IMPORTANT: Both endpoints should decrease projection available seats count.

#### Recommendations:  
	
> Select only what you need from database. - Expect hundreds of users using this application at the same time. Lots of users might want to reserve or buy tickets at once for movies right after they are released. Note: You may modify the existed code at your discretion as well as to add missing components if you think it is necessary. Evaluation criteria: - Maintainability (Code reusability and extensibility) - Data selections - Performance - Concurrency - Validations and Error handling - Returning on correct http status codes and descriptive messages. Thank you for your time and effort in making this assessment! 

### 3. Project Planning [( Detailed Info Here )](https://github.com/VeselinovStf/UP_CinamaSystem/projects/1 "( Details Here )")

### 4. Task Notes - Project Tasks Work flow [( Detailed Info Here )](https://github.com/VeselinovStf/UP_CinamaSystem/projects/2 "( Detail Here )")

<dl>
  <dt>Project target</dt>
   <dd>API purpose is to manage cinemas and their projections of movies</dd>
  <dt>Current State</dt>
  <dd> .NET Web Api project</dd>
  <dd>Entity Framework to communicate with MSSQL Server.</dd>
<dd> Endpoints to create cinemas, rooms in these cinemas, movies and projections of these movies in cinemas.</dd>
  <dt>Task walkthrough</dt>
<dd> | | Examine task requirements </dd>
  <dd> | | Examine code base</dd>
  <dt> List api associations - routs</dt>
  <dd>Section 2: Methods: GET <--- /api/projection/{projectionId}/availibleSeatsCount  ---> Availible Seats Count : </dd> 
<dd>Section 3: Methods: POST <---  /api/reservation/create/{projectionId}/{row}/{col} ---> Reservation Creation Object </dd> 
<dd>Section 5.1 : Methods: POST <--- /api/ticket/buy/{reservationKey} ---> Ticket </dd> 
<dd>Section 5.2 : Methods: POST <--- /api/ticket/buy/{projectionId}/{row}/{col} ---> Ticket </dd> 
  <dt> Refactor existing code</dt>
	<dd> |X| Settup help page </dd>
	<dd>| | Settup documentation -- add suppress warning 1591 to build</dd>
	<dd>|X| Async Methods </dd>
	<dd>|X| Routeing attributes </dd>
	<dd>| | Service Layer </dd>
	<dd>|X| Model Factory </dd>
	<dd>| | Caching </dd>
	<dd> |X| SetUp Database and db-migration </dd>
	<dd>|X| Settup Database Seed</dd>
	<dd>| | Use of SSL </dd>
	<dd>| | Settup CORS </dd>
	<dd>| | Settup JSONP as format </dd>
	<dd>| | Exposing LINK's to endpoints result </dd>	
  <dt> Work on Task Sections </dt>
	<dd> Analyze task -> add planning to the task board</dd>
	<dd>Build future</dd>
	<dd>Test with Fiddler</dd>
</dl>

### 5. Used Literature and Videos

> Pluralsight - Implementing an API in ASP.NET Web API by Shawn Wildermuth, 
> 	Pluralsight - Building and Securing a RESTful API for Multiple Clients in 	ASP.NET by Kevin Dockx, 
> 	Microsoft - Get Started with ASP.NET Web API 2 (C#) 
