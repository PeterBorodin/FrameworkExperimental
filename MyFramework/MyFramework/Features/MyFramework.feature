Feature: MyFramework
	Working with Lead Source page

Background: Loging In and going to the Lead Source page
    Given User Loginned and he is on Lead Source page



@Adding
Scenario: 1.Perform Adding new Lead Source to Project Plan site
	When user click on Add Lead Source Button
	And user enter the Name of Lead Source
	And user click the Note field
	And user enter the note of Lead Source
	And user click the Save button
	Then user see Successfully Added message

@Sorting
Scenario: 2.Perform Sorting on Lead Source Page
	When user click on created on button
	Then user see last edited Lead Source on top

@EditingName
Scenario: 3.Perform Editing Lead Source Name on Project Plan site
	When user doing search on Lead Source Page
	And user click on edit button
	And user assign a new name for Lead Source
	And user click Save button
	Then user see Successfully updated message

@EditingNote
Scenario: 4.Perform Editing Lead Source Note on Project Plan site
	When user doing search on Lead Source Page
	And user click on edit button
	And user assign a new note for Lead Source
	Then user see new note on Lead Source
	And user click Save button

@Deleting
Scenario: 5.Perform Deleting Lead Source on Project Plan site
	When user doing search on Lead Source Page
	And user click on delete button
	And usesr click Yes on confirmation button
	Then user see Successfully deleted message

