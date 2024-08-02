Feature: User Actions

This feature covers the User action scenarios for the users of the Pet Store
Background: 
	Given I am an admin user of Pet Store	

@tag1
Scenario: Get user details
	When I send the get request
	Then I should get all the details of this user

Scenario: Update user details
	When I enter updated <EmailId>
	And I send the update request
	Then update of email should be successful
	Examples: 
		| EmailId       |
		| wow@gmail.com |

Scenario: Delete user
	When I send the delete request
	Then this user should be deleted successfully

#Scenario: Get user details with incorrect username
#	When I send the get request with non existent username
#	Then I should receive a user not found error
#
#Scenario: 
#	Given I am a registered user of Pet Store
#	When I send the get request with valid username
#	Then I should receive restricted access error 