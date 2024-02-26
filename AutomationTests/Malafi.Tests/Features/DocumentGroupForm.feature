Feature: Add Documents group
Background: Common steps till reach to Add Document group
	Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link
	And Clicked Documents Group link
	And I click on Add Document group button
	



Scenario: Add new document group should succeed
	Given I completed the form New Document Group
		| Title AR      | Title EN     |
		| 1فاطمة اختبار | TestFatimah1 |

	When I click on  add document group save button
	Then A successful message should be appeared

	
Scenario: Add new document group should fill if the data is doublicated.
	Given I completed the form New Document Group
		| Title AR | Title EN |
		| اختبار   | Test     |

	When I click on  add document group save button
	Then A fill message should be appeared



Scenario Outline: Language from validation
	Given I completed the form New Document Group
		| Title AR | Title EN |
		| اختبار   | test     |

	And I enter '<text>' in '<field>'
	When I click on  add document group save button
	Then A ErrorMessage notification message should be appeare
Examples:
	| field    | text      |
	| Title Ar | testtt    |
	| Title En | اختبارررر |