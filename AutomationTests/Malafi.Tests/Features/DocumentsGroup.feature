
Feature: DocumentsGroup

This feature file has all the scenarios related to the document Group page(s)


Background: Common steps till reach to Documents group listing page
Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link
	And Clicked Documents Group link

@tag1
Scenario: Click on Add Document group button then go to add document group page
	When I click on Add Document group button 
	Then I should be navigated to Add Documents group Page