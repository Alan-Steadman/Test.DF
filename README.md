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

- [ ] Remove scaffolded items
- [ ] Client side validation when creating a person
- [ ] On server side error creating person, display error message on client screen
- [ ] Create constants for page routes


# Given More Time

This is not an exhastive list, these are just reminders of assorted items.
In addition to the items on the list, layering the application into clean architecture layers is a large potential item.

- TDD / Unit Tests
- Create and utlise a service result + define errors for all anticipated errors
- Inject services such as
  - DateTime
  - vowel count
- Introduce Stylecop or similar

