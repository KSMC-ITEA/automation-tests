Feature: MalafiHome

Move to a page DocumentsTypes

Background: Login to Internal Portal and click on Malafi Link
Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link

Scenario: Click on Document Types link
	When Clicked DocumentsTypes link
	Then I should be navigated to Document Types Page


	Scenario: Open Page Registered Employees 
		When Clicked Registered Employees link
		Then I should be navigated to Registered Employees Page

