Feature: NewDocTypeApprovalLVI

Enter data into the form and submit

Background: Common steps till reach to Document Types listing page
Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link
	And Clicked DocumentsTypes link
	When I click on View approval levels button 
	And I click on AddApprovalLevelClick button
@tag1
Scenario: Add new document LVI should succeed
	Given I completed the form New Document LVI
	When I click save button
  Then A Successful Notification Message Should Be Appeared

  Scenario: DocTypeApproval LVI Validation
  When I click save button
  Then A ErrorMessage Notification Message Should Be Appeared

