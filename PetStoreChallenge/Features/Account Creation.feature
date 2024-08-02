Feature: Account Creation

This feature covers the new users accounts creation scenarios for users of the Pet Store

@tag1
Scenario: Successful New User Account creation
	Given I am a new user
	When I request creation of a new account with username <Username>
	And with firstname <Firstname> and lastname <Lastname>
	And with email id <EmailId>
	And with password <Password>
	And with phone number <Phone>
	And I send the User Creation request
	Then this new user account should be created successfully
	Examples: 
	    | Username | Firstname | Lastname | EmailId       | Password      | Phone      |
	    | CSP1     | Charchika | Shukla   | csp@gmail.com | Ch@llenge2024 | 0412366875 |
	    | User11   | Charchika | Shukla   | csp@gmail.com | Ch@llenge2024 | 0412366875 |
	    | User21   | Charchika | Shukla   | csp@gmail.com | Ch@llenge2024 | 0412366875 |
	    | User31   | Charchika | Shukla   | csp@gmail.com | Ch@llenge2024 | 0412366875 |

Scenario: New Users User Account Creation in bulk using List
	Given I am an admin user of Pet Store
	When I request creation of new users
	And I send the bulk User Creation request List
	Then these new users accounts should be created successfully

Scenario: New Users Account Creation in bulk using an Array
	Given I am an admin user of Pet Store
	When I request creation of new users
	And I send the bulk User Creation request Array
	Then these new users accounts should be created successfully

#Scenario: Error User Account creation
#	Given I am a new User
#	When I send a request to create an account with invalid details
#   Then the request should fail
#   And I should receive a an error

