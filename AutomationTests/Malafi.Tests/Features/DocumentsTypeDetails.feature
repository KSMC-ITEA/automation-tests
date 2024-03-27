Feature: Documents Type Details

Enter data into the form and submit


Background: Common steps till reach to Add Document Type page
	Given Entered 'blue2'as a username
	And Enterd 'Ksmc@1234' as password
	When I cilck on login button
	And Click on Malafi link
	And Clicked DocumentsTypes link
	And Click on Add Document Type button



Scenario: Add new document type should succeed
	Given I completed the form New Document Type
		| Title AR | Title EN | Website Link | OnBase Number | upload File |
		| تجربة    | Test     | x            | 1111          | ladybug.png |

	When I click on save button
	Then A successful notification message should be appeared




Scenario: Checks the file type(PDF,JPG,PNG,BMP)
	Given I completed the form New Document Type
		| Title AR | Title EN | Website Link | OnBase Number | upload File       |
		| تجربة    | Test     | x            | 1111          | NotSupported.xlsx |

	When I click on save button
	Then An error message notification message should be appeared




	Scenario: Checks the file size(bigger-10MB) 

	Given I completed the form New Document Type
		| Title AR | Title EN | Website Link | OnBase Number | upload File       |
		| تجربة    | Test     | x            | 1111          | bigger-10MB.pdf   |

	When I click on save button
Then An error message notification message should be appeared


	
	Scenario: Checks the file size(1-10MB) 

	Given I completed the form New Document Type
		| Title AR | Title EN | Website Link | OnBase Number | upload File       |
		| تجربة    | Test     | x            | 1111          | 1-10MB.pdf        |

	When I click on save button
	Then A successful notification message should be appeared





	
Scenario Outline: Language from validation
	Given I completed the form New Document Type
		| Title AR | Title EN | Website Link | OnBase Number | upload File |
		| تجربة    | Test     | x            | 1111          | ladybug.png |

	When I enter '<text>' in '<field>'
	And I click on save button
	Then An error message notification message should be appeared
Examples:
	| field    | text    |
	| Title Ar | test50  |
	| Title En | تجربه50 |




	