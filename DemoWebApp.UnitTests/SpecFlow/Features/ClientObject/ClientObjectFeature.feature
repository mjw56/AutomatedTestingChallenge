Feature: ClientObjectFeature
	I want to verify that the 
	client object contains the
	necessary fields I construct
	it with

@mytag
Scenario: Create Client Object
	Given I have a client constructor with params
	When I call the constructor
	Then it should return a new Client object
