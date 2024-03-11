Feature: Approve Documents

Background: Common steps till reach to Add Document Type page
	Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link

Scenario: Approve Documents
	When Click on inbox link
	Then I have been navigated to the approved inbox


