Feature: DisplayDocumentTypes

A short summary of the feature
Background: Common steps till reach to Add Document Type page
	Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link
	And Clicked DocumentsTypes link




Scenario: Check title

	Then I should see Title in the top left corner


Scenario: Check search box and add document type button.

	Then I should see search box and add document type button in the top right corner


Scenario: Check Action button

	Then I should see for buttons Edit Delete Add it to Documents Group View approval levels

Scenario: Check sortable-icon.
	Given Click on sortable-icon
	Then I should see in table sortable-icon


Scenario: Check table
	Given Click on sortable-icon
	Then Verify that the table is validly sortable