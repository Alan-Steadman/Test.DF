using NSubstitute;
using Test.DF.Infrastructure.Services;
using Test.DF.Models;

namespace Test.DF.UnitTests;
public class PersonTests
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public PersonTests()
    {
        _dateTimeProvider = Substitute.For<IDateTimeProvider>();
        _dateTimeProvider.Now.Returns(DateTime.Now);
    }

    [Fact]
    public void Create_Should_ThrowArgumentException_WhenFullNameDoesNotHaveSpace()
    {
        // Arrange
        var fullName = "JohnSmith";
        var dob = new DateOnly(1990, 01, 01);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Person.Create(fullName, dob, _dateTimeProvider.Now));
    }

    [Fact]
    public void Create_Should_ThrowArgumentException_WhenDobIsInfuture()
    {
        // Arrange
        var fullName = "John Smith";
        var dob = DateOnly.FromDateTime(DateTime.Now.AddDays(1));

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Person.Create(fullName, dob, _dateTimeProvider.Now));
    }

    [Fact]
    public void Create_Should_ThrowArgumentException_WhenDobIsToday()
    {
        // Arrange
        var fullName = "John Smith";
        var dob = DateOnly.FromDateTime(DateTime.Now);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Person.Create(fullName, dob, _dateTimeProvider.Now));
    }

    [Fact]
    public void Create_Should_CreatePerson_WhenFullNameAndDobAreValid()
    {
        // Arrange
        var fullName = "John Smith";
        var dob = new DateOnly(1990, 01, 01);

        // Act
        var person = Person.Create(fullName, dob, _dateTimeProvider.Now);

        // Assert
        Assert.NotNull(person);
        Assert.Equal(fullName, $"{person.FirstName} {person.LastName}");
        Assert.Equal(dob, person.Dob);
    }

    [Fact]
    public void Create_Should_CreatePerson_WhenFullNameHasApostrophe()
    {
        // Arrange
        var fullName = "John O'Brian";
        var dob = new DateOnly(1990, 01, 01);

        // Act
        var person = Person.Create(fullName, dob, _dateTimeProvider.Now);

        // Assert
        Assert.NotNull(person);
        Assert.Equal(fullName, $"{person.FirstName} {person.LastName}");
    }

    [Fact]
    public void Create_Should_CreatePerson_WhenFullNameHasHyphen()
    {
        // Arrange
        var fullName = "John Smitherton-Smythe";
        var dob = new DateOnly(1990, 01, 01);

        // Act
        var person = Person.Create(fullName, dob, _dateTimeProvider.Now);

        // Assert
        Assert.NotNull(person);
        Assert.Equal(fullName, $"{person.FirstName} {person.LastName}");
    }

    [Theory]
    [InlineData("Llwn Llwynn", 0)]
    [InlineData("Llwn Llwelln", 1)]
    [InlineData("Aaron Aaronson", 7)]
    public void VowelCount_Should_CountVowelsCorrectly_WhenPersonIsValid(string fullName, int expectedVowels)
    {
        // Arrange
        var dob = new DateOnly(1990, 01, 01);
        var person = Person.Create(fullName, dob, _dateTimeProvider.Now);

        // Act
        var vowelCount = person.VowelCount();

        // Assert
        Assert.Equal(expectedVowels, vowelCount);
    }

    [Fact]
    public void Age_Should_GiveCorrectAge_WhenPersonIsValid()
    {
        // Arrange
        var expectedAge = 25;
        var dob = DateOnly.FromDateTime(_dateTimeProvider.Now.AddYears(-expectedAge).AddDays(-1));
        var fullName = "John Smith";
        var person = Person.Create(fullName, dob, _dateTimeProvider.Now);

        // Act
        var age = person.Age();

        // Assert
        Assert.Equal(expectedAge, age);
    }

}
