Feature: BookingSearch

This Feature details the way to search a property and then search the results on 4 and 5 star ratings 

@SearchBooking
Scenario Outline: Search Booking 
	Given I am on Booking site 
	When I click on search location and enter location
	And I enter the desired dates
	And I select 2 adults , 1 childern of Age 7
	Then I click on to the search button 
	And I am on Booking Site results page
	When Results on Left Side is in match with Search
	And I click on <Rating> star properties and budget
			| Rating |
			| 4      | 
			| 5      | 

	Then the sum of properties matches the total result


