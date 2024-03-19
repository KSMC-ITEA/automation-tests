Feature: Registered Employees


Background: Common steps till reach to Documents group listing page
	Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link
	And Clickd Registered Employee link

Scenario Outline: find the registered employee by select status
	When I Click on '<Status>' link
	And I click click on review button
	Then I should see  the  selected Status in  '<StatusText>'

 
Examples:
	| Status   | StatusText |
	| Pending  | Pending    |
	| Approved | Approved   |
	| Rejected | Rejected   |

Scenario: assign  document group to the employee

 When I Click on 'Approved' link
 And I click on add icon for any employee
 Given I prepare the Document data
 When I click on add to add the document grope to the employee
 Then I should find the selectd document group moved to employee document group 

 Scenario: Clicked on search button should filter the data in the grid 
 Given I write data on the search filed'11' 
 And I click on Approved status
 When I prepare the employee data
 Then  data in the grid should be filterd with row contain the search key '11' 
