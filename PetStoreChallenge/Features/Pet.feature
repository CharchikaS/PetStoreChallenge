Feature: Pet

This feature covers the Pets related scenarios for the users of the Pet Store
Background: 
	Given I create the details of a new Pet
	When I send pet creation request
	Then a new pet entry should be created successfully

@tag1
Scenario: Add new Pet to the Pet store

Scenario: Upload pet image
	When I send the request to upload image of this pet
	Then the image should be uploaded successfully

Scenario: Find Pets by status
	When I send the request to find pets by status
	Then I should get all the pets who have this status

#Scenario: Find/Update/Delete Pet details successfully with valid petid
#	Given I am a registered or Admin user of Pet Store
#	When I request to get a pet record with its valid petid
#	Then I should get all the details of this pet
#
#Scenario: Unsuccessful Find/Update/Delete Pet request with invalid petid
#	Given I am a registered or Admin user of Pet Store
#	When I request to get a pet record with an invalid petid
#	Then I should get an error message


