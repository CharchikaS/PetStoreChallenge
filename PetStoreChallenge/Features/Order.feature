Feature: Order

This feature covers the Order related scenarios for the users of the Pet Store

@tag1
Scenario: Place an order
	Given I register as a new User on Pet Store
	And I login successfully
	When I place an order for a pet
	Then the order should be placed successfully

#Scenario: Successful new order placement by Admin
#	Given I an Admin User on Pet Store
#	And I login successfully
#	When I place an order for a pet
#	Then the order should be placed successfully

#Scenario: Restriced access to get store inventory by non-Admin user
	#Given I am a registered user on Pet Store
	#And I login successfully
#	When I send the get inventory request
#	Then I should receive restricted access error
#
#Scenario: Successful get store inventory by Admin user
	#Given I an Admin User on Pet Store
	#And I login successfully
#	When I send the get inventory request
#	Then I should get inventory details
#
#Scenario: Successful find an order by Admin user with valid order id
	#Given I an Admin User on Pet Store
	#And I login successfully
#	When I send the get order request with valid orderid
#	Then I should get all the details of this order
#
#Scenario: UnSuccessful find an order by Admin user with invalid order id
	#Given I an Admin User on Pet Store
	#And I login successfully
#	When I send the get order request with an invalid orderid
#	Then I should get all the details of this order
#	
#Scenario: Restriced access to find an order by non-Admin user
	#Given I am a registered user on Pet Store
	#And I login successfully
#	When I send the get order request with valid orderid
#	Then I should receive restricted access error
#	
#Scenario: Successful deletion an order by Admin user
	#Given I an Admin User on Pet Store
	#And I login successfully
#	When I send the delete order request with valid orderid
#	Then I should get all the details of this order
#	
#Scenario: Restriced access to delete an order by non-Admin user
	#Given I am a registered user on Pet Store
	#And I login successfully
#	When I send the delete order request with valid orderid
#	Then I should receive restricted access error

