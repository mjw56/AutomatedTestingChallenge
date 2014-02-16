Feature: Displaying Clients

@mytag
Scenario: Display two clients
	Given That I have two clients defined
	When I load the page
	Then two clients should be displayed on the screen