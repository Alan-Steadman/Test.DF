# Test.DF

Test excercise for an undisclosed client.  Implemented as a Blazor Web App on .NET 8 rendering as Blazor Server.

# Dev setup

This application works with Visual Studio 2022.
There are no setup requirements, (no user secrets, no startup or installation scripts).
The project will run simply by pressing F5.


# Requirements

- [x] ask user to enter full name, dob
- [x] redirect the user to another page on submission
- [x] display welcome message with users first name only
- [x] display message showing how many vowels are in the name
- [x] display message showing how old the user is and how many days before next birthday
- [x] show table which displays 14 days before run up to next birthday (days of week (mon, tue, wed etc..) and allow the dates to be clickable, which redirect the user to the following �https://www.historynet.com/today-in-history/june-10� with selected date


# TODO

- [x] Remove scaffolded items
- [x] Client side validation when creating a person


# Given More Time

This is not an exhastive list, these are just reminders of assorted items.
In addition to the items on the list, layering the application into clean architecture layers is a large potential item.

- TDD / Unit Tests
- Create and utlise a service result + define errors for all anticipated errors
- Inject services such as
  - DateTime
  - vowel count
- Introduce Stylecop or similar
- Pull requests from the start
- Create constants for page routes

- Split out the DTOs into their own files
- I should have retrieved the <Person?> from application state and rendered in the entry form when a user visits/returns to the Home page
- A better name for the Infrastructure folder would have been ClientInfrastructure, also the DataAnnotations folder doesn't belong there.
- The list of dates in the PersonView.razor could be split out into its own sub-component.
- PersonView.razor is implemented as a page, whereas it could be cleaner to implement it as a component and always have pages orchestrating components.
