Feature: DocumentsTypeDetails

A short summary of the feature
Background: Login to Internal Portal and click on Malafi Link
Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link
	And I clicked DocumentsTypes link
	Given I click on Add Document Type button 


@tag1
Scenario: completed the form New Document Type 
	Given I completed the form New Document Type 
	| Title AR | Title EN | Website Link | OnBase Number1 | upload File1 |
	| تجربة    | Test     |        x     |       12234    |   ladybug.png      |
	When I click on save button 
	Then A successful notification message should be appeared
