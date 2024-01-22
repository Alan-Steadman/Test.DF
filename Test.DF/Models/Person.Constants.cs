namespace Test.DF.Models;

public partial class Person
{
    public const string FullNameRegex = @"^[a-zA-Z]*\s[a-zA-Z\-\']*$";
    public const string FullNameRegexMessage = "Full name must contain a first name and a last name seperated by a space";

    public const string DobFutureMessage = "The Date of Birth must be in the past";
}
