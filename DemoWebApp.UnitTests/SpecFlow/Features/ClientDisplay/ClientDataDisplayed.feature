Feature: Client Data Displayed

@mytag
Scenario: Display two clients
	Given That I have two clients defined
	When I load the page
	Then two clients should have names, addresses, and accounts
