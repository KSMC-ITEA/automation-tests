Feature: EmployeesSearch

A short summary of the feature
Background: Common steps till reach to Add Document Type page
	Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link

Scenario: Click on Excel  button
	When I click on  Excel  button
	Then the excel file should be downloaded
