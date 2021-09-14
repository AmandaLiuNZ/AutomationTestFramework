Feature: BillingOrder


@mytag
Scenario: Sbumit billing order form
	Given I am on billing order page
	And enter user details
	When click submit button
	Then user details should be submitted

	 