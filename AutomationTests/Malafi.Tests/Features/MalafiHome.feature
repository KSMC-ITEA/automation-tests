Feature: MalafiHome

Move to a page DocumentsTypes

Background: Login to Internal Portal and click on Malafi Link
Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link

@tag1
Scenario: Click on Document Types link
	When Clicked DocumentsTypes link
	Then I should be navigated to Document Types Page



Scenario:Click on Document Group link
	When Clicked Documents Group link
	Then I should be navigated to Documents Group Page


Scenario:Click on Registered Employees link
  When Clickd Registered Employee link
  Then I should be navigated to the Registered employees page
