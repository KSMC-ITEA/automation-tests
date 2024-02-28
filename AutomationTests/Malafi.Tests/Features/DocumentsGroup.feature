
Feature: DocumentsGroup

This feature file has all the scenarios related to the document Group page(s)


Background: Common steps till reach to Documents group listing page
Given Entered 'blue2' as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link
	And Clicked Documents Group link


Scenario: Click on Add Document group button then go to add document group page
	When I click on Add Document group button 
	Then I should be navigated to Add Documents group Page


Scenario: Checking elemnts in DisplayGrouppage
	Given QualificationGroupsList page was opened
	Then I should find Tilte named 'Documents Group List'
	And I should find Button named '+ Add documents Group'

Scenario: Checking Serach Engine
   Given QualificationGroupsList page was opened
   And I should find Search engine 

Scenario: Checking sorting column in the table
	When I should find the table 
	And I clcick on the header of the first column
	Then I should see the elements sorted 
	

	