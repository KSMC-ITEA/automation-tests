Feature: Display Rejected Document(

A short summary of the feature
Background: Login to Internal Portal and click on Malafi Link
	Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link
	When Clicked Registered Employees link

@tag1
Scenario: View Document Approval LVI History
	Given I click on Approved
	 And I click on view documents 
	 And I click any file
	 And Click on view documents 
	When I click on view Approved timeline
	Then I shoed see View Document Approval LVI History 
