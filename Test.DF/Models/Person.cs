namespace Test.DF.Models;

public class Person
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly Dob { get; set; }

    private string FullName => $"{FirstName} {LastName}";

    private static readonly DateOnly today = DateOnly.FromDateTime(DateTime.Now); // Would inject a DateTime service instead of using DateTime.Now

    public Person() { }

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

        if (dob >= today)
        {
            throw new ArgumentException("Date of birth cannot be in the future");
        }

        var firstName = fullName.Substring(0, fullName.IndexOf(" "));
        var lastName = fullName.Substring(fullName.IndexOf(" ") + 1); // Ignoring multiple spaces

        return new Person(firstName, lastName, dob);
    }

    public int VowelCount()
    {
        return FullName.Count("aeiouAEIOU".Contains);
    }

    public int Age()
    {
        var age = today.Year - Dob.Year;

        if (Dob.AddYears(age) > today) age--;

        return age;
    }

    public DateOnly NextBirthday()
    {
        var nextBirthday = new DateOnly(today.Year, Dob.Month, Dob.Day);

        if (nextBirthday <= today)
        {
            nextBirthday = new DateOnly(today.Year + 1, Dob.Month, Dob.Day);
        }

        return nextBirthday;
    }

    public int DaysToNextBirthday()
    {
        return NextBirthday().DayNumber - today.DayNumber;
    }


    public List<DateAndLink> ListDaysLeadingToBirthday(int daystoList = 14)
    {
        var nextBirthday = NextBirthday();
        var days = new List<DateAndLink>();

        for (var day = 1; day <= daystoList; day++)
        {
            var date = nextBirthday.AddDays(-day);

            days.Add(
                new DateAndLink(
                    date: date,
                    formattedDate: $"{date: ddd dd MMMM}",
                    linkUrl: $"https://www.historynet.com/today-in-history/{date:MMMM-dd}"));
        }

        return days;
    }

    public record DateAndLink(DateOnly date, string formattedDate, string linkUrl);
}
