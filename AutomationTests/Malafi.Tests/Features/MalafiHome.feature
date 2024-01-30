Feature: MalafiHome

A short summary of the feature

Background: Login to Internal Portal and click on Malafi Link
	Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link

@tag1
Scenario: Click on Document Types link
	When I clicked DocumentsTypes link
	Then I should be navigated to Document Types Page


@tag1
Scenario: Employee Registration Form
	When click on Request a Registration link
	Then I should be navigated to Employee Registration Form
