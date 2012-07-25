Cavan gaels Project Proposal
============================

c sharp project for
[*National College of Ireland - Enterprise Frameworks*](http://courses.ncirl.ie/index.cfm/page/module/moduleId/17383)
by [Adrian Skehill](http://www.linkedin.com/in/askehill?_mSplash=1).

Sean delete this





National College of Ireland

PGDip in Cloud Computing

2011/2012



			
				Cavan Gaels
Brian Burns x10205284
Sean O Shea x10206230
Lakshman Pusarapu x11106808
Torsby Attipoe x11106409
					 




Enterprise Frameworks


	Group Project Proposal


June 2012






 
 
An introduction to the project subject matter. 
=============================================
The group proposes to develop an online application for a Car Rental Business. This business will be a web based business where customers can log onto a website and book car hire from four different locations throughout the country, Dublin, Cork, Galway and Limerick.
It is proposed that this will be a pure web based business where we will sell car hire to individuals and companies on behalf of companies with fleets of cars. Customers will log on to our website and after choosing options of the location they wish to hire the car from and the category of car they will be given a list of cars available from that location for the dates that they require. The hire price will for each car will be given and the customer can then choose which car they wish to hire. The customer can then proceed to check out and pay for the car hire by either credit card or paypal. The car fleet company will be notified and the particular car will be no longer available for hire.
It is proposed to develop the application using C# and Asp.net on the Microsoft Visual Studio IDE with a mySql database.

The goals of the project.
========================
*	To develop electronic services (e-services) including interactive services, electronic transactions, web based applications etc. that can facilitate efficient and cost-effective on-line transaction processing dissemination / delivery of on-line information to customers and car fleet owners.
*	To develop electronic services (e-services) including interactive services, electronic transactions, web based applications etc. that can facilitate efficient and cost-effective on-line transaction processing dissemination / delivery of on-line information to customers and suppliers.
*	To develop electronic services (e-services) including interactive services, electronic transactions, web based applications etc. that can facilitate efficient and cost-effective on-line transaction processing dissemination / delivery of on-line information to staff, students and to public.
*	To continuously enhance the approaches used in applications development and the capabilities of analysts and project leaders in facilitating process changes.
*	To establish reliable and secure construct in administrative computing environment to ensure smooth operations in mission critical applications.
*	That within 2 months that we will have a fully functioning web site where customers can log on search, book and pay for car hire.
*	That car hire companies can log on and 

The strategy that will be employed to meet the stated project goals.
==================================================================== 
The goals of the project having been clearly defined we will set out clearly what we want to do in the project. How we arrive with the solution that we require. We will set out a list of major tasks to be completed during the project, breaking each one into smaller components. We will list each of these and allocate them out to a member of the group to take responsibility for the task. We will review and amend these tasks as the project proceeds ensuring at all times that the project goals are being adhered to.

The key characteristics of your project in terms of functionality.
================================================================= 
The customer can go online to our website and having been given options to enter dates of car hire, locations that they wish to collect the car from will be given an option to hire cars that are available for hire on that particular date from that location.
The customer will be able to book the car hire online and pay for it by credit card or paypal
The Car Fleet companies will have their own section of the web site where they can log on and amend the details of cars available and check which cars have been hired out. 
The data will be held in a database. It is proposed that there will be a number of tables in the database including supplier, car, availability, booking, user location and payment. The following diagram represents the proposed tables `
 
![Alt text](https://s3.amazonaws.com/cloud12414214/img.jpg)

 A list of the project deliverables that will be submitted on project completion
================================================================================
A fully functioning web application that works seamlessly
A technical report describing the application and how it works.
This report should include the following:
*	Project Plan
*	Background research and investigations.
*	Software development methodology employed 
*	Requirements analysis 
*	Use cases 
*	Architecture/Design approach 
*	Models (Class Models / Data Models etc.) 
*	Implementation of particular OOP constructs 
*	Design patterns and architectural patterns implemented in the application 
*	How cross-cutting concerns have been handled 
*	Security of the application 
*	Configuration of the application 
*	Scalability of the application 
*	Testing Approach (in terms of both functional and non-functional requirements) 

A  project log document signed by all members of the group which records
*	all actions and tasks carried out 
*	who carried out these actions and tasks 
*	when actions and tasks were carried out 
*	the time spent on the actions and tasks 

Demonstrate that the project has the traits and qualities of an enterprise application. 

Provide a presentation of the project and demonstrate the developed application.


Main Report
===========

1. Data Access Layer
====================

Microsoft SQL Server did not like foreign key relationships that may cause cycles or multiple cascade paths. [*Stackoverflow*](http://stackoverflow.com/questions/851625/foreign-key-constraint-may-cause-cycles-or-multiple-cascade-paths)
[*MSDN*](http://msdn.microsoft.com/en-us/library/ms186973%28v=sql.105%29.aspx)
As an example we had tables Bookings, Cars both linking to Supplier by FK SupplierId.
Ideally both models should contain a reference to the supplier without a problem but SQL Server played it ultra conservative and complained about multiple cascade paths.
Cascades are rules to carry out if a user deltes a key to which foreign keys point (e.g. ON DELETE of an entity). The issue happens if there is a triangular relationship between Booking to Supplier to Car and back to Booking. What we found was the relationship must not cycle like this.
The solution is to create clear cascade rules for ONDELETE or to remove the offending foreign relationship. For the moment, the simple solution was to remove the link between supplier and booking (not ideal).

## Use Cases

Use Case 1:  User logs on
*	User asked to input pickup location
*	The user is presented with a drop down box of a list of locations
*	The user chooses the location that they require to pick up the car
*	User fills out the following  details:
  *	Pick up date & time
  *	Drop off date & time
  *	Car Class	
  *	Email address (optional)
*	User Enters Submit Button
*	The user is given a report of the number of cars that are available


Use Case 2a: A list of cars available is given from the cheapest to the dearest 
*	The cars are listed from the cheapest to the dearest.
*	The cars are described by the Make, Model and the Number of passengers it can hold & the luggage space.

Use Case 2b: User selects car they want to hire
*	The user then selects the car that they want to hire by Select Button
*	The user is then given a screen with the details of the car, the location, the pickup and drop off times and the total rental cost.
*	The user is asked to confirm by clicking a Button called Confirm
*	The user is then re directed to a new page to register their details and confirm the booking

Use Case 3: User Completes a form giving their Details and are Requested to enter their Payment Details
*	The customer is requested to fill in a form giving their first name, last name, age, email address
*	They are then requested to fill in their payment details. Their credit card or debit card.
*	The user is then required to press a button to confirm the booking
*	A page is returned confirming the booking
*	An order confirming the booking is also sent to the car supplier by email
		

Use Case 4: Car Suppliers Log in & Report
*	Supplier enters login button
*	Supplier enters id and password
*	The supplier is then returned a page with supplier details. Giving their name address and the number of current cars on the database
*	 This supplier will include an option to list from the cars available from that supplier & the dates & times the cars are hired from
*	The supplier then selects the required options it wants from the report, either a full list of cars or just a list of the confirmed bookings.
*	The supplier is then returned a list showing the Registration of the Car, The Car description (name, make, model & colour) & current bookings in the car.
*	The supplier also has option to amend car listing.


Use Case 5: Supplier amends car details by either entering a new csv file of amending an individual car record.
*	From car suppliers page while logged in the supplier is given the option to amend the car listing by clicking in a button.
*	The supplier is then presented with a drop down listing with options to either
	*	Remove a car either temporarily or permanently
	*	Replace a car with a different car
	*	Add a new car
	*	Replace the full list of cars with a new list by updating with a new csv file.
*	If the supplier decides to remove the car either temporarily or permanently they can change the status of the car to not available or change the status to available
*	If a new additional car becomes available the supplier can add a record for that by entering the Reg of the car, the name, make model & colour. 
*	If the supplier chooses to update the car list with a new list he then selects CSV from the Export As drop-down field
*	The user then selects the Generate Report button
*	The is re-directed to a new page which displays the generated CSV file

## Testing

Test was performed for ensure system was working fine and producing the desired results. 
For instance, it was required that a test for Booking for the Business Logic should do the following:

	*	Booking must be in future,
	*	Booking end date must be after before date
	*	Booking must have car_id, customer_id
	*	Replace a car with a different car
	*	Booking should calculate total cost (daily rate * number of days)
	*	Booking should calculate total cost (daily rate, number of days)
	
