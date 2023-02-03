Feature: BookingSearch

This Feature details the way to search a property and then search the results on 4 and 5 star ratings 

@SearchBooking
Scenario Outline: Search Booking 
	Given I am on Booking site 
	When I enter destination <Location>
	And I enter the desired dates
	And I select 2 adults , 1 childern of Age 7
	Then I click on to the search button 
	And I am on Booking Site results page
	When Results on Left Side is in match with Search
	And I click on 5 Star Rating
	And I change the language to Arabic
	And I wait for the page to load
	And I verify that total results are above 100 and below 300
	And I add more selection if results are below 100 
	And I reduce selection if results are above 300
	Then the sum of properties matches the total result
	Examples: 
	|Location|
	|London	|

