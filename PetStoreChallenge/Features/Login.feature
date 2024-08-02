Feature: Login

This feature covers the Login scenarios for the users of the Pet Store

@tag1
Scenario: Successful Login
	Given I am a registered user of Pet Store
	When I enter username <Username>
	And password <Password>
	And I send the Login request
	Then I should be logged in successfully
	Examples: 
	    | Username | Password      |
	    | CSP      | Ch@llenge2024 |

#Scenario: UnSuccessful Login
#	Given I am an unregistered user of Pet Store
#	When I enter random username
#	And random password <Password>
#	And I send the Login request
#	Then login should be unsuccessful

#Scenario: Restrict Anonymous Access to store inventory
#	Given I am an anonymous user of Pet Store
#	When I request to get store inventory
#	Then I should receive an access denied message
#
#Scenario: Restrict Anonymous Access to add a pet
#	Given I am an anonymous user of Pet Store
#	When I try to add a pet to the Pet Store
#	Then I should receive an access denied message
#
#Scenario: Restrict Anonymous Access to order a pet
#	Given I am an anonymous user of Pet Store
#	When I try to order a pet from the Pet Store
#	Then I should receive an access denied message