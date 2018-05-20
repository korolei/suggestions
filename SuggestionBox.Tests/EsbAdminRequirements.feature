@AdminScenarious
Feature: ESB Admin User Scenarios
	In order to reply to posted suggestions
	As Admin User on the site
	I want to be able submit reply to each posted suggestion

Scenario: See all suggestions and replies
	Given I can access the ESB app in my browser
	When I load the page
	Then I can see all posted suggestions
	And all suggestions sorted by date in descending order

@AdminActions
Scenario: Open a reply screen
	Given I can see 'Reply' button
	When suggestion does not have a reply text
	Then I can click on 'Reply' button
	And textbox with two buttons 'Submit' and 'Cancel' will be shown

@AdminActions
Scenario: Create a reply
	Given I can see Reply form with text box and two buttons 'Submit' and 'Cancel'
	When I entered minimum 20 and maximum 2000 characters
	Then 'Submit' button gets enabled

@AdminActions
Scenario: Submit a reply
	Given 'Submit' button is enabled
	When I click on 'Submit' button
	Then my reply will be saved and shown on the screen
	And user's suggestion and my reply becomes visible to all users

@AdminActions	
Scenario: Cancel submit a reply
	Given I can see reply form with two buttons 'Submit' and 'Cancel'
	When Clicked on 'Cancel' button
	Then reply form will not be shown on the screen
	And user's suggestion will not be visible to all users
