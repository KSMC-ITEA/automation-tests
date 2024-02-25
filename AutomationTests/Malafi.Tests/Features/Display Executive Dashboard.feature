Feature: Display Executive Dashboard

A short summary of the feature
Background: Common steps till reach to Add Document Type page
	Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link
 
 


	Scenario: Check Executive Dashboard
	Given I click on Dashboard
	Then Check Display Dashboard 