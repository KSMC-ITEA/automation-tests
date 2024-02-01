Feature: RegisteredEmployeesReview

A short summary of the feature
Background: Common steps till reach to Add Document Type page
	Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link

Scenario: Click on Review  button
	When I click on  Review  button
	Then I should be navigated to  Review  Page

Scenario: Form Registered Employees Validation
	When I click on  Review  button
	And I click on  Employee Name Changing the name
	And I click on Save Changes
	Then It is supposed to be for readers only
   

