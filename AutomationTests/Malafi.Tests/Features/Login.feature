Feature: Login feature

login scenarios for the malfi project 

@tag1
Scenario: Login using valid username and password should be successeded

	Given I have naveigated to the research login page
	And Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilci on login button
	Then I should be able to view my home page 
