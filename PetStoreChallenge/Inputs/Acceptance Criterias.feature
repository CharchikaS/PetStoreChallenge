@ignore
Feature: Acceptance Criterias

This feature file contains the feature wise Acceptance Criterias for the given requirements for Pet Store

#Feature - User_Account_Management
Scenario: Create User Account
	Given I am a new User of Pet Store
	When I request to create an account with valid details
    Then the account should be created successfully
    And I should receive a confirmation

Scenario: Create User Accounts in Bulk
	Given I am an Admin user of Pet Store
	And I login successfully with my credentials
	When I send a request to create new users accounts with valid details in bulk 
    Then the accounts should be created successfully
    And I should receive a confirmation
	And the users of these new accounts should be able to login successfully with their provided credentials

#Feature - Login
Scenario: Login to User Account
	Given I am a registered user of Pet Store
	When I request to login with my valid credentials	
    Then I should be logged in successfully

Scenario: Restrict Anonymous Access
	Given I am an anonymous user of Pet Store
	When I try to access a resource that needs user authentication
	Then I should receive an access denied message

#Feature - User Actions
Scenario: CRUD operations on User Accounts by Admin
	Given I am an Admin user of Pet Store
	And I login successfully with my credentials
	When I request to get or update or delete a user account with its relevant username
	Then I should be able to do so successfully

#Feature - Orders
Scenario: Get Store inventory by Admin
	Given I am an Admin user of Pet Store
	And I login successfully with my credentials
	When I request store inventory details
	Then I should receive the details successfully

Scenario: Find or delete an order 
	Given I am an Admin user of Pet Store
	And I login successfully with my credentials
	When I request to find or delete an order with its relevant orderId
	Then I should be able to do so successfully

Scenario: create new order 
	Given I am a registered or Admin user of Pet Store
	And I login successfully with my credentials
	When I request to create a new order with valid details
	Then I should be able to do so successfully

#Feature - Pets
Scenario: Add new Pets
	Given I am a registered or Admin user of Pet Store
	When I request to add a new pet with valid details
	Then I should be able to do so successfully

Scenario: CRUD operations on Pets
	Given I am a registered or Admin user of Pet Store
	When I request to get or update or delete a pet record with its relevant petid
	Then I should be able to do so successfully

Scenario: Upload image to a pet record
	Given I am a registered or Admin user of Pet Store
	When I request to upload an image to a pet record with its relevant petid
	Then I should be able to do so successfully

Scenario: Find list of pets having same status
	Given I am a registered or Admin user of Pet Store
	When I request to get a list of pets that have a particular status
	Then I should be able to do so successfully
