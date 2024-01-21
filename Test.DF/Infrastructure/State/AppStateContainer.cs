using Test.DF.Models;

namespace Test.DF.Infrastructure.State;

public class AppStateContainer
{
    public Person? Person { get; set; }

    public event Action OnStateChange;

    public void SetPerson(Person person)
    {
        this.Person = person;
    }

    private void NotifyStateChanged() => OnStateChange?.Invoke();
}
