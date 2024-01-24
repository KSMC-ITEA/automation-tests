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
		| تجربة    | Test     | x            | www            | ladybug.png  |

	When I click on save button
	Then A successful notification message should be appeared



	
@tag1
Scenario: 	Scenarios: Checks the file type(PDF,JPG,PNG,BMP,TIFF) and size (10MB)

		Given I completed the form New Document Type
		| Title AR | Title EN | Website Link | OnBase Number1 | upload File1 |
		| تجربة    | Test     | x            | www            | test1.xlsx  |

	When I click on save button
	Then A ErrorMessage notification message should be appeared









	
Scenario Outline: Language from validation
Given I completed the form New Document Type
		| Title AR | Title EN | Website Link | OnBase Number1 | upload File1 |
		| تجربة    | Test     | x            | www            | ladybug.png  |

	When I enter '<text>' in '<field>'
	And I click on save button
	Then A successful notification message should be appeared
Examples:
	| field      | text    |
	| Title Ar   | تجربه50 |
	| Title En   | test50  |




	