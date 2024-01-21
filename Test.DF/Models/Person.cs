namespace Test.DF.Models;

public class Person
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly Dob { get; set; }

    private Person(string firstName, string lastName, DateOnly dob)
    {
        FirstName = firstName;
        LastName = lastName;
        Dob = dob;
    }

    public static Person Create(string fullName, DateOnly dob)
    {
        if (!fullName.Contains(" "))
        {
            throw new ArgumentException("Full name must contain a first name and a last name seperated by a space");
        }

        if (dob >= DateOnly.FromDateTime(DateTime.Now))
        {
            throw new ArgumentException("Date of birth cannot be in the future");
        }

        var firstName = fullName.Substring(0, fullName.IndexOf(" "));
        var lastName = fullName.Substring(fullName.IndexOf(" ") + 1); // Ignoring multiple spaces

        return new Person(firstName, lastName, dob);
    }

}
