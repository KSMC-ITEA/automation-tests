Feature: Login

A short summary of the feature

Scenario: Login using valid username and password should be succeeded
	Given Entered 'Dev_MOH'as a username
	And Enterd 'Dd@112233' as password
	When I cilck on login button
	Then I should be able to view my home page


	Scenario: Username and Password Validation(This field is required)
	Given Entered ''as a username
	And Enterd '' as password
	When I cilck on login button
	Then I should be message This field is required


	Scenario:Login an unauthorized user(Sorry, but you don’t have an access permission)
	Given Entered 'Dev_MOH'as a username
	And Enterd 'Dd@112233' as password
	When I cilck on login button
	Then I should be message Sorry, but you don’t have an access permission


   Scenario:Login without an account MOH(Login authentication failed, check your username or password.)
	Given Entered 'KSMC@Ksmc.med.sa'as a username
	And Enterd 'Dd@112233' as password
	When I cilck on login button
	Then I should be message Login authentication failed, check your username or password.


	Scenario: Forgot your password
	Given Click on Forgot your password link
	Then I should be navigated to the moh.gov.sa
