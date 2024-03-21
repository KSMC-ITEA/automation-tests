Feature: Home Page

 Internal Portal Home Page Scenarios


Background: Login to Internal Portal and click on Malafi Link
Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link


@tag1
Scenario: Click on Malafi link
	Then I should be navigated to Malafi Home Page


