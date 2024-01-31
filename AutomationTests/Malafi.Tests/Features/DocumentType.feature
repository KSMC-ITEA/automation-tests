Feature: DocumentType

This feature file has all the scenarios related to the document type page(s)


Background: Common steps till reach to Document Types listing page
	Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link
	And Clicked DocumentsTypes link

Scenario: Click on Add Document Type button
	When I click on Add Document Type button
	Then I should be navigated to Add Document Types Page



Scenario: Click on View approval levels button
	When I click on View approval levels button
	And I click on AddApprovalLevelClick button
	Then I should be navigated toIDApproval level List Page
