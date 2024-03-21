Feature: Display Rejected Document

A short summary of the feature
Background: Login to Internal Portal and click on Malafi Link
	Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link
	When Clicked Registered Employees link

Scenario: View Document Approval LVI History
	When I click on Approved
	 When I click on view documents 
	 When I click any file
	 When Click on view documents 
	When I click on view Approved timeline
	Then I shoed see View Document Approval LVI History 


	Scenario: Check Display Approved/Pending/Rejected
		When Clicked Registered Employees link



