Feature: Registration

Test Registration request

Background: Common steps till reach to registration page
	Given Entered 'apple'as a username
	And Enterd 'Ksmc@102030' as password
	When I cilck on login button
	And Click on Malafi link
	And click on Request a Registration link


Scenario: Fill the Registration Form
	Given I filled in all the required feilds
	When Clicked on submit button
	Then I should See the succuessfully registration message






