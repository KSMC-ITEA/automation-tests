Feature: Reject the Documents and Add Rejection Reason

Background: Common steps till reach to Add Document Type page
	Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link
	When Click on inbox link

Scenario: [scenario name]
	When Click on  Reject the Documents
	Then Add Rejection Reason
