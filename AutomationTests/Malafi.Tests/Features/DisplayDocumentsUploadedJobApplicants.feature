Feature: Display the Documents Uploaded by Job Applicants

Background: Login to Internal Portal and click on Malafi Link
	Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link
	When Clicked Registered Employees link


Scenario: View Document Approval LVI History
	Given I click on Approved
	And I click on view documents
	And I click on DownloadPreviouslyUploadedFile