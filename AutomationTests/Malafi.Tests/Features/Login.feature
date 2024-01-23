Feature: Login Feature

Login scenarios for the malfi project 

@loginTest
Scenario: Login using valid username and password should be succeeded


	Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	Then I should be able to view my home page 



Scenario: Login using unvalid username or  unvalid password should be  not succeeded
	Given Entered 'blue'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	Then I should not be able to view my home page

Scenario: click on forget my password should move me to SelfServices 
	Given click forget password putton.
	Then  I should move to selfservices page.

	
Scenario: click on selfservices should move me to SelfServices 
	Given click selfservices putton.
	Then  I should move to selfservices page.