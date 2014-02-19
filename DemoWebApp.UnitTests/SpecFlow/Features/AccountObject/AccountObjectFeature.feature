Feature: AccountObjectFeature
	I want to verify that the 
	account object contains the
	necessary fields I construct
	it with

@mytag
Scenario: Create Account Object
	Given I have Account constructor with params
	When I call the Account constructor
	Then it should return a new Account object