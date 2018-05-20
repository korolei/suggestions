@UserScenarious
Feature: ESB Regular User Scenarios
	In order to use Electronic Suggestion Box application
	As a regular user
	I want to see all suggestions and replies
	And I want submit my suggestions anonymously

Scenario: See all suggestions and replies
	Given I can access the ESB app in my browser
	When I load the page
	Then I can see all posted and answered suggestions
	And all suggestions sorted by date in descending order

Scenario: Open a suggestion post screen
	Given I can see 'Add Suggestion' button on the ESB page
	When I click 'Add Suggestion' button
	Then text box with two buttons 'Post It' and 'Cancel' will be shown

Scenario: Submitting a suggestion post
	Given I entered minimum 20 and maximum 2000 characters in the text box
	Then 'Submit' button get enabled
	And I can submit my suggestion
	Then confirmation message will be shown
	But my suggestion will not be visible
	Then Admin Group will receive email notification

Scenario: Cancelling a suggestion post
	Given I can see text box and two buttons 'Post It' and 'Cancel'
	When I click on 'Cancel' button
	Then text box and two buttons will disappear
