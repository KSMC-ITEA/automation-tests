Feature: Display Required Documents Types Grouped by the Document Group us 1625


Background: Login to Internal Portal and click on Malafi Link
	Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link
	When Clicked My files link

Scenario: Display Required Documents Types Grouped by the Document Group
	 When I click any file My files
	 Then Check Display file