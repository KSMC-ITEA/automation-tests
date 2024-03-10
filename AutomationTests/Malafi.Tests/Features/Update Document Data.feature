Feature: Update Document Data


Background: Common steps till reach to Add Document Type page
	Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link
	When Click on inbox link

Scenario: Update Document Data

	When Click on Edit
	Then The new information must be saved



	
Scenario: Check Display the Documents for Each Request
	Then Check Display the Documents for Each Request


