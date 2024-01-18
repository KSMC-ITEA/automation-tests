Feature: Login Feature

login scenarios for the malfi project 

@tag1
Scenario: Login using valid username and password should be succeeded


	Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	Then I should be able to view my home page 
