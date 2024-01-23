Feature: DocumentType

A short summary of the feature


Background: Login to Internal Portal and click on Malafi Link
Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link
	And I clicked DocumentsTypes link

@tag1
Scenario: Click on Add Document Type button 

	Given I click on Add Document Type button 


