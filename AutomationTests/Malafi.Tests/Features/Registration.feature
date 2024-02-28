Feature: Registration

Test Registration request

Background: Common steps till reach to registration page
	Given Entered 'wamda' as a username
	And Enterd 'Ksmc@102030' as password
	When I cilck on login button
	And Click on Malafi link
	And click on Request a Registration link

Scenario: Fill the Registration Form
Given Entered the following informaion
		| Email                 | Mobile     | Job Number | Nationality | JobTitle | OrganizationalLevelEn | OrganizationalLevelEn2 | JobGroup | ContractType | RequestStatus |
		| mo.elsaid@ksmc.med.sa | 0548526612 | -012345    | China       | Casher   | Administration        | Infection Control      | Nursing  | MOH          | Pending       |
	And I filled in all the required feilds
	When Clicked on submit button
	Then I should See the succuessfully registration message



#Scenario: Filling wrong mobile
#Given I enter wrong mobile 
#When Clicked on submit button
#Then I should See the Error message


Scenario Outline: Filling wrong data
	Given Entered the following informaion
	| Email | Mobile     | Job Number | Nationality | JobTitle | OrganizationalLevelEn | OrganizationalLevelEn2 | JobGroup      | ContractType | RequestStatus |
	|       | 3548526612 | -012345    | China       | Casher   | Administration        | Infection Control      | Nursing       |  MOH         | Pending       |
		
	And I filled in all the required feilds
	When Changed the '<Field>' with the '<Data>'
	And Clicked on submit button
	Then The '<Field>' validation should have the '<Error Message>'
Examples:
	| Field                  | Data              | Error Message                                                         |
	| Email                  | abc               | Please add a valid Eamil                                              |
	| Mobile                 |                   | Please add a valid phone number: Number should start with 05 or +9665 |
	| Job Number             | -012345           | Please add a valid Number                                             |
	| Nationality            | China             | ------                                                                |
	| JobTitle               | Casher            | ------                                                                |
	| OrganizationalLevelEn  | Administration    | ------                                                                |
	| OrganizationalLevelEn2 | Infection Control | ------                                                                |
	| JobGroup               | Nursing           | ------                                                                |
	| ContractType           | MOH               | ------                                                                |
	| RequestStatus          | Pending           | ------                                                                |




	




