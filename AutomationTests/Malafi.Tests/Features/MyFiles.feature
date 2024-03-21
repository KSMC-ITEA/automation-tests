Feature: MyFiles

Background: Login to Internal Portal and click on Malafi Link
	Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link
	When Clicked My files link

Scenario: Upload Document successfully
	 When I click any file My files
	 When Click on view documents  My files
	 And I upload File 
		| upload File |
		| ladybug.png |
	
	Then cilck on Save button