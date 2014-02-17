Feature: Data Displayed on Page

@mytag
Scenario: Display two clients
	Given That I have two clients defined
	When I load the page
	Then two clients should be displayed on the screen

Scenario: Two Clients Each Have a Name
	Given That I have two clients defined
	When I load the page
	Then the two clients should each have a name